using System;
using Domain.Common;
using Domain.Users;

namespace Domain.Authentication
{
    public class AuthService
    {
        private readonly UsersRepository _usersRepository = new UsersRepository();

        public AuthResponse Login(string email, string password)
        {
            var user = _usersRepository.GetByEmail(email);
            if (user == null)
            {
                return new AuthResponse();
            }

            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);

            return user.Password == cryptPassword
                ? new AuthResponse(user.Id)
                : new AuthResponse();
        }
        
        public User GetById(Guid id)
        {
            return _usersRepository.GetById(id);
        }
    }
}