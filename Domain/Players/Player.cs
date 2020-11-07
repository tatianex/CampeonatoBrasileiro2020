using System;
using Domain.Users;
using Domain.Teams;

namespace Domain
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Goals { get; set;}
        public Team Team { get; set; }

        // To do: Colocar a validação de user no PlayersController do WebAPI.
        public Player(string name)
        {
            Name = name;
        }

        // To do: Colocar a validação de user no PlayersController do WebAPI.
        public Player(string name, Team team, int goals, User user)
        {
            if (user.Profile == UserProfile.CBF)
            {
                Name = name;
                Team = team;
                Goals = goals;
            }          
        }
    }
}