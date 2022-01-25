using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Rating
    {
        
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public int Value { get; set; }

        public  Movie Movie { get; set; }
        public  User User { get; set; }


    }
}
