using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {        
        [HttpPost]
        public Guid Post(CreateUserRequest request)
        {
            var user = new User(request.Name, request.Password, request.Profile);
            return user.Id;
        }
    }
}
