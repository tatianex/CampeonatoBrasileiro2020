using System;

namespace Domain.Users
{
    public class UsersService
    {
        public Guid Create(string name, UserProfile profile)
        {
            var user = new User(name, profile);
            UsersRepository.Add(user);
            return user.Id;
        }
    }
}