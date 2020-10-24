using System;
using System.Collections.Generic;

namespace Domain
{
    public class SoccerRound
    {
        public int RoundNumber { get; set; }
        public DateTime BeginingDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<(Team, Team)> RoundGames { get; set;}


        public void LaunchRoundResults()
        {

        }

        public void GetTopScorer()
        {

        }

        public static implicit operator int(SoccerRound v)
        {
            throw new NotImplementedException();
        }
    }
}