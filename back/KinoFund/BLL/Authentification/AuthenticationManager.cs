using Core.Dtos.Authentication;
using Core.Interfaces;
using Core.Models;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Authentification
{
    public class AuthenticationManager
    {
        private readonly MyContext _dbContext;
        private readonly IJWTTokenRepository _jwtRepo;
        public AuthenticationManager(MyContext context, IJWTTokenRepository jwtRepo)
        {
            _dbContext = context;
            _jwtRepo = jwtRepo;
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

            var token = _jwtRepo.GenerateJWTToken(userModel);

            return userModel.ToLoginDto(token);
        }
        //public async Task LogoutAsync(LoginDTO loginDTO)
        //{
            
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
