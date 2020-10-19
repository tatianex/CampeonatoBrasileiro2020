using System;
using System.Collections.Generic;

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
        public void RemovePlayer(Player player)
        {
            
        }
    }
}