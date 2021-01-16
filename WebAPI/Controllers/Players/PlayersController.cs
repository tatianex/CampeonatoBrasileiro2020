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
        public readonly PlayersService _playersService;
        public readonly IUsersService _usersService;

        public PlayersController(IUsersService usersService)
        {
            _usersService = usersService;
            _playersService = new PlayersService();
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Create(CreatePlayerRequest request)
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

            var response = _playersService.Create(request.TeamId, request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
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

            if (user.Profile != UserProfile.CBF)
            {
                return Unauthorized();
            }

            var playerRemoved = _playersService.Remove(id);

            if (playerRemoved == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}