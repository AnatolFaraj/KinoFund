using BLL.Comments;
using Core.Dtos.Comments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/movies/{movieId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsManager _commentsManager;
        public CommentsController(CommentsManager commentsManager)
        {
            _commentsManager = commentsManager;
        }

        [HttpGet("")]
        public async Task<GetAllComentsDTO> GetAllCommentsAsync(long movieId)
        {
            var comments = await _commentsManager.GetAllCommentsAsync(movieId);
            return comments;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCommentAsync(CommentCreateDTO commentModel)
        {
            await _commentsManager.CreateCommentAsync(commentModel);
            return Ok();
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditCommentAsync(long commentId, CommentCreateDTO commentModel)
        {
            await _commentsManager.EditCommentAsync(commentId, commentModel);
            return Ok(commentModel);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMovieAsync(long commentId)
        {
            await _commentsManager.DeleteCommentAsync(commentId);
            return Ok();
        }
    }
}
