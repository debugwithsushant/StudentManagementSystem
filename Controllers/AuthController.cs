using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Auth;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtHelper _jwtHelper;

        public AuthController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Hardcoded credentials for demo
            if (request.Username == "admin" && request.Password == "admin123")
            {
                var token = _jwtHelper.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized("Invalid credentials...!");
        }
    }

    // Login request model
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
