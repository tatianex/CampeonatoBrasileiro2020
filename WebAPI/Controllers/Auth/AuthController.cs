using Microsoft.AspNetCore.Mvc;
using Domain.Authentication;

namespace WebAPI.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        
        public AuthController()
        {
            _authService = new AuthService();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {   
            var response = _authService.Login(request.Email, request.Password);

            if (!response.IsValid)
            {
                return BadRequest("Email ou senha inválido");
            }
            
            return Ok(response.UserId);
        }
    }
}