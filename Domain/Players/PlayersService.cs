using System;
using System.Linq;
using Domain.Infra;

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
                using (var db = new BrasileiraoContext())
                {
                    db.Players.Add(player);
                    return new CreatedPlayerDTO(player.Id);
                }
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Player GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Players.FirstOrDefault(x => x.Id == id);
            }
        }

        public CreatedPlayerDTO Update(Guid id, string name)
        {
            var player = GetById(id);

            var updatedPlayer = new Player(name);
            var playerValidation = updatedPlayer.Validate();

            using (var db = new BrasileiraoContext())
            {
                if (playerValidation.isValid)
                {
                    db.Players.Add(updatedPlayer);
                    db.Players.Remove(player);
                    return new CreatedPlayerDTO(updatedPlayer.Id);
                }
            }
            return new CreatedPlayerDTO(playerValidation.errors);
        }

        public Guid? Delete(Guid id)
        {
            var player = GetById(id);
            using (var db = new BrasileiraoContext())
            {
                if (player != null)
                {
                    db.Players.Remove(player);
                    return id;
                }
            }
            return null;
        }
    }
}