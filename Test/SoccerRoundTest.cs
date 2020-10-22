using System;
using System.Collections.Generic;
using Domain;
using Xunit;

namespace Test
{
    public class SoccerRoundTest
    {
        [Fact]
        public void should_do_something()
        {
            var teams = new List<Team>{
                new Team(Guid.NewGuid(), "Flamengo"),
                new Team(Guid.NewGuid(), "Fluminense"),
                new Team(Guid.NewGuid(), "Vasco"),
                new Team(Guid.NewGuid(), "Palmeiras")
            };

            var user = new User("Silvano", "password", User.UserProfile.CBF);
            
            var soccer = new SoccerRound(0, teams, user);
        }
    }
}