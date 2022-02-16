
using Core.Dtos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _autService;
        private readonly JWTTokenService _jwtService;

        public AuthenticationController(AuthenticationService authManager, JWTTokenService jwtService)
        {
            _autService = authManager;
            _jwtService = jwtService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            var loginDTO = await _autService.LoginAsync(email, password);
            var tokenDTO = _jwtService.GenerateJWTToken(loginDTO);

            return Ok(tokenDTO);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync(RegistrationDTO registrationDTO)
        {
            var newUserId = await _autService.RegisterAsync(registrationDTO);
            return Ok(newUserId);
        }

        [Authorize]
        [HttpPut("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            var userId = Convert.ToInt64(HttpContext.User.FindFirstValue("id"));
            await _autService.LogoutAsync(userId);
            return NoContent();
        }
    }
}
