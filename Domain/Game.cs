using System;

namespace Domain
{
    public class Game
    {
        public Guid Id { get; set; } = new Guid();
        public int Round { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }

        public Game(int round, Team team1, Team team2, User user)
        {
            if ((user.Profile == User.UserProfile.CBF) && (team1.Id != team2.Id))
            {
                Round = round;
                Team1 = team1;
                Team2 = team2;
            }
        }
        

    }
}