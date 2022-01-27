using Core.Dtos.Movies;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Movies
{
    public class MoviesManager
    {
        private readonly MyContext _dbContext;

        public MoviesManager(MyContext context)
        {
            _dbContext = context;
        }

        public async Task<GetAllMoviesDTO> GetAllMoviesAsync()
        {
            var movies = await _dbContext.Movies
                .Include(i => i.MovieDetail)
                .Select(m => new MovieDTO
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Description = m.MovieDetail.Description,

                }).OrderBy(t => t.Title).ToListAsync();

            return new GetAllMoviesDTO
            {
                Movies = movies,
            };
        }

        public async Task<MovieInfoDTO> GetMovieInfoAsync(long movieId)
        {
            var movieModel = await _dbContext.Movies
                .Include(i => i.Category)
                .Include(i => i.MovieDetail)
                .Include(i => i.Ratings)
                .FirstAsync(m => m.MovieId == movieId);

            return movieModel.ToDto();
        }
    }
}
