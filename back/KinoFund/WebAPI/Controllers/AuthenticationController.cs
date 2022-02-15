
using Core.Dtos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _autManager;
        private readonly JWTTokenService _jwtService;

        public AuthenticationController(AuthenticationService authManager, JWTTokenService jwtService)
        {
            _autManager = authManager;
            _jwtService = jwtService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            var loginDTO = await _autManager.LoginAsync(email, password);
            var tokenDTO = _jwtService.GenerateJWTToken(loginDTO);

            return Ok(tokenDTO);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync(RegistrationDTO registrationDTO)
        {
            var newUserId = await _autManager.RegisterAsync(registrationDTO);
            return Ok(newUserId);
        }

        //[Authorize]
        //[HttpDelete("logout")]
        //public async Task<IActionResult> LogoutAsync()
        //{
            
        //    throw new NotImplementedException();
        //}
    }
}
