using Domain.Users;
namespace WebAPI.Controllers.Players
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserProfile Profile{ get; set; }
    }
}