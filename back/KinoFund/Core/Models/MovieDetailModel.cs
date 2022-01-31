using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MovieDetailModel
    {
      
        public long MovieId { get; set; }
        public  MovieModel Movie { get; set; }

        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public string Picture { get; set; }
        public string Country { get; set; }
        public string PEGI { get; set; }

    }
}
