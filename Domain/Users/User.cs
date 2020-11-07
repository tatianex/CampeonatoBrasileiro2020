using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Users
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();    
        public string Name { get; set; }
        public UserProfile Profile { get; set; }

        public User(string name, UserProfile profile)
        {
            Name = name;
            Profile = profile;
        }

        private bool ValidateauUserName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
            if (words.Length < 2)
            {
                return false;
            }

            foreach (var word in words)
            {
                if (word.Trim().Length < 2)
                {
                    return false;
                }
                if (word.Any(x => !char.IsLetter(x)))
                {
                    return false;
                }
            }
            return true;
        }

        // Colocar o VALIDATE no usersService dentro de Create e o BadRequest no webapi
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateauUserName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}