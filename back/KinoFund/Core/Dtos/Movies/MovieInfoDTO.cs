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

        public string Title { get; set; }
        public string Description { get; set; }
        public long Category { get; set; }
        public string Picture { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Country { get; set; }
        public string PEGI { get; set; }


    }

    public static class MovieInfoDtoExtensionMethods
    {
        public static MovieInfoDTO ToDto(this MovieModel movieModel)
        {
            return new MovieInfoDTO
            {
                
                Title = movieModel.Title,
                Description = movieModel.MovieDetail.Description,
                Category = movieModel.Category.CategoryId,
                Picture = movieModel.MovieDetail.Picture,
                ReleaseDate = movieModel.MovieDetail.ReleaseDate,
                Country = movieModel.MovieDetail.Country,
                PEGI = movieModel.MovieDetail.PEGI,

            };
        }
    }
}
