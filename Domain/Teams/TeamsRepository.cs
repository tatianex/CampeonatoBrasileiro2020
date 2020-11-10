using System.Collections.Generic;

namespace Domain.Teams
{
    static class TeamsRepository
    {
        private static List<Team> _teams { get; set; } = new List<Team>();
        public static IReadOnlyCollection<Team> Players => _teams;

        public static void Add(Team team)
        {
            _teams.Add(team);
        }
    }
}