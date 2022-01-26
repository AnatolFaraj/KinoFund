using Core.Enums;
using System;

namespace Core.Dtos.Users
{
    public class UserDto
    { 
        public long UserId { get; set; }
        public string Name { get; set; }
        public UserType Role { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
