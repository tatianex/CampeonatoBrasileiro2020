using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Players;
using System.Collections.Generic;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        public readonly PlayersService _playerService;
        public PlayersController()
        {
            _playerService = new PlayersService();
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Post(CreatePlayerRequest request)
        {
            if(request.Profile != UserProfile.CBF || request.Password != "admin123")
            {
                return Unauthorized();
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