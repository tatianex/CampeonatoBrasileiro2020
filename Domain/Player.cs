using System;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; }
        public int Goals { get; set;}

        public Player(string name, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {
                Name = name;
            }          
        }
    }
}