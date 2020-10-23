using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        public List<Team> Teams { get; set; }
        public List<Game> Games { get; set; }
        
        public Championship(List<Team> teams, User user)
        {
            if ((user.Profile == User.UserProfile.CBF)
                && (teams.Count > 7)
                && (teams.Count % 2 == 0))
            {
                Teams = teams;
                Games = new List<Game>();
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
                // Seleciona o time e divide em dois gerando o tamanho dos grupos
                // E o total de jogos da rodada
                var sizeOfGroup = Teams.Count / 2;
                // Calcula o total de rodadas do campeonato
                var totalRounds = Teams.Count - 1;
                // Grupo A recebe a primeira metade da lista de times
                var groupA = Teams.Take(sizeOfGroup).ToList();
                // Grupo B recebe a última metade da lista de times
                var groupB = Teams.Skip(sizeOfGroup).Take(sizeOfGroup).ToList();
                // Os times do Grupo B são selecionados da última para a primeira posição
                var teamB = groupB.Count - 1;    
                
                for (var actualRound = 1; actualRound < totalRounds; actualRound++)
                {
                    // Loop que preenche a lista de jogos de uma rodada
                    for (int teamA = 0; teamA <= sizeOfGroup - 1; teamA++)
                    {
                        var game = new Game(actualRound, groupA[teamA], groupB[teamB], user);
                        Games.Add(game);
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