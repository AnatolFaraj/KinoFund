﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MovieDetail
    {

        public long MovieId { get; set; }
        public  Movie Movie { get; set; }

        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        

        public string Country { get; set; }
        public string PEGI { get; set; }

    }
}
