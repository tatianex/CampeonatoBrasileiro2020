using System;

namespace WebAPI.Controllers.Auth
{
    public class LoginRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}