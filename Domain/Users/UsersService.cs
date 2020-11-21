using System;

namespace Domain.Users
{
    public class UsersService
    {
        private readonly UsersRepository _usersRepository = new UsersRepository();
        public CreatedUserDTO Create(string name, UserProfile profile)
        {
            var user = new User(name, profile);
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