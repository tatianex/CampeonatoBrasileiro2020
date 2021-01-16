using System.Collections.Generic;
using Domain.People;
using System.Text.RegularExpressions;
using System;

namespace Domain.Users
{
    
    public class User : Person
    {
        public UserProfile Profile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string email, UserProfile profile, string password) : base(name)
        {
            Id = Guid.NewGuid();
            Email = email;
            Profile = profile;
            Password = password;
        }

        private bool ValidateEmail()
        {
            return Regex.IsMatch(
                Email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );
        }

        // Colocar o VALIDATE no usersService dentro de Create e o BadRequest no webapi
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }

            if (!ValidateEmail())
            {
                errors.Add("Email inválido.");
            }

            return (errors, errors.Count == 0);
        }
    }
}