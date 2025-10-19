using Microsoft.AspNetCore.Mvc;
using Services.Auth;

namespace GadgetHubAPI.Controllers
{
    // create records to pass data 
    // Since JSON deseralization requires concreate class to implement using records can be much easier.
    public record AuthDTO(string Username, string Password);
    public record RegisterDTO(string Username, string Password, string Role);


    [ApiController]
    [Route("v1/api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // Login Endpoint
        [HttpPost("auth")]
        public async Task<IActionResult> Authentication([FromBody] AuthDTO authDTO)
        {
            try
            {
                var token = await _authService.LoginServiceAsync(authDTO.Username, authDTO.Password);
                if (token == null)
                    return Unauthorized(new { message = "Invalid credentials" });

                return Ok(new { token });
            }
            catch (Exception error)
            {

                return BadRequest(error.ToString());
            }
        }

        // Register User Endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                var user = await _authService.ResgisterUserServiceAsync(registerDTO.Username, registerDTO.Password, registerDTO.Role);
                return Ok(new { user.Username, user.Role });
            }
            catch (Exception error)
            {

                return BadRequest(error.ToString());
            }
        }


    }
}
