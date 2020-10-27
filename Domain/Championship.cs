using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace Domain
{
    public class Championship
    {
        private List<Game> _games { get; set; }
        public IReadOnlyCollection<Game> Games => _games;
        private List<Team> _teams { get; set; }
        public IReadOnlyCollection<Team> Teams => _teams;
        
        public Championship(List<Team> teams, User user)
        {
            if ((user.Profile == User.UserProfile.CBF) && (teams.Count > 7))
            {
                var validTeam = false;
                
                for (int actualTeam = 0; actualTeam < teams.Count; actualTeam++)
                {
                    var totalTeamPlayers = teams[actualTeam].Players.Count;
                    if ((totalTeamPlayers > 15) && (totalTeamPlayers < 33))
                    {
                        validTeam = true;
                    }
                    else
                    {
                        validTeam = false;
                        break;
                    }
                }

                if (validTeam)
                {
                    // Cria uma lista vazia de Times do campeonato
                    _teams = new List<Team>();

                    // Preenche a lista vazia que foi criada
                    // com os times passados por parâmetro
                    _teams = teams;
                } 
                else throw new System.Exception("Os times precisam ter entre 16 e 32 jogadores");

                _games = new List<Game>();
            }
            else throw new System.Exception("Total de times deve ser par e > 7 e usuário CBF");
        }
        
        public void CreateRounds(User user)
        {            
            if ((user.Profile == User.UserProfile.CBF) && (Teams.Count > 7))
            {
                // Embaralha a lista de times
                Tools.Shuffle(_teams);
                /*
                    Se o total de times for ímpar, é inserido um "time falso" 
                    indicando que o time que for sorteado junto com o competidor 
                    "Fora da rodada" vai descansar naquela rodada, iniciando pelo
                    primeiro time sorteado na primeira rodada
                */
                if (_teams.Count % 2 != 0)
                {
                    _teams.Insert(0, new Team("Fora da rodada!", null));
                }
                // Seleciona o time e divide em dois gerando o tamanho dos grupos
                // E o total de jogos da rodada
                var sizeOfGroup = _teams.Count / 2;
                // Calcula o total de rodadas do campeonato
                var totalRounds = _teams.Count - 1;
                // Grupo A recebe a primeira metade da lista de times
                var groupA = _teams.Take(sizeOfGroup).ToList();
                // Grupo B recebe a segunda metade da lista de times
                var groupB = _teams.TakeLast(sizeOfGroup).ToList();
                
                for (var actualRound = 1; actualRound <= totalRounds; actualRound++)
                {
                    // Os times do Grupo B são selecionados da última para a primeira posição
                    var teamB = groupB.Count - 1;    
                    // Loop que preenche a lista de jogos de uma rodada
                    for (int teamA = 0; teamA < sizeOfGroup; teamA++)
                    {
                        var game = new Game(actualRound, groupA[teamA], groupB[teamB], user);
                        _games.Add(game);
                        teamB--;
                    }

                    // Insere o último time do Grupo B na segunda posição do Grupo A
                    groupA.Insert(1, groupB[groupB.Count - 1]);
                    // Remove o último time do Grupo B
                    groupB.RemoveAt(groupB.Count - 1);
                    // Insere o último time do Grupo A na primeira posição do Grupo B
                    groupB.Insert(0, groupA[groupA.Count - 1]);
                    // Remove o úlimo time do Grupo A
                    groupA.RemoveAt(groupA.Count - 1);            
                }
                
                // Criando um arquivo .txt com os confrontos de todas as rodadas
                using (StreamWriter file = new StreamWriter(@"D:\DOCS\Dev\PROWAY\C#\jogos.txt"))
                {
                    var actualRound = _games[0].Round;

                    for (int line = 0; line < Games.Count; line++)
                    {
                        if (actualRound != _games[line].Round)
                        {
                            file.Write("\r\n");
                            actualRound = _games[line].Round;
                        }
                        file.WriteLine($"Rodada: {_games[line].Round}: Jogo: {_games[line].Team1.Name} x {_games[line].Team2.Name}");
                    }
                }
            }
        }

        /* public void CreateMatchResults(User user, int round, Team team1, Team team2)
        {

                team1.EfficiencyPercent = team1.GetEfficiency(round, team1, user);
                team2.EfficiencyPercent = team2.GetEfficiency(round, team2, user);
            }
            
        } */

        public bool LaunchRoundResults(int round, List<Game> gamesResults, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                /*
                    Verificar se os times que estamos inserindo
                    são iguais aos times registrados na rodada
                    Ex: Estou querendo colocar o resultado do jogo do time A com B
                    Preciso verificar se o primeiro jogo era realmente de A com B
                */ 
                var gamesRoundOfficial = new List<Game>();
                gamesRoundOfficial = _games.Where(x => x.Round == round).ToList();

                for (var i = 0; i < gamesResults.Count; i++)
                {
                    if (gamesRoundOfficial[i].Id != gamesResults[i].Id)
                    {
                        throw new Exception("Jogos da rodada não coincidem!");
                    }
                }

                // Loop para inserir os resultados dos jogos da rodada
                // E o cálculo da tabela de pontos do campeonato por time
                for (var actualGame = 0; actualGame < gamesResults.Count; actualGame++) 
                {
                    // Informa o resultado do jogo atual
                    
                    // game trás a posição do confronto na lista oficial de jogos _games
                    // e nessa posição é inserido o resultado do confronto atual
                    // que é passado pelo parâmetro gamesResults
                    
                    var game = _games.IndexOf(gamesResults[actualGame]);
                    _games[game].Team1Goals = gamesResults[actualGame].Team1Goals;
                    _games[game].Team2Goals = gamesResults[actualGame].Team2Goals;

                    // Lança os resultados e calcula os pontos dos times do jogo atual

                    // Jogos disputados
                    _games[game].Team1.DisputedMatches++;
                    _games[game].Team2.DisputedMatches++;

                    // Total de gols do time
                    _games[game].Team1.Goals += _games[game].Team1Goals;
                    _games[game].Team2.Goals += _games[game].Team2Goals;

                    // Total de gols sofridos
                    _games[game].Team1.ConcededGoals += _games[game].Team2Goals;
                    _games[game].Team2.ConcededGoals += _games[game].Team1Goals;
                
                    // Saldo de gols recebe os gols feitos menos os gols sofridos
                    _games[game].Team1.GoalsOutcome += _games[game].Team1Goals - _games[game].Team2Goals;
                    _games[game].Team2.GoalsOutcome += _games[game].Team2Goals - _games[game].Team1Goals;
                
                    if (_games[game].Team1Goals == _games[game].Team2Goals)
                    {
                        // Quando há empate cada um dos times recebe um ponto
                        // e incrementa o histórico de empates
                        _games[game].Team1.Points++;
                        _games[game].Team2.Points++;
                        _games[game].Team1.Draws++;
                        _games[game].Team2.Draws++;
                    }
                    else if (_games[game].Team1Goals > _games[game].Team2Goals)
                    {
                        // Quando o time1 tem mais gols que 2º este recebe 3 pontos
                        // e incrementa suas vitórias e aumenta o histórico de derrotas do outro time
                        _games[game].Team1.Points += 3;
                        _games[game].Team1.Victories++;
                        _games[game].Team2.Defeats++;
                    }
                    else
                    {
                        // Quando o time2 tem mais gols que o primeiro ele recebe 3 pontos
                        // e incrementa suas vitórias e aumenta o histórico de derrotas do outro time
                        _games[game].Team2.Points += 3;
                        _games[game].Team2.Victories++;
                        _games[game].Team1.Defeats++;
                    }
                
                }

                return true;
            }
            else return false;
        }

        public void Scorecard()
        {

        }

        public void ShowTeamPoints()
        {

        }
    }
}