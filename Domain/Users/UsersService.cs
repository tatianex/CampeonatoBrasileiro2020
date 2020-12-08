using System;
using Domain.Common;

namespace Domain.Users
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository = new UsersRepository();
        public CreatedUserDTO Create(
            string name,
            UserProfile profile,
            string email,
            string password
        )
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);
            
            var user = new User(name, cryptPassword, email, profile);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }
            return new CreatedUserDTO(userValidation.errors);
        }

        public User GetById(Guid id)
        {
            return _usersRepository.GetById(id);
        }
    }
}