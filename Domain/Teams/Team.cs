using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;
using Domain.Players;
using Domain.Common;

namespace Domain.Teams
{
    public class Team : Entity
    {
        public string Name { get; set; }
        public virtual IList<Player> Players { get; set; }
        public int DisputedMatches { get; set; } = 0;
        public int Points { get; set; } = 0;
        public int Victories { get; set; } = 0;
        public int Defeats { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int GoalsOutcome { get; set; } = 0;
        public int Goals { get; set; } = 0;
        public int ConcededGoals { get; set; } = 0;
        public double EfficiencyPercent { get; set; } = 0;

        public Team(string name, IList<string> players)
        {
             Name = name;
            if (players != null)
            {
                Players = players
                    .Select(playerName => new Player(Id, playerName))
                    .ToList();
            }
        }

         protected Team() {}

        protected bool ValidateName()
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

        protected bool ValidateTeamName()
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
            if (Players != null)
            {
                Players.Any(player => !player.Validate().isValid);
                errors.Add("Há jogadores inválidos");
            }
            return (errors, errors.Count == 0);
        }


        // public bool AddPlayer(Player player, User user)
        // {
        //     var playerAlreadyExists = Players.FirstOrDefault(x => x.Name == player.Name);
        //     var playerValidation = player.Validate();


        //     if ((user.Profile == UserProfile.CBF)
        //         && (Players.Count < 32)
        //         && (playerAlreadyExists == null)
        //         && (playerValidation.isValid))
        //     {
        //         Players.Add(player);
        //         return true;                
        //     }
        //     return false;          
        // }
        
        // public bool RemovePlayer(string name, User user)
        // {
        //     if (user.Profile == UserProfile.CBF)
        //     {    
        //         var RemovedPlayer = Players.First(x => x.Name == name);
        //         Players.Remove(RemovedPlayer);
        //         return true;
        //     }
        //     return false;
        // }

        // public double GetEfficiency(int round, Team team, User user)
        // {
            
        //     int totalPossiblePoints = team.DisputedMatches * 3;
        //     return team.Points / totalPossiblePoints * 100;
        // }
    
        // public static void LaunchScorerGoals(Team team, List<Player> scorers, User user)
        // {
        //     foreach (var scorer in scorers)
        //     {
        //         Player p = team.Players.FirstOrDefault(x => x.Name == scorer.Name);
        //         if (p != null) p.Goals += scorer.Goals;
        //     }
        // }
    }
}