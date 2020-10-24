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
        public int DisputedMatches { get; set; }
        public int TeamPoints { get; set; }
        public int TeamVictories { get; set; }
        public int TeamDefeats { get; set; }
        public int Ties { get; set; }
        public int GoalsOutcome { get; set; }
        public int Goals { get; set; }
        public int concededGoals { get; set; }
        public double EfficiencyPercent { get; set; }

        public Team(string name)
        {
            // Lista privada para acesso do torcedor
            _players = new List<Player>();
            Name = name;
        }
        
        public bool AddPlayer(Player player, User user)
        {
            var playerAlreadyExists = _players.FirstOrDefault(x => x.Name == player.Name);

            if ((user.Profile == User.UserProfile.CBF)
                && (_players.Count < 32)
                && (playerAlreadyExists == null))
            {
                _players.Add(player);
                return true;                
            }
            return false;          
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

        public void GetEfficiency(SoccerRound round, Team team, User user)
        {
            if (user.Profile == User.UserProfile.CBF || user.Profile == User.UserProfile.Fan)
            {  
                round.RoundNumber = round;
                //double EfficiencyPercent = TeamPoints / totalPossiblePoints (quantidade de jogos * 3) * 100;

            

            }
            
            
             
        }
    }
}