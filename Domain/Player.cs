using System;

namespace Domain
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; } = 0;
        public int OwnGoal { get; set; } = 0;

        public Player(string name, int goal, int ownGoal)
        {
            Name = name;
            goal = Goal;
            ownGoal = OwnGoal;
        }
    }
}