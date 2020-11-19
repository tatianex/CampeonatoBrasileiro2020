using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Domain.Players;
using Domain.Teams;

namespace Domain.Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Player> Players {get; set;}
        // Override pois estamos sobrescrevendo o comportamento padrão.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Initial Catalog = nome do banco de dados que será criado
            //PWD  = Password
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=some(!)Password;Initial Catalog=Brasileirao");
        }
    }
}