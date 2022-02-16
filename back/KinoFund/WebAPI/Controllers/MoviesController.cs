using BLL.Movies;
using Core.Dtos.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesManager _moviesManager;

        public MoviesController(MoviesManager moviesManager)
        {
            _moviesManager = moviesManager;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<GetAllMoviesDTO> GetAllAsync(string filter)
        {
            var movieDTOs = await _moviesManager.GetAllAsync(filter);
            return movieDTOs;
        }

        [Authorize]
        [HttpGet("{movieId}/info")]
        public async Task<MovieInfoDTO> GetInfoAsync(long movieId)
        {
            var movie = await _moviesManager.GetInfoAsync(movieId);
            return movie;
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{movieId}")]
        public async Task<IActionResult> EditAsync(MovieInfoDTO movieModel)
        {
            await _moviesManager.EditAsync(movieModel);
            return Ok(movieModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(MovieInfoDTO movieModel)
        {
             var newMovieId = await _moviesManager.CreateAsync(movieModel);
            return Ok(newMovieId);
        }


        [Authorize]

        [HttpPost("{movieId}/score")]
        public async Task<IActionResult> SetScoreAsync(SetMovieRatingDTO movieRatingDTO)
        {
            var scoredMovieId = await _moviesManager.SetScoreAsync(movieRatingDTO);

            

            return Ok(scoredMovieId);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteAsync(long movieId)
        {
            await _moviesManager.DeleteAsync(movieId);
            return Ok();
        }

    }
}
