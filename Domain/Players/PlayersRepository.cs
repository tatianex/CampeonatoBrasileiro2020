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

        public void Remove(Player player)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Players.Remove(player);
            }
        }
    }
}