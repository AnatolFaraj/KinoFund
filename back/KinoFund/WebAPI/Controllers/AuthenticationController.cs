
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

        public AuthenticationController(AuthenticationService authManager)
        {
            _autManager = authManager;
        }

        [HttpGet("login")]
        public async Task<IActionResult> LoginAsync(string password, string email)
        {
            var loginDto = await _autManager.LoginAsync(password, email);
            
            return Ok(loginDto);
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
