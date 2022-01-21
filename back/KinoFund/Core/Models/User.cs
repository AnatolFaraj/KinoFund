using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; } 
        
        public DateTime? DateOfBirth { get; set; }
        public UserType Type { get; set; }

        public  ICollection<Comment> Comments { get; set; }
        public  ICollection<Collection> Collections { get; set; }

        public  ICollection<Rating> Ratings { get; set; }

    }
}
