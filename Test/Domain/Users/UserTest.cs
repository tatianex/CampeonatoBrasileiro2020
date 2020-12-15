using Xunit;
using Domain.Users;

namespace Tests.Domain.Users
{
    public class UserTest
    {
        [Fact]
        public void should_contain_same_parameters_provided()
        {
            var name = "Rogério Caboclo";
            var password = "adm123";
            var email = "rogerio.caboclo@gmail.com";
            var profile = UserProfile.CBF;
            
            var user = new User(name, password, email, profile);

            Assert.Equal(name, user.Name);
            Assert.Equal(profile, user.Profile);
        }

        [Fact]
        public void Should_not_generate_same_id_for_both_users()
        {
            var userCbf = new User("João Fernandes", "adm123", "joao.fernandes@gmail.com", UserProfile.CBF);
            var userFan = new User("Carlos Augusto", "adm123", "carlos.augusto@gmail.com",  UserProfile.Fan);
            
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
            var  password = "adm123";
            var email = "rafael.rodrigues@gmail.com";
            var user = new User(name, password, email, profile);

            // When / Ação
            var isValid = user.Validate().isValid;
            
            // Deve / Asserções
            Assert.False(isValid);
        }

        [Theory]
        [InlineData("rodrigo")]
        [InlineData("rodrigo.vieira")]
        [InlineData("rodrigo.vieira@")]
        [InlineData("rodrigo.vieiracom")]
        [InlineData("rodrigo.vieira.com")]
        [InlineData("rodrigo.vieira@.com")]
        [InlineData("rodrigo.vieira@com")]
        public void Should_return_false_when_email_is_invalid(string email)
        {
            var user = new User("Rodrigo Vieira", "pass", email, UserProfile.CBF);

            var userIsValid = user.Validate().isValid;

            Assert.False(userIsValid);
        }

        [Theory]
        [InlineData("joao.silva@gmail.com")]
        [InlineData("tiago_delas@yahoo.com")]
        [InlineData("rodrigo.dourado@bol.com.br")]
        [InlineData("rodrigo789.dourado@bol.com.br")]
        public void Should_return_true_when_email_is_valid(string email)
        {
            var user = new User("João da Silva", "pass", email, UserProfile.CBF);

            var userIsValid = user.Validate().isValid;

            Assert.True(userIsValid);
        }
    }    
}
