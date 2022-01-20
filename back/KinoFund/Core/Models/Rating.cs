using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Rating
    {
        
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public int Value { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }


    }
}
