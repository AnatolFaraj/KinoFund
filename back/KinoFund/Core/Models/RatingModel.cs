using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RatingModel
    {
        
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public int Value { get; set; }

        public  MovieModel Movie { get; set; }
        public  UserModel User { get; set; }


    }
}
