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
        private readonly JWTTokenService _jwtService;
        public AuthenticationService(MyContext context, JWTTokenService jwtService)
        {
            _dbContext = context;
            _jwtService = jwtService;
        }

        public async Task<LoginDTO> LoginAsync(string password, string email)
        {
            var userModel = await _dbContext.Users
                .Include(i => i.Credential)
                .Include(i => i.Comments)
                .Where(x => x.Credential.Email == email && x.Credential.Password == password)
                .SingleAsync();

            if (userModel != null)
            {
                userModel.Credential.LastLoginDate = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }

            var tokenDTO = _jwtService.GenerateJWTToken(userModel);
  
            return userModel.ToLoginDto(tokenDTO.Token);
        }
        //public async Task<bool> LogoutAsync(long userId)
        //{
        //    await _jwtRepo.DeleteToken(userId);

        //    return true;
        //}

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
