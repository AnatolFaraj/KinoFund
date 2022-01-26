using Core.Dtos.Users;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Users
{
    public class UsersManager
    {
        private readonly MyContext _dbContext;

        public UsersManager(MyContext context)
        {
            _dbContext = context;
        }

        public async Task<GetAllUsersDto> GetAllUsersAsync()
        {
            var users = await _dbContext.Users
                .Include(i => i.Credential)
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    Name = u.UserName,
                    Role = u.Type,
                    LastLoginDate = u.Credential.LastLoginDate,
                })
                .ToListAsync();

            return new GetAllUsersDto
            {
                Users = users,
            };
        }

        public async Task<UserInfoDto> GetUserInfoAsync(long userId)
        {
            var userModel = await _dbContext.Users
                .Include(i => i.Credential)
                .Include(i => i.Comments)
                .FirstAsync(u => u.UserId == userId);

            return userModel.ToDto();
        }
    }
}
