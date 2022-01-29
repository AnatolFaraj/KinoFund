using BLL.Movies;
using Core.Dtos.Movies;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet("")]
        public async Task<GetAllMoviesDTO> GetAllMoviesAsync()
        {
            var users = await _moviesManager.GetAllMoviesAsync();
            return users;
        }


        [HttpGet("{movieId}/info")]
        public async Task<MovieInfoDTO> GetMovieInfoAsync(long movieId)
        {
            var movie = await _moviesManager.GetMovieInfoAsync(movieId);
            return movie;
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> EditMovieAsync(long movieId, MovieDTO movieModel)
        {
            await _moviesManager.EditMovieAsync(movieId, movieModel);
            return Ok(movieModel);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateMovieAsync(MovieDTO movieModel)
        {
             await _moviesManager.CreateMovieAsync(movieModel);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteMovieAsync(long movieId)
        {
            await _moviesManager.DeleteMovieAsync(movieId);
            return Ok();
        }

    }
}
