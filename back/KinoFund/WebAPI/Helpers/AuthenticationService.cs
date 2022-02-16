using Core.Dtos.Authentication;
using Core.Interfaces;
using Core.Models;
using DAL.data;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public class AuthenticationService
    {
        private readonly MyContext _dbContext;

        public AuthenticationService(MyContext context)
        {
            _dbContext = context;

        }

        public async Task<LoginDTO> LoginAsync(string email, string password)
        {
            var userModel = await _dbContext.Users
                .Include(i => i.Credential)
                .Where(x => x.Credential.Email == email)
                .SingleOrDefaultAsync();

            if (userModel == null)
            {
                throw new Exception("User with such an Email is not found.");
            }

            if(userModel.Credential.Password != password)
            {
                throw new Exception("Password is invalid.");
            }

            userModel.Credential.LastLoginDate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
            
            var loginDTO = userModel.ToLoginDto();
            
  
            return loginDTO;
        }
        public async Task<bool> LogoutAsync(long userId)
        {
            var userModel = await _dbContext.Users
                .Include(i => i.Credential)
                .Where(x => x.UserId == userId).SingleAsync();

            userModel.Credential.LastLogoutDate = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<long> RegisterAsync(RegistrationDTO registrationDTO)
        {
            var credentialModel = new CredentialModel()
            {
                Email = registrationDTO.Email,
                Password = registrationDTO.Password
            };

            var userModel = new UserModel()
            {
                UserName = registrationDTO.Name,
                DateOfBirth = registrationDTO.DateOfBirth,
                Type = registrationDTO.Role,
                Credential = credentialModel
            };

            _dbContext.Users.Add(userModel);
            _dbContext.Credentials.Add(credentialModel);

            await _dbContext.SaveChangesAsync();
            return userModel.UserId;

        }

        

    }
}
