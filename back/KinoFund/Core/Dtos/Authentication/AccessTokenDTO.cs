using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Authentication
{
    public class AccessTokenDTO
    {
        public long UserId { get; set; }
        public string Token { get; set; }
    }
}
