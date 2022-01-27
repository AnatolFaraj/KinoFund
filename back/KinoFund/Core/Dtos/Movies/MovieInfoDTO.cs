using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Movies
{
    public class MovieInfoDTO
    {
        public long MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Picture { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Country { get; set; }
        public string PEGI { get; set; }
        public int Rating { get; set; }

    }

    public static class MovieInfoDtoExtensionMethods
    {
        public static MovieInfoDTO ToDto(this Movie movieModel)
        {
            return new MovieInfoDTO
            {
                MovieId = movieModel.MovieId,
                Title = movieModel.Title,
                Description = movieModel.MovieDetail.Description,
                Category = movieModel.Category.Name,
                Picture = movieModel.MovieDetail.Picture,
                ReleaseDate = movieModel.MovieDetail.ReleaseDate,
                Country = movieModel.MovieDetail.Country,
                PEGI = movieModel.MovieDetail.PEGI,
                Rating = (int)movieModel.Ratings.Select(r => r.Value).Average()
            };
        }
    }
}
