﻿using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Teams;
using Microsoft.Extensions.Primitives;
using System;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        public readonly TeamsService _teamsService;
        public readonly IUsersService _usersService;
        public TeamsController(IUsersService usersService, TeamsService teamsService)
        {
            _usersService = usersService;
            _teamsService = teamsService;
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreateTeamRequest request)
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
            
            var response = _teamsService.Create(request.Name, request.Players);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
           
            return Ok(response.Id);
        }


    }
}