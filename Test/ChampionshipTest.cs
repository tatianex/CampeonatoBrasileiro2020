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
        
        public List<Team> GetMockTeams(int amount, User user)
        {
            var players = new List<Player>();
            players = GetMockPlayers(16, user);

            var mockTeams = new List<Team>
            {
                new Team("Goiás", players),
                new Team("Coritiba", players),
                new Team("Athletico-PR", players),
                new Team("Vasco", players),
                new Team("Botafogo", players),
                new Team("Bragantino", players),
                new Team("Ceará-SC", players),
                new Team("Bahia", players),
                new Team("Sport", players),
                new Team("Grêmio", players),
                new Team("Corinthians", players),
                new Team("Atlético-GO", players),
                new Team("Palmeiras", players),
                new Team("Fortaleza", players),
                new Team("Fluminense", players),
                new Team("Santos", players),
                new Team("São Paulo", players),
                new Team("Atlético-MG", players),
                new Team("Flamengo", players),
                new Team("Internacional", players)

            };

            return mockTeams.Take(amount).ToList();
        }
        
        [Fact]
        public void should_return_true_when_size_of_teams_and_players_are_correct()
        {
            var user = new User("Tatiane", "password", User.UserProfile.CBF);
            var teams = GetMockTeams(8, user);

            var soccer = new Championship(teams, user);

            Assert.NotEmpty(soccer.Teams);
        }
    }
}