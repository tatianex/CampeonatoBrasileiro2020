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
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Post(CreateUserRequest request)
        {
            if(request.Profile == UserProfile.CBF && request.Password != "admin123")
            {
                return Unauthorized();
            }
            var user = new User(request.Name, request.Profile);
            return Ok(user.Id);
        }
    }
}
