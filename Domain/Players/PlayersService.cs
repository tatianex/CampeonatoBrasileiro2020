using System;
using System.Linq;

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

        public Player GetById(Guid id)
        {
            return PlayersRepository.Players.FirstOrDefault(x => x.Id == id);
        }

        public CreatedPlayerDTO Update(Guid id, string name)
        {
            var player = GetById(id);

            var updatedPlayer = new Player(name);
            var playerValidation = updatedPlayer.Validate();

            if (playerValidation.isValid)
            {
                PlayersRepository.Add(updatedPlayer);
                PlayersRepository.Remove(player);
                return new CreatedPlayerDTO(updatedPlayer.Id);
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Guid? Delete(Guid id)
        {
            var player = GetById(id);
            if (player != null)
            {
                PlayersRepository.Remove(player);
                return id;
            }
            return null;
        }
    }
}