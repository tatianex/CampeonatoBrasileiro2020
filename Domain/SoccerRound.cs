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

        public SoccerRound(int round, List<Team> teams, User user) 
        {
            if (
                (user.Profile == User.UserProfile.CBF)
                && (teams.Count > 7)
                && (teams.Count % 2 == 0)
            )
            {
                var amountOfGamesPerRound = teams.Count / 2;
                var totalRounds = teams.Count - 1;
                var actualRound = 1;

                var games = teams.Count -1 * amountOfGamesPerRound;
                var sortition = new Random();
                sortition.Next(games);

                for (int team1 = 0; team1 <= totalRounds; team1++)
                {                  
                    for (int team2 = totalRounds; team2 >= 0; team2--)
                    {
                        if (teams[team1].Id != teams[team2].Id)
                        {
                            RoundGames.Add((teams[team1], teams[team2]));
                            break;
                        }
                    }
                    actualRound++;
                }
            }

            /*
                A rodada é formada selecionando a lista de times, criando uma nova lista
                onde são passados o primeiro time da lista e o último para formar um jogo
                com 4 jogos (considerando que tenham 8 times) forma-se uma rodada.

                {Fluminense, Flamengo, Santos, Vasco, Botafogo, Palmeiras, Cruzeiro, Atlético Mineiro}

                Rodada 1 - Jogo 1: Fluminense x Atlético Mineiro
                Rodada 1 - Jogo 2: Fluminense x Cruzeiro
                Rodada 1 - Jogo 3: Fluminense x Palmeiras
                Rodada 1 - Jogo 4: Fluminense x Botafogo

                Rodada 2 - Jogo 5: Flamengo x Atlético Mineiro
                Rodada 2 - Jogo 6: Fl
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