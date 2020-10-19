using System;

namespace Domain
{
    public class Player
    {
        public string Id { get; set; }
        public string TeamName { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; } = 0;
        public int OwnGoal { get; set; } = 0;

        public Player(string teamName, string name, int goal, int ownGoal, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Id = name.Trim() + teamName.Trim();
                TeamName = teamName;
                Name = name;
                Goal = goal;
                OwnGoal = ownGoal;
            }          
        }
    }
}