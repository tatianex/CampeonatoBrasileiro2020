using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team
    {  
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }

        public Team(Guid id, string name)
        {
            // Lista privada para acesso do torcedor
            _players = new List<Player>();
            Id = id;
            Name = name;            
        }
        private List<Player> _players { get; set; }
        public IReadOnlyCollection<Player> Players => _players;

        public void AddPlayer(Player player)
        {
            
        }
        public bool RemovePlayer(string name, User user)
        {
            if (user.Profile == User.UserProfile.CBF)
            {    
                var RemovedPlayer = _players.First(x => x.Name == name);
                _players.Remove(RemovedPlayer);
                return true;
            }
            return false;
        }
    }
}