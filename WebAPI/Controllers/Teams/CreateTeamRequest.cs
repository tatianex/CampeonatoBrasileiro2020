using System.Collections.Generic;

namespace WebAPI.Controllers.Players
{
    public class CreateTeamRequest
    {
        public string Name { get; set; }
        public IList<string> Players { get; set; }
    }
}