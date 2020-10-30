using System;

namespace Domain.Users
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();    
        public string Name { get; set; }
        public string Password { get; private set; }
        public UserProfile Profile { get; set; }

        public User(string name, string password, UserProfile profile)
        {
            Name = name;
            Password = password;
            Profile = profile;
        }
    }
}