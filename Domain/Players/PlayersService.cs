using System;

namespace Domain.Players
{
    public class PlayersService
    {
        private readonly PlayersRepository _playersRepository = new PlayersRepository();
        public CreatedPlayerDTO CreatePlayer(Guid teamId, string name)
        {
            var player = new Player(teamId, name);
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