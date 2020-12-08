using System;
using System.Collections.Generic;
using Domain.People;
using Domain.Entities;

namespace Domain.Users
{
    
    public class User : Person
    {
        public UserProfile Profile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string name, string password, string email, UserProfile profile) : base(name)
        {
            Password = password;
            Email = email;
            Profile = profile;
        }

        // Colocar o VALIDATE no usersService dentro de Create e o BadRequest no webapi
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}