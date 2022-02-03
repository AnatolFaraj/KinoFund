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

        public async Task<GetAllMoviesDTO> GetAllAsync()
        {
            var movies = await _dbContext.Movies
                .Include(i => i.MovieDetail)
                .Include(i => i.Category)
                .Select(m => new MovieDTO
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    CategoryName = m.Category.Name

                }).OrderBy(t => t.Title).ToListAsync();
            
            return new GetAllMoviesDTO
            {
                Movies = movies,
            };
        }

        public async Task<MovieInfoDTO> GetInfoAsync(long movieId)
        {
            var movieModel = await _dbContext.Movies
                .Include(i => i.Category)
                .Include(i => i.MovieDetail)
                .FirstAsync(m => m.MovieId == movieId);

            return movieModel.ToDto();
        }

        public async Task<bool> EditAsync(MovieInfoDTO movieDTO)
        {
            var movieModel = await _dbContext.Movies
                .Where(m => m.MovieId == movieDTO.MovieId)
                .Include(i => i.MovieDetail)
                .Include(i => i.Category)
                .FirstOrDefaultAsync();

            if(movieModel != null)
            {

                movieModel.Title = movieDTO.Title;
                movieModel.MovieDetail.Description = movieDTO.Description;
                movieModel.CategoryId = movieDTO.CategoryId;
                movieModel.MovieDetail.Picture = movieDTO.Picture;
                movieModel.MovieDetail.ReleaseDate = movieDTO.ReleaseDate;
                movieModel.MovieDetail.Country = movieDTO.Country;
                movieModel.MovieDetail.PEGI = movieDTO.PEGI;

                await _dbContext.SaveChangesAsync();
            }
            

            return true;
            
        }

        public async Task<long> CreateAsync(MovieInfoDTO movieDTO)
        {
            var movieModel = new Core.Models.MovieModel()
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
                CategoryId = movieDTO.CategoryId
                
            };

            _dbContext.Movies.Add(movieModel);

            await _dbContext.SaveChangesAsync();

            return movieModel.MovieId;
        }


        public async Task<bool> DeleteAsync(long movieId)
        {
            var movie = await _dbContext.Movies
                .Where(m => m.MovieId == movieId)
                .Include(i => i.MovieDetail)
                .FirstOrDefaultAsync();

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

        
    }
}
