using Microsoft.AspNetCore.Mvc;
using Domain.Users;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {        
        [HttpPost]
        public UserProfile Post(CreateUserRequest request)
        {
            var user = new User(request.Name, request.Password, request.Profile);
            return user.Profile;
        }
    }
}
