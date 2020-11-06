using Xunit;
using Domain.Users;

namespace Test
{
    public class UserTest
    {
        [Fact]
        public void should_contain_same_parameters_provided()
        {
            var name = "Rogério Caboclo";
            var profile = UserProfile.CBF;
            
            var user = new User(name, profile);

            Assert.Equal(name, user.Name);
            Assert.Equal(profile, user.Profile);
        }
    }    
}
