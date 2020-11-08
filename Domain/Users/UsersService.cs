using System;

namespace Domain.Users
{
    public class UsersService
    {
        public Guid CreateUser(string name, UserProfile profile)
        {
            var user = new User(name, profile);
            var isValid = user.Validate().isValid;
            if (isValid)
            {
                UsersRepository.Add(user);
            }
            return user.Id;
        }      
    }
}