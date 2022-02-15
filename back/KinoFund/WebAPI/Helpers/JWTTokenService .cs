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

namespace WebAPI.Helpers
{
    public class JWTTokenService 
    {
        

        private readonly JWTSettings _jwtSettings;
        public JWTTokenService(IOptions<JWTSettings> jwtSettings)
        {

            _jwtSettings = jwtSettings.Value;
        }


        public AccessTokenDTO GenerateJWTToken(LoginDTO loginDTO)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", loginDTO.UserId.ToString()),
                    new Claim(ClaimTypes.Email, loginDTO.Email),
                    new Claim(ClaimTypes.Role, Convert.ToInt32(loginDTO.Role).ToString()),
                    new Claim(ClaimTypes.Name, loginDTO.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
                

            };
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(createdToken);



            return new AccessTokenDTO
            {
                Token = generatedToken
            };
        }
    }
}
