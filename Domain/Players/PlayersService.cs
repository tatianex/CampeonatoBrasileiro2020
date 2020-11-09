using Domain.Users;
using Domain.Players;

namespace Domain.Players
{
    public class PlayersService
    {
        public CreatedPlayerDTO CreatePlayer(string name)
        {
            var player = new Player(name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                PlayersRepository.Add(player);
                return new CreatedPlayerDTO(player.Id);
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }
    }
}