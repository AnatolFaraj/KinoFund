using BLL.Comments;
using Core.Dtos.Comments;
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
    [Authorize]
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsManager _commentsManager;
        private readonly UserClaims _userClaims;
        public CommentsController(CommentsManager commentsManager, UserClaims userClaims)
        {
            _commentsManager = commentsManager;
            _userClaims = userClaims;
        }

        [HttpGet("")]
        public async Task<GetAllComentsDTO> GetAllAsync(long movieId)
        {
            var comments = await _commentsManager.GetAllAsync(movieId);
            return comments;
        }
        [HttpGet("{commentId}")]
        public async Task<List<CommentDTO>> GetAllSubsByIdAsync(long commentId)
        {
            var subComments = await _commentsManager.GetAllSubsByIdAsync(commentId);
                return subComments;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CreateCommentDTO commentDTO)
        {
            var newCommentId = await _commentsManager.CreateAsync(commentDTO, _userClaims.Id);
            return Ok(newCommentId);
        }

        [HttpPut("{commentId}")]
        public async Task<IActionResult> EditAsync(long commentId, EditCommentDto commentDTO)
        {
            await _commentsManager.EditAsync(commentDTO, _userClaims.Role, _userClaims.Id);
            return Ok(commentDTO);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteAsync(long commentId)
        {

            await _commentsManager.DeleteAsync(commentId, _userClaims.Role, _userClaims.Id);
            return Ok();
        }
    }
}
