using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    
    public class UserModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; } 
        
        public DateTime? DateOfBirth { get; set; }
        public UserType Type { get; set; }

        public  ICollection<CommentModel> Comments { get; set; }
        public  ICollection<CollectionModel> Collections { get; set; }

        public  ICollection<RatingModel> Ratings { get; set; }
        public CredentialModel Credential { get; set; }

    }
}
