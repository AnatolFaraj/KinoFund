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
        public async Task<GetAllMoviesDTO> GetAllAsync()
        {
            var users = await _moviesManager.GetAllAsync();
            return users;
        }


        [HttpGet("{movieId}/info")]
        public async Task<MovieInfoDTO> GetInfoAsync(long movieId)
        {
            var movie = await _moviesManager.GetInfoAsync(movieId);
            return movie;
        }

        [HttpPut("{movieId}")]
        public async Task<IActionResult> EditAsync(MovieInfoDTO movieModel)
        {
            await _moviesManager.EditAsync(movieModel);
            return Ok(movieModel);
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(MovieInfoDTO movieModel)
        {
             var newCommentId = await _moviesManager.CreateAsync(movieModel);
            return Ok(newCommentId);
        }

        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteAsync(long movieId)
        {
            await _moviesManager.DeleteAsync(movieId);
            return Ok();
        }

    }
}
