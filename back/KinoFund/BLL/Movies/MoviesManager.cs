using Core.Dtos.Movies;
using Core.Interfaces;
using Core.Models;
using DAL.data;
using DAL.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        private readonly IRatingRepository _ratingRepo;

        public MoviesManager(MyContext context, IRatingRepository ratingRepository)
        {
            _dbContext = context;
            _ratingRepo = ratingRepository;

        }
        
        public async Task<GetAllMoviesDTO> GetAllAsync()
        {

            var movies = await _dbContext.Movies
                .Include(i => i.Category)
                .ToListAsync();

            var movieDtos = new List<MovieDTO>();

            foreach (var movie in movies)
            {
                var rating = _ratingRepo.GetValueByMovieId(movie.MovieId);
                movieDtos.Add(movie.ToDto(rating));
            }

            return new GetAllMoviesDTO
            {
                Movies = movieDtos,
            };
        }

        public async Task<MovieInfoDTO> GetInfoAsync(long movieId)
        {
            var movieModel = await _dbContext.Movies
                .Include(i => i.Category)
                .Include(i => i.MovieDetail)
                .FirstAsync(m => m.MovieId == movieId);

            var rating = _ratingRepo.GetValueByMovieId(movieId);

            return movieModel.ToInfoDto(rating);
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
            var movieDetailModel = new MovieDetailModel()
            {
                Description = movieDTO.Description,
                Picture = movieDTO.Picture,
                ReleaseDate = movieDTO.ReleaseDate,
                Country = movieDTO.Country,
                PEGI = movieDTO.PEGI
            };

            var movieModel = new MovieModel()
            {
                Title = movieDTO.Title,
                MovieDetail = movieDetailModel,
                CategoryId = movieDTO.CategoryId
                
            };

            _dbContext.MovieDetails.Add(movieDetailModel);
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
