using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Movies
{
    public class MovieDTO
    {
        public long MovieId { get; set; }
        public string Title { get; set; }

        public string CategoryName { get; set; }

    }
}
