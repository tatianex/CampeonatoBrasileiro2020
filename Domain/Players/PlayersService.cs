using System;
using System.Linq;
using Domain.Infra;

namespace Domain.Players
{
    public class PlayersService
    {
        private readonly PlayersRepository _playersRepository = new PlayersRepository();
        public CreatedPlayerDTO CreatePlayer(string name)
        {
            var player = new Player(name);
            var playerValidation = player.Validate();

            if (playerValidation.isValid)
            {
                _playersRepository.Add(player);
                return new CreatedPlayerDTO(player.Id);
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Player GetById(Guid id)
        {
            return _playersRepository.GetById(id);
        }

        public CreatedPlayerDTO Update(Guid id, string name)
        {
            var player = GetById(id);

            var updatedPlayer = new Player(name);
            var playerValidation = updatedPlayer.Validate();

            if (playerValidation.isValid)
            {
                _playersRepository.Add(updatedPlayer);
                _playersRepository.Remove(player);
                return new CreatedPlayerDTO(updatedPlayer.Id);
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Guid? Delete(Guid id)
        {
            var player = GetById(id);
            if (player != null)
            {
                _playersRepository.Remove(player);
                return id;
            }
            return null;
        }
    }
}