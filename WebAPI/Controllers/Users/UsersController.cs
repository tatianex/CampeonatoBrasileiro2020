﻿using System;
using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Microsoft.Extensions.Primitives;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreateUserRequest request)
        {
            StringValues userId;
            if(!Request.Headers.TryGetValue("UserId", out userId))
            {
                return Unauthorized();
            }

            var user = _usersService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return Unauthorized();
            }

            if (user.Profile == UserProfile.Fan)
            {
                return Unauthorized();
            }

            var response = _usersService.Create(
                request.Profile,
                request.Name,
                request.Email,                
                request.Password
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _usersService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }


    }
}