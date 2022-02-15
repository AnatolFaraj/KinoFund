﻿using Core.Dtos.Authentication;
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
                .Where(x => x.Credential.Email == email && x.Credential.Password == password)
                .SingleAsync();

            if (userModel != null)
            {
                userModel.Credential.LastLoginDate = DateTime.UtcNow;
                await _dbContext.SaveChangesAsync();
            }

            var loginDTO = userModel.ToLoginDto();
            
  
            return loginDTO;
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