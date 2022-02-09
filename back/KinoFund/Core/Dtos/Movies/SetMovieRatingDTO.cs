using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Movies
{
    public class SetMovieRatingDTO
    {
        public long MovieId { get; set; }
        public long UserId { get; set; }
        public int Value { get; set; }
    }
}
