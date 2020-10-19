using System;
using System.Collections.Generic;

namespace Domain
{
    public class Team
    {  
        public string Id { get; set; }
        public string Name { get; set; }

        public Team()
        {
            // Lista privada para acesso do torcedor
            playersList = new List<Player>();
            
        }
        private List<Player> playersList { get; set; }
        public IReadOnlyCollection<Player> Players => playersList;

        public bool CreateTeams(List<Player> players, string password)
        {
            if (password == "459iMs@;3eZ!8*")
            {
                playersList = players;
                return true;
            }
            return false;
        }

        public void AddPlayer(Player player)
        {
            
        }
        public void RemovePlayer(Player player)
        {
            
        }
    }
}