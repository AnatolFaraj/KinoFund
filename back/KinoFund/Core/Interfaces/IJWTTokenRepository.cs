using Core.Dtos.Authentication;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IJWTTokenRepository
    {
        public AccessTokenDTO GenerateJWTToken(UserModel userModel);
        public Task DeleteToken(long userId);
    }
}
