using System;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; set; } = new Guid();
        public Team Team { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; } = 0;
        public int OwnGoal { get; set; } = 0;

        public Player(Team team, string name, int goal, int ownGoal, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Team = team;
                Name = name;
                Goal = goal;
                OwnGoal = ownGoal;
            }          
        }
    }
}