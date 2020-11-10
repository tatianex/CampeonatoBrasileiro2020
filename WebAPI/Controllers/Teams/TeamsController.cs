using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using Domain.Teams;
using System.Collections.Generic;

namespace WebAPI.Controllers.Players
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        public readonly TeamsService _teamService;
        public TeamsController()
        {
            _teamService = new TeamsService();
        }

        [HttpPost]
        //IActionResult é mais genérico e conseguimos retornar tanto o Unauthorized, quanto o Ok.
        public IActionResult Post(CreateTeamRequest request)
        {
            if(request.Profile != UserProfile.CBF || request.Password != "admin123")
            {
                return Unauthorized();
            }
            
            var response = _teamService.CreateTeam(request.Name);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
           
            return Ok(response.Id);
        }


    }
}