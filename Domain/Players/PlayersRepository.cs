using System.Collections.Generic;

namespace Domain.Players
{
    static class PlayersRepository
    {
        private static List<Player> _players { get; set; } = new List<Player>();
        public static IReadOnlyCollection<Player> Players => _players;

        public static void Add(Player player)
        {
            _players.Add(player);
        }
    }
}