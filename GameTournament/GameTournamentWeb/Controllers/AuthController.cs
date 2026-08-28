using GameTournamentApplication.Services.AuthServices;
using GameTournamentApplication.Services.AuthServices.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameTournamentWeb.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterRequest request)
            {
                var result = await _authService.RegisterUserAsync(request);

                if (!result.IsSuccess)
                {
                    return BadRequest(result.Errors);
                }

                return Ok();
            }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.AuthenticateUserAsync(
                request.UserName,
                request.Password);

            if (!result.IsSuccess)
            {
                return Unauthorized(result.Errors);
            }

            return Ok();
        }
    }
}
