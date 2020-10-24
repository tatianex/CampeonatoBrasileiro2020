using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class ChampionshipTest
    {
        public List<Player> GetMockPlayers(int amount, User user)
        {
            var mockPlayers = new List<Player>
            {
                new Player("Gabriel", user),
                new Player("Marcos", user),
                new Player("Rodolfo", user),
                new Player("Rafael", user),
                new Player("Diego", user),
                new Player("Yuri", user),
                new Player("Luan", user),
                new Player("Daniel", user),
                new Player("Miguel", user),
                new Player("Matheus", user),
                new Player("Lucas", user),
                new Player("Caio", user),
                new Player("William", user),
                new Player("Fernando", user),
                new Player("Felipe", user),
                new Player("Wellington", user),
                new Player("Luiz Henrique", user),
                new Player("Vinícius", user),
                new Player("Thiago", user),
                new Player("Pedro", user),
                new Player("Raul", user),
                new Player("Ruan", user),
                new Player("Ramon", user),
                new Player("Bruno", user),
                new Player("Fabio", user),
                new Player("Marcelo", user),
                new Player("Leandro", user),
                new Player("João", user),
                new Player("Antônio", user),
                new Player("Gustavo", user),
            };

            return mockPlayers.Take(amount).ToList();
        }
        
        public List<Team> GetMockTeams(int amount)
        {
            var mockTeams = new List<Team>
            {
                new Team("Goiás"),
                new Team("Coritiba"),
                new Team("Athletico-PR"),
                new Team("Vasco"),
                new Team("Botafogo"),
                new Team("Bragantino"),
                new Team("Ceará-SC"),
                new Team("Bahia"),
                new Team("Sport"),
                new Team("Grêmio"),
                new Team("Corinthians"),
                new Team("Atlético-GO"),
                new Team("Palmeiras"),
                new Team("Fortaleza"),
                new Team("Fluminense"),
                new Team("Santos"),
                new Team("São Paulo"),
                new Team("Atlético-MG"),
                new Team("Flamengo"),
                new Team("Internacional")

            };

            return mockTeams.Take(amount).ToList();
        }
        
        /* [Fact]
        public void should_do_something()
        {
            var user = new User("Tatiane", "password", User.UserProfile.CBF);
        
            var soccer = new Championship(teams, user);
            soccer.CreateRounds(user);
        } */
    }
}