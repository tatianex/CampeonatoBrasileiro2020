using System;
using Domain.Users;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public int Goals { get; set;}
        public Team Team { get; set; }

        public Player(string name, User user)
        {
            if (user.Profile == UserProfile.CBF)
            {
                Name = name;
            }          
        }

        public Player(string name, Team team, int goals, User user)
        {
            if (user.Profile == UserProfile.CBF)
            {
                Name = name;
                Team = team;
                Goals = goals;
            }          
        }
    }
}