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

        [Fact]
        public void Should_not_generate_same_id_for_both_users()
        {
            var userCbf = new User("João Fernandes", UserProfile.CBF);
            var userFan = new User("Carlos Augusto", UserProfile.Fan);
            
            Assert.NotEqual(userCbf.Id, userFan.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1234")]
        [InlineData(" Rafael")]
        [InlineData("Rafael ")]
        [InlineData("Rafael  ")]
        [InlineData("Rafael I")]
        [InlineData("Rafael 0")]
        [InlineData("Rafael --")]
        [InlineData("R4fael Rodrigues")]
        [InlineData("Rafael Rodrigues Fernande$")]
        [InlineData("Raf@el Rodrigues")]
        public void Should_return_false_when_name_is_invalid(string name)
        {
            // Dado / Setup
            var profile = UserProfile.Fan;
            var user = new User(name, profile);

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }
    }    
}
