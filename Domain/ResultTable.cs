using System;
using System.Collections.Generic;

namespace Domain
{
    public class ResultTable
    {
        public int DisputedMatches { get; set; }
        public int TeamPoints { get; set; }
        public int TeamVictories { get; set; }
        public int TeamDefeats { get; set; }
        public int Ties { get; set; }
        public int GoalsOutcome { get; set; }
        public int Goals { get; set; }
        public int OwnGoals { get; set; }
        public double EfficiencyPercent { get; set; }
        public List<Player> TopScorer { get; set; }
        public List<Team> RelegatedTeam { get; set; }
        public List<Team> QualifiedTeam { get; set; }
    }
}