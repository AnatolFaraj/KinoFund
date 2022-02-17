using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure
{
    public class UserClaims
    {
        public long Id { get; set; } 

        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }

        public UserClaims(IHttpContextAccessor contextAccessor)
        {
            Id = Convert.ToInt64(contextAccessor.HttpContext.User.FindFirstValue("id"));
            Role = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            Name = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            Email = contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }
        
    }
}
