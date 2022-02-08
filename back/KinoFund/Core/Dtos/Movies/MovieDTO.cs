using Core.Models;
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

        public float Rating { get; set; }


    }

    public static class MovieDtoExtensionMethods
    {
        public static MovieDTO ToDto(this MovieModel movieModel, float rating)
        {
            return new MovieDTO
            {
                MovieId = movieModel.MovieId,
                Title = movieModel.Title,
                CategoryName = movieModel.Category.Name,
                Rating = rating
            };
        }
    }
}
