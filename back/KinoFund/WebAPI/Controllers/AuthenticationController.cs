using BLL.Authentification;
using Core.Dtos.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationManager _autManager;

        public AuthenticationController(AuthenticationManager authManager)
        {
            _autManager = authManager;
        }

        [HttpGet("login")]
        public async Task<LoginDTO> LoginAsync(string password, string email)
        {
            var loginDto = await _autManager.LoginAsync(password, email);
            return loginDto;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterAsync(RegistrationDTO registrationDTO)
        {
            var newUserId = await _autManager.RegisterAsync(registrationDTO);
            return Ok(newUserId);
        }
    }
}
