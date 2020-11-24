using System;
using System.Linq;
using Domain.Infra;

namespace Domain.Players
{
    public class PlayersRepository
    {
        public void Add(Player player)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Players.Add(player);
                db.SaveChanges();
            }
        }
        
        public Player GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Players.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Remove(Player player)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Players.Remove(player);
            }
        }
    }
}