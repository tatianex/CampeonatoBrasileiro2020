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
            var password = "459iMs@;3eZ!8*";
            var profile = UserProfile.CBF;
            
            var user = new User(name, password, profile);

            Assert.Equal(name, user.Name);
            Assert.Equal(password, user.Password);
            Assert.Equal(profile, user.Profile);
        }
    }    
}
