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
        public string GenerateJWTToken(UserModel userModel);
    }
}
