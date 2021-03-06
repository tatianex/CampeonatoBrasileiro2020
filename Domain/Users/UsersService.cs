using System;
using Domain.Common;

namespace Domain.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public CreatedUserDTO Create(
            UserProfile profile,
            string name,
            string email,
            string password
        )
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);
            
            var user = new User(profile, name, email, cryptPassword);
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
            return _usersRepository.Get(id);
        }
    }
}