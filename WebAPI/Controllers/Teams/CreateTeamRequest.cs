using Domain.Users;
namespace WebAPI.Controllers.Players
{
    public class CreateTeamRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserProfile Profile{ get; set; }
    }
}