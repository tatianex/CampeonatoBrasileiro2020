using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        public int TotalRound { get; set; } = 7;
        private List<Team> Teams { get; set; }
        
        public bool CreateTeams(List <Team> teams, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Teams = teams;
                return true;
            }
            return false;            
        }

        private void CreateRounds(List <Team> teams, User user)
        {
            if (user.Profile == User.UserProfile.CBF && teams.Count > 7)
            {
                //Criar automaticamente uma lista tuplas onde cada time joga com os outros 1 vez.
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