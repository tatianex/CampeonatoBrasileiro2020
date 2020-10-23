using System;
using Xunit;
using Domain;
using System.Collections.Generic;

namespace Test
{
    public class ChampionshipTest
    {
        [Fact]
        public void should_do_something()
        {
            var user = new User("Tatiane", "password", User.UserProfile.CBF);
            
            var teams = new List<Team> {
                new Team("Internacional"),
                new Team("Flamengo"),
                new Team("Atlético-MG"),
                new Team("São Paulo"),
                new Team("Santos"),
                new Team("Fluminense"),
                new Team("Fortaleza"),
                new Team("Palmeiras"),
                new Team("Atlético-GO"),
                new Team("Grêmio"),
                new Team("Sport"),
                new Team("Bahia"),
            };

            var soccer = new Championship(teams, user);
            soccer.CreateRounds(user);
        }
    }
}