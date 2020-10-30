using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Users;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {        
        [HttPost]
        public Guid Post(CreateUserRequest request)
        {
            var user = new User(request.Name, "password", User.UserProfile.CBF);
            return user.Id;
        }
    }
}
