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
        public  Category Category { get; set; }

        public string Picture { get; set; }

        public  MovieDetail Detail { get; set; }

        public  ICollection<Comment> Comments { get; set; }
        public  ICollection<Collection> Collections { get; set; }

        public  ICollection<Rating> Ratings { get; set; }



    }
}
