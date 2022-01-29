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
                .Include(i => i.Category)
                .Select(m => new MovieDTO
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    Description = m.MovieDetail.Description,
                    Category = m.Category.CategoryId

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
                .FirstAsync(m => m.MovieId == movieId);

            return movieModel.ToDto();
        }

        public async Task<MovieInfoDTO> EditMovieAsync(long movieId, MovieInfoDTO movieModel)
        {
            var existingMovie = _dbContext.Movies
                .Where(m => m.MovieId == movieId)
                .Include(i => i.MovieDetail)
                .Include(i => i.Category)
                .FirstOrDefault();

            if(existingMovie != null)
            {
                
                existingMovie.Title = movieModel.Title;
                existingMovie.MovieDetail.Description = movieModel.Description;
                existingMovie.Category.CategoryId = movieModel.Category;
                existingMovie.MovieDetail.Picture = movieModel.Picture;
                existingMovie.MovieDetail.ReleaseDate = movieModel.ReleaseDate;
                existingMovie.MovieDetail.Country = movieModel.Country;
                existingMovie.MovieDetail.PEGI = movieModel.PEGI;

                await _dbContext.SaveChangesAsync();
            }
            

            return movieModel;
            
        }

        public async Task<MovieInfoDTO> CreateMovieAsync(MovieInfoDTO movieModel)
        {

            _dbContext.Movies.Add(new Core.Models.Movie()
            { 
                MovieId = movieModel.MovieId,
                Title = movieModel.Title,
                MovieDetail = new Core.Models.MovieDetail()
                {
                    Description = movieModel.Description,
                    Picture = movieModel.Picture,
                    ReleaseDate = movieModel.ReleaseDate,
                    Country = movieModel.Country,
                    PEGI = movieModel.PEGI
                    
                },
                CategoryId = movieModel.Category
                

            });

            await _dbContext.SaveChangesAsync();
            return movieModel;
        }


        public async Task DeleteMovieAsync(long movieId)
        {
            var movie = _dbContext.Movies
                .Where(m => m.MovieId == movieId)
                .Include(i => i.MovieDetail)
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
