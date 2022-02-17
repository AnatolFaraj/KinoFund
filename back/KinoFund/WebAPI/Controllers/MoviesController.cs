using BLL.Movies;
using Core.Dtos.Authentication;
using Core.Dtos.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MoviesManager _moviesManager;
        private readonly UserClaims _userClaims; 
        public MoviesController(MoviesManager moviesManager, UserClaims userClaims)
        {
            _moviesManager = moviesManager;
            _userClaims = userClaims;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<GetAllMoviesDTO> GetAllAsync(string titleFilter, float? ratingFilter, string categoryFilter)
        {
            var movieDTOs = await _moviesManager.GetAllAsync(titleFilter, ratingFilter, categoryFilter);
            return movieDTOs;
        }

        [Authorize]
        [HttpGet("{movieId}/info")]
        public async Task<MovieInfoDTO> GetInfoAsync(long movieId)
        {
            var movie = await _moviesManager.GetInfoAsync(movieId);
            return movie;
        }

        [Authorize(Roles = AuthConsts.Admin)]
        [HttpPut("{movieId}")]
        public async Task<IActionResult> EditAsync(long movieId, MovieInfoDTO movieDTO)
        {
            await _moviesManager.EditAsync(movieDTO);
            return Ok(movieDTO);
        }

        [Authorize(Roles = AuthConsts.Admin)]
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
            var scoredMovieId = await _moviesManager.SetScoreAsync(movieRatingDTO, _userClaims.Id);
            return Ok(scoredMovieId);
        }

        [Authorize(Roles = AuthConsts.Admin)]
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteAsync(long movieId)
        {
            await _moviesManager.DeleteAsync(movieId);
            return Ok();
        }

    }
}
