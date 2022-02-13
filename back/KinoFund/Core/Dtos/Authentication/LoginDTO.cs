using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Authentication
{
    public class LoginDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public UserType Role { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int CommentsCount { get; set; }

    }

    public static class UserLoginDtoExtensions
    {
        public static LoginDTO ToLoginDto(this UserModel userModel, string token)
        {
            return new LoginDTO
            {
                UserId = userModel.UserId,
                Name = userModel.UserName,
                Email = userModel.Credential.Email,
                Password = userModel.Credential.Password,
                Role = userModel.Type,
                DateOfBirth = userModel.DateOfBirth,
                Token = token,
                CommentsCount = userModel.Comments.Count
            };
        }
    }
}
