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
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsManager _commentsManager;
        public CommentsController(CommentsManager commentsManager)
        {
            _commentsManager = commentsManager;
        }

        [HttpGet("")]
        public async Task<GetAllComentsDTO> GetAllAsync(long movieId)
        {
            var comments = await _commentsManager.GetAllAsync(movieId);
            return comments;
        }
        [HttpGet("{commentId}")]
        public async Task<CommentDTO> GetAllSubsByIdAsync(long commentId)
        {
            var subComments = await _commentsManager.GetAllSubsByIdAsync(commentId);
                return subComments;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCommentDTO commentDTO)
        {
            var newCommentId = await _commentsManager.CreateAsync(commentDTO);
            return Ok(newCommentId);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> EditAsync(EditCommentDto commentDTO)
        {
            await _commentsManager.EditAsync(commentDTO);
            return Ok(commentDTO);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(long commentId)
        {
            await _commentsManager.DeleteAsync(commentId);
            return Ok();
        }
    }
}
