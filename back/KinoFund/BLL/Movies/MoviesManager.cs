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

        public async Task<MovieInfoDTO> EditMovieAsync(long movieId, MovieInfoDTO movieDTO)
        {
            var existingMovie = _dbContext.Movies
                .Where(m => m.MovieId == movieId)
                .Include(i => i.MovieDetail)
                .Include(i => i.Category)
                .FirstOrDefault();

            if(existingMovie != null)
            {
                
                existingMovie.Title = movieDTO.Title;
                existingMovie.MovieDetail.Description = movieDTO.Description;
                existingMovie.Category.CategoryId = movieDTO.Category;
                existingMovie.MovieDetail.Picture = movieDTO.Picture;
                existingMovie.MovieDetail.ReleaseDate = movieDTO.ReleaseDate;
                existingMovie.MovieDetail.Country = movieDTO.Country;
                existingMovie.MovieDetail.PEGI = movieDTO.PEGI;

                await _dbContext.SaveChangesAsync();
            }
            

            return movieDTO;
            
        }

        public async Task<MovieInfoDTO> CreateMovieAsync(MovieInfoDTO movieDTO)
        {

            _dbContext.Movies.Add(new Core.Models.MovieModel()
            { 
               
                Title = movieDTO.Title,
                MovieDetail = new Core.Models.MovieDetailModel()
                {
                    Description = movieDTO.Description,
                    Picture = movieDTO.Picture,
                    ReleaseDate = movieDTO.ReleaseDate,
                    Country = movieDTO.Country,
                    PEGI = movieDTO.PEGI
                    
                },
                CategoryId = movieDTO.Category
                

            });

            await _dbContext.SaveChangesAsync();
            return movieDTO;
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
