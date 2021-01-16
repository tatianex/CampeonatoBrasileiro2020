using System;
using Domain.Users;
using Domain.Teams;
using System.Collections.Generic;
using Domain.People;

namespace Domain.Players
{
    public class Player : Person
    {
        public int Goals { get; set;}
        // A propriedade virtual indica ao EF que é uma propriedade de navegação
        public virtual Team Team { get; private set; }
        public Guid TeamId { get; private set; }

        public Player (Guid teamId, string name) : base(name)
        {
            TeamId = teamId;
        }
        
        public Player(string name, Team team, int goals, User user) : base(name)
        {
            if (user.Profile == UserProfile.CBF)
            {
                Team = team;
                Goals = goals;
            }          
        }

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