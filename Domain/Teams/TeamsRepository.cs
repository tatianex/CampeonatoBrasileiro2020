using Domain.Infra;
using System;
using System.Linq;

namespace Domain.Teams
{
    public class TeamsRepository
    {
        public void Add(Team team)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }

        public Team GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Teams.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}