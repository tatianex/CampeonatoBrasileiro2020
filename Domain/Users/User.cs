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

        public User(UserProfile profile, string name, string email, string password) : base(name)
        {
            Profile = profile;
            Email = email;
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