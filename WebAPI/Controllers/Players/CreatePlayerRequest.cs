using System;

namespace WebAPI.Controllers.Players
{
    public class CreatePlayerRequest
    {
        public string Name { get; set; }
        public Guid TeamId { get; set; }
    }
}