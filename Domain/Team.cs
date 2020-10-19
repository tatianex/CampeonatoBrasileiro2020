using System;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Team(string id, string name, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Id = id;
                Name = name;
            }
        }

        public void AddPlayer(Player player)
        {
            
        }
        public void RemovePlayer(Player player)
        {
            
        }
    }
}