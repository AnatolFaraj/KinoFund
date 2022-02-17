using BLL.Users;
using Core.Dtos.Users;
using Core.Dtos.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Authorize(Roles = AuthConsts.Admin)]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersManager _usersManager;

        public UsersController(UsersManager usersManager)
        {
            _usersManager = usersManager;
        }
       
        [HttpGet("")]
        public async Task<GetAllUsersDto> GetAllAsync()
        {
            var users = await _usersManager.GetAllAsync();
            return users;
        }

        
        [HttpGet("{userId}/info")]
        public async Task<UserInfoDto> GetInfoAsync(long userId)
        {
            var user = await _usersManager.GetInfoAsync(userId);
            return user;
        }

        
    }
}
