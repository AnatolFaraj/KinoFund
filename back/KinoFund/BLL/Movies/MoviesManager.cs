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

        public async Task<MovieDTO> EditMovieAsync(long movieId, MovieDTO movieModel)
        {
            var existingMovie = _dbContext.Movies
                .Where(m => m.MovieId == movieModel.MovieId)
                .FirstOrDefault();

            if(existingMovie != null)
            {
                
                existingMovie.Title = movieModel.Title;
                existingMovie.MovieDetail.Description = movieModel.Description;

                await _dbContext.SaveChangesAsync();
            }
            

            return movieModel;
            
        }

        public async Task<MovieDTO> CreateMovieAsync(MovieDTO movieModel)
        {

            _dbContext.Movies.Add(new Core.Models.Movie()
            { 
                MovieId = movieModel.MovieId,
                Title = movieModel.Title,
                
                
                
                //todo: add description somehow
                
            });

            await _dbContext.SaveChangesAsync();
            return movieModel;
        }


        public async Task DeleteMovieAsync(long movieId)
        {
            var movie = _dbContext.Movies
                .Where(m => m.MovieId == movieId)
                .FirstOrDefault();

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        

        public async Task<MovieDTO> GetMovieAsync(long movieId)
        {
            var movie = await _dbContext.Movies.FindAsync(movieId);
            
            return new MovieDTO
            { 
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.MovieDetail.Description
            };
        }
    }
}
