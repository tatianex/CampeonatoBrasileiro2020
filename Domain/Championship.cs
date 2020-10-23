using System.Linq;
using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        private List<Team> Teams { get; set; }
        private List<SoccerRound> _rounds { get; set; }
        public IReadOnlyCollection<SoccerRound> Rounds => _rounds;

        public bool CreateTeams(List<Team> teams, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Teams = teams;
                return true;
            }
            return false;            
        }

        public CreateRounds(List<Team> groupA, List<Team> groupB, User user)
        {
            
            if (
                (user.Profile == User.UserProfile.CBF)
                && (groupA.Count > 3)
                && (groupB.Count == groupA.Count)
                && ((groupA.Count + groupB.Count) % 2 == 0)
            )
            {
                var amountOfGamesPerRound = groupA.Count;
                var totalRounds = (groupA.Count + groupB.Count) - 1;
                var actualRound = 1

                var games = ((groupA.Count + groupB.Count) -1) * amountOfGamesPerRound;
                // var sortition = new Random();
                // sortition.Next(games);

                for (var i = 0; i < totalRounds; i++)
                {
                    for (int team1 = 0; team1 <= amountOfGamesPerRound; team1++)
                    {                  
                        for (int team2 = amountOfGamesPerRound; team2 >= 0; team2--)
                        {
                            if (groupA[team1].Id != groupB[team2].Id)
                            {
                                RoundGames.Add((groupA[team1], groupB[team2]));
                                break;
                            }
                        }
                    }
                    actualRound++;
                    // Usar add e remove nas listas.
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