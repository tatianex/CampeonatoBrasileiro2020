using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;
using Domain.Players;

namespace Domain.Teams
{
    public class Team
    {  
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        private List<Player> _players { get; set; }
        public IReadOnlyCollection<Player> Players => _players;
        public int DisputedMatches { get; set; }
        public int Points { get; set; }
        public int Victories { get; set; }
        public int Defeats { get; set; }
        public int Draws { get; set; }
        public int GoalsOutcome { get; set; }
        public int Goals { get; set; }
        public int ConcededGoals { get; set; }
        public double EfficiencyPercent { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public Team(string name, List<Player> players)
        {
            Name = name;
            // Lista privada para acesso do torcedor
            _players = players;
        }

        public bool ValidateTeamPlayers(List<Player> players)
        {
            foreach (var item in players)
            {
                var validation = item.Validate();
                if (!validation.isValid)
                {
                    break;
                }
                return false;
            }
            return true;
        }
        
        public bool AddPlayer(Player player, User user)
        {
            var playerAlreadyExists = _players.FirstOrDefault(x => x.Name == player.Name);
            
            if ((user.Profile == UserProfile.CBF)
                && (_players.Count < 32)
                && (playerAlreadyExists == null)
                && (ValidateTeamPlayers(_players) == true))
            {
                _players.Add(player);
                return true;                
            }
            return false;          
        }
        
        public bool RemovePlayer(string name, User user)
        {
            if (user.Profile == UserProfile.CBF)
            {    
                var RemovedPlayer = _players.First(x => x.Name == name);
                _players.Remove(RemovedPlayer);
                return true;
            }
            return false;
        }

        public double GetEfficiency(int round, Team team, User user)
        {
            
            int totalPossiblePoints = team.DisputedMatches * 3;
            return team.Points / totalPossiblePoints * 100;
        }
    
        public static void LaunchScorerGoals(Team team, List<Player> scorers, User user)
        {
            foreach (var scorer in scorers)
            {
                Player p = team._players.Find(x => x.Name == scorer.Name);
                if (p != null) p.Goals += scorer.Goals;
            }
        }

        private bool ValidateTeamName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }

            var words = Name.Split(' ');
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

        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateTeamName())
            {
                errors.Add("Nome inválido.");
            }
            return (errors, errors.Count == 0);
        }
    
    }
}