using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Credential
    {
        public long CredentialId { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long? ResetPasswordKey { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public DateTime? LastLoginDate { get; set; }



    }
}
