using System;
using Domain.Users;
using Domain.Teams;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Players
{
    public class Player
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; }
        public int Goals { get; set;}
        public Team Team { get; private set; }  // O professor não colocou, verificar...

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, Team team, int goals, User user)
        {
            if (user.Profile == UserProfile.CBF)
            {
                Name = name;
                Team = team;
                Goals = goals;
            }          
        }

        private bool ValidatePlayerName()
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

        // Colocar o VALIDATE no playersService dentro de Create e o BadRequest no webapi
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidatePlayerName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}