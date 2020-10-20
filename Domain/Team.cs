using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Team
    {  
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        private List<Player> _players { get; set; }
        public IReadOnlyCollection<Player> Players => _players;

        public Team(Guid id, string name)
        {
            // Lista privada para acesso do torcedor
            _players = new List<Player>();
            Id = id;
            Name = name;            
        }
        
        public bool AddPlayer(Player player, User user)
        {
            if (user.Profile == User.UserProfile.CBF && _players.Count < 32)
            {
                var SamePlayer = _players.First(x => x.Name == player.Name);
                return false;                
            }
            else
            {
                _players.Add(player);
                return true;
            }           
        }
        
        public bool RemovePlayer(string name, User user)
        {
            if (user.Profile == User.UserProfile.CBF && _players.Count > 16)
            {    
                var RemovedPlayer = _players.First(x => x.Name == name);
                _players.Remove(RemovedPlayer);
                return true;
            }
            return false;
        }

        public bool ValidatePlayersAmount()
        {
            if (_players.Count >= 16 && _players.Count <= 32)
            {
                return true;
            }
            return false;
        }
    }
}