using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        public int TotalRound { get; set; } = 7;
        public List<Team> Teams { get; set; }

        public bool CreateTeams(List <Team> teams, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Teams = teams;
                return true;
            }
            return false;            
        }

        private void CreateDispute()
        {
            // var Palmeiras = new Team("Pal", "Palmeiras");
        }

        public void ShowFinalResults()
        {

        }

        public void ShowTeamPoints()
        {

        }
    }
}