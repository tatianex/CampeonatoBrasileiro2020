/* using System;
using Domain.Users;

namespace Domain.Players
{
    public class PlayersService
    {
        public Guid CreatePlayer(string name, UserProfile profile)
        {
            var player = new Player(name);
            PlayersRepository.Add(player);  // criar PlayerRepository
            return player.Id;
        }
    }
} */