using System.Collections.Generic;
using Domain.Infra;
using System;
using System.Linq;

namespace Domain.Users
{
    public class UsersRepository
    {
        public void Add(User user)
        {
            using (var db = new BrasileiraoContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public User GetById(Guid id)
        {
            using (var db = new BrasileiraoContext())
            {
                return db.Users.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}