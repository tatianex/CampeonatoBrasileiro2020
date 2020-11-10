using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Players;
using Microsoft.Extensions.Primitives;
using System;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        public readonly PlayersService _playerService;
        public readonly UsersService _usersService;
        public PlayersController()
        {
            _playerService = new PlayersService();
            _usersService = new UsersService();
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Post(CreatePlayerRequest request)
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
                return Forbid();
            }

            var response = _playerService.CreatePlayer(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }


    }
}