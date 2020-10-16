using System.Collections.Generic;

namespace Domain
{
    public class Championship
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int TotalRound { get; set;} = 7;

        public void CreateTeam(List <Player> players)
        {
            
        }

        private void CreateDispute()
        {

        }

        public void ShowFinalResults()
        {

        }

        public void ShowTeamPoints()
        {

        }
    }
}