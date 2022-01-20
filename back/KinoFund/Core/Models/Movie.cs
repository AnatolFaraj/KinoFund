using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Movie
    {
        public long MovieId { get; set; } 
        public string Title { get; set; }
        public long  CategoryId { get; set; }

        public string Picture { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }



    }
}
