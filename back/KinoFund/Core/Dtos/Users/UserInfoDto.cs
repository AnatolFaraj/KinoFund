using Core.Enums;
using Core.Models;
using System;

namespace Core.Dtos.Users
{
    public class UserInfoDto
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType Role { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int CommentsCount { get; set; }
    }

    public static class UserInfoDtoExtensionMethods
    {
        public static UserInfoDto ToDto(this UserModel userModel)
        {
            return new UserInfoDto
            {
                UserId = userModel.UserId,
                Name = userModel.UserName,
                Role = userModel.Type,
                DateOfBirth = userModel.DateOfBirth,
                Email = userModel.Credential.Email,
                CommentsCount = userModel.Comments.Count
            };
        }
    }
}
