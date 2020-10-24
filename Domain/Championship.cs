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
            if ((user.Profile == User.UserProfile.CBF)
                && (teams.Count > 7)
                && (teams.Count % 2 == 0))
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
            if ((user.Profile == User.UserProfile.CBF)
                && (Teams.Count > 7)
                && (Teams.Count % 2 == 0)
            )
            {
                // Embaralha a lista de times
                Tools.Shuffle(_teams);
                // Seleciona o time e divide em dois gerando o tamanho dos grupos
                // E o total de jogos da rodada
                var sizeOfGroup = _teams.Count / 2;
                // Calcula o total de rodadas do campeonato
                var totalRounds = _teams.Count - 1;
                // Grupo A recebe a primeira metade da lista de times
                var groupA = _teams.Take(sizeOfGroup).ToList();
                // Grupo B recebe a última metade da lista de times
                var groupB = _teams.Skip(sizeOfGroup).Take(sizeOfGroup).ToList();
                
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
                
                using (StreamWriter file = new StreamWriter(@"D:\DOCS\Dev\PROWAY\C#\jogos.txt"))
                {
                    for (int line = 0; line < Games.Count; line++)
                    {
                        file.WriteLine($"Rodada: {_games[line].Round}: Jogo: {_games[line].Team1.Name} x {_games[line].Team2.Name}");
                    }
                }
            }
        }

        public void CreateMatchResults(User user, int round, Team team1, Team team2)
        {
            var randomGoals = new Random();
            if ((user.Profile == User.UserProfile.CBF) && (team1.Id != team2.Id))
            {
                team1.DisputedMatches++;
                team2.DisputedMatches++;

                int team1Goals = randomGoals.Next(0, 6);
                int team2Goals = randomGoals.Next(0, 6);
                
                team1.Goals += team1Goals;
                team2.Goals += team2Goals;

                team1.concededGoals += team2Goals;
                team2.concededGoals += team1Goals;

                team1.GoalsOutcome += team1Goals - team2Goals;
                team2.GoalsOutcome += team2Goals - team1Goals;

                if (team1Goals == team2Goals)
                {
                    team1.TeamPoints++;
                    team2.TeamPoints++;
                    team1.Ties++;
                    team2.Ties++;
                }
                else if (team1Goals > team2Goals)
                {
                    team1.TeamPoints += 3;
                    team1.TeamVictories++;
                    team2.TeamDefeats++;
                }
                else
                {
                    team2.TeamPoints += 3;
                    team2.TeamVictories++;
                    team1.TeamDefeats++;
                }
            }
            
        }

        public void ShowFinalResults()
        {

        }

        public void ShowTeamPoints()
        {

        }
    }
}