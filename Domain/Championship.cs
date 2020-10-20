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

        private void CreateRounds(List<Team> teams, User user)
        {
            for (int round = 0; round < teams.Count - 1; round++)
            {
                _rounds.Add(new SoccerRound(round, teams, user));
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