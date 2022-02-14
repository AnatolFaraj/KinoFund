using Core.Configuration;
using Core.Dtos.Authentication;
using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class JWTTokenRepository : IJWTTokenRepository
    {
        

        private readonly JWTSettings _jwtSettings;
        public JWTTokenRepository(IOptions<JWTSettings> jwtSettings)
        {

            _jwtSettings = jwtSettings.Value;
        }

        

        public Task DeleteToken(long userId)
        {
            throw new NotImplementedException();
        }

        public AccessTokenDTO GenerateJWTToken(UserModel userModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", userModel.UserId.ToString()),
                    new Claim(ClaimTypes.Email, userModel.Credential.Email),
                    new Claim(ClaimTypes.Role, Convert.ToInt32(userModel.Type).ToString()),
                    new Claim(ClaimTypes.Name, userModel.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                

            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var GeneratedToken = tokenHandler.WriteToken(createdToken);



            return new AccessTokenDTO
            {
                UserId = userModel.UserId,
                Token = GeneratedToken
            };
        }
    }
}
