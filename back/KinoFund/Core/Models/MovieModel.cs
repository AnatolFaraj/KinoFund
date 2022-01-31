using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MovieModel
    {
        public long MovieId { get; set; } 
        public string Title { get; set; }
        public long  CategoryId { get; set; }
        public  CategoryModel Category { get; set; }

        public  MovieDetailModel MovieDetail { get; set; }

        public  ICollection<CommentModel> Comments { get; set; }
        public  ICollection<CollectionModel> Collections { get; set; }

        public  ICollection<RatingModel> Ratings { get; set; }



    }
}
