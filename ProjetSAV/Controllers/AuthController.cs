using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSAV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            Console.WriteLine($"Email: {request.Email}, Password: {request.Password}");
            if (request.Email == "nouissermehdi@gmail.com" && request.Password == "Mahdouch1")
            {
                return Ok(new { Token = "FakeJwtToken", Message = "Connexion réussie" });
            }

            return Unauthorized(new { Message = "Email ou mot de passe incorrect" });
        }
    }

        public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}