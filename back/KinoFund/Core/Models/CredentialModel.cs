using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CredentialModel
    {

        public long UserId { get; set; }
        public UserModel User { get; set; }
        public long? ResetPasswordKey { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime? LastLoginDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }



    }
}
