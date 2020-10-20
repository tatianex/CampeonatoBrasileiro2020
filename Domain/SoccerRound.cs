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

        public SoccerRound(List<Team> teams, User user) 
        {
            var sizeOfRoundGroup = teams.Count / 2;

            for (int i = 0; i <= sizeOfRoundGroup; i++)
            {
                RoundGames.Add((teams[i], teams[teams.Count - i]));
            }

            /*
                Fluminense
                Flamengo
                Santos
                Vasco 
                Botafogo
                Palmeiras
                Cruzeiro
                Atlético Mineiro

                Fluminense x Atlético Mineiro
                Flamengo x Cruzeiro
                Santos x Palmeiras
                Vasco x Botafogo
            */
        }

        public void LaunchRoundResults()
        {

        }

        public void GetTopScorer()
        {

        }
    }
}