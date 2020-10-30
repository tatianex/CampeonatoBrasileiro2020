using Xunit;
using Domain;
using System.Collections.Generic;
using System.Linq;
using Domain.Users;

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
            var user = new User("Tatiane", "password", UserProfile.CBF);
            var teams = GetMockTeams(8, user);

            var soccer = new Championship(teams, user);

            Assert.NotEmpty(soccer.Teams);
        }

         [Fact]
        public void should_return_true_when_launched_results_are_correct()
        {
            // Cria o usuário CBF
            var user = new User("Tatiane", "password", UserProfile.CBF);

            // Cria os times que participarão do campeonato
            List<Team> teams = GetMockTeams(8, user);

            // Cria a lista de goleadores
            var scorers = new List<Player>();

            // Cria as rodadas do campeonato
            var soccer = new Championship(teams, user);
            soccer.CreateRounds(user);

            // Resultados dos jogos da rodada 
            var results = new List<Game>();
            results = soccer.Games.Where(x => x.Round == 1).ToList();

            // Jogo 1 da rodada
            Game jogo1 = results[0];  // Referência ao jogo 0 de results
            
            jogo1.Team1Goals = 3;
            scorers.Add(new Player("Fernando", jogo1.Team1, 2, user));
            scorers.Add(new Player("Daniel", jogo1.Team1, 1, user));

            jogo1.Team2Goals = 2;
            scorers.Add(new Player("Diego", jogo1.Team2, 1, user));
            scorers.Add(new Player("Marcos", jogo1.Team2, 1, user));

            // jogo 2
            Game jogo2 = results[1]; // Referência ao jogo 1 de results

            jogo2.Team1Goals = 1;
            scorers.Add(new Player("Gabriel", jogo2.Team1, 1, user));

            jogo2.Team2Goals = 0;

            // jogo 3
            Game jogo3 = results[2]; // Referência ao jogo 2 de results

            jogo3.Team1Goals = 2;
            scorers.Add(new Player("Rodolfo", jogo3.Team1, 1, user));
            scorers.Add(new Player("Yuri", jogo3.Team1, 1, user));

            jogo3.Team2Goals = 4;
            scorers.Add(new Player("Ramon", jogo3.Team2, 2, user));
            scorers.Add(new Player("Thiago", jogo3.Team2, 1, user));
            scorers.Add(new Player("Gustavo", jogo3.Team2, 1, user));

            // jogo 4
            Game jogo4 = results[3]; // Referência ao jogo 3 de results

            jogo4.Team1Goals = 0;
            jogo4.Team2Goals = 0;
          
            // Lança os resultados da rodada             
            var result = soccer.LaunchRoundResults(1, results, scorers, user);

            Assert.True(result);
        }       
    }
}