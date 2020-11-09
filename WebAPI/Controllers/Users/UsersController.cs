using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System.Collections.Generic;
using System;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly UsersService _usersService;
        public UsersController()
        {
            _usersService = new UsersService();
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Post(CreateUserRequest request)
        {
            if(request.Profile == UserProfile.CBF && request.Password != "admin123")
            {
                return Unauthorized();
            }

            var response = _usersService.Create(request.Name, request.Profile);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
           
            return Ok(response.Id);
        }


        //Não é necessário para user
        /* [HttpGet]
        public IReadOnlyCollection<Users> Get()
        {
            return Users;
        } */
    }
}