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

            // return BadRequest("O nome está inválido");

            var userId = _usersService.CreateUser(request.Name, request.Profile);
            return Ok(userId);
        }

        /* [HttpGet]
        public IReadOnlyCollection<Users> Get()
        {
            return Users;
        } */
    }
}