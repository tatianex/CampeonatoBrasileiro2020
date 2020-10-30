using Domain.Users;

namespace WebAPI.Controllers.Users
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserProfile Profile{ get; set; }
    }
}