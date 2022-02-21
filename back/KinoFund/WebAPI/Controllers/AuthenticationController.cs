
using Core.Dtos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Infrastructure;


namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly AuthenticationService _autService;
        private readonly JWTTokenService _jwtService;
        private readonly UserClaims _userClaims;

        public AuthenticationController(AuthenticationService authManager, JWTTokenService jwtService, UserClaims userClaims)
        {
            _autService = authManager;
            _jwtService = jwtService;
            _userClaims = userClaims;

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
        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync()
        {

            await _autService.LogoutAsync(_userClaims.Id);
            return Ok();
        }

    }
}
