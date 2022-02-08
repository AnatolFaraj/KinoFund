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
        public long CategoryId { get; set; }
        public string Picture { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Country { get; set; }
        public string PEGI { get; set; }

        public int Rating { get; set; }


    }

    public static class MovieInfoDtoExtensionMethods
    {

        
        public static MovieInfoDTO ToInfoDto(this MovieModel movieModel, int rating)
        {

            


            return new MovieInfoDTO
            {
                MovieId = movieModel.MovieId,
                Title = movieModel.Title,
                Description = movieModel.MovieDetail.Description,
                CategoryId = movieModel.Category.CategoryId,
                Picture = movieModel.MovieDetail.Picture,
                ReleaseDate = movieModel.MovieDetail.ReleaseDate,
                Country = movieModel.MovieDetail.Country,
                PEGI = movieModel.MovieDetail.PEGI,

                Rating = rating



            };
        }
    }
}
