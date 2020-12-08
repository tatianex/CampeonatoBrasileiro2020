using System;

namespace WebAPI.Controllers.Players
{
    public class CreatePlayerRequest
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; }
    }
}