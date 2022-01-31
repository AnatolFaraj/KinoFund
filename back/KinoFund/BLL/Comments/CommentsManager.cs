using Core.Dtos.Comments;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Comments
{
    public class CommentsManager
    {
        private readonly MyContext _dbContext;

        public CommentsManager(MyContext context)
        {
            _dbContext = context;
        }

        public async Task<GetAllComentsDTO> GetAllCommentsAsync(long movieId)
        {
            var comments = await _dbContext.Comments
                .Include(i => i.User)
                .Include(i => i.Movie)
                .Where(x => x.MovieId == movieId)
                .Select(c => new CommentDTO
                {
                    CommentId = c.CommentId,
                    UserName = c.User.UserName,
                    MovieTitle = c.Movie.Title,
                    Text = c.Text,
                    RefersTo = c.RefersToCommentId

                }).ToListAsync();

            return new GetAllComentsDTO
            {
                Comments = comments,
            };
        }

        public async Task<EditCommentDto> EditCommentAsync(long commentId, EditCommentDto commentDTO)
        {
            var existingComment = _dbContext.Comments
                .Where(c => c.CommentId == commentId)
                .FirstOrDefault();

            if(existingComment != null)
            {
                existingComment.Text = commentDTO.Text;

                await _dbContext.SaveChangesAsync();
            }

            return commentDTO;
        }

        public async Task<CreateCommentDTO> CreateCommentAsync(CreateCommentDTO commentDTO)
        {
            _dbContext.Comments.Add(new Core.Models.CommentModel()
            { 
                UserId = commentDTO.UserId,
                MovieId = commentDTO.MovieId,
                Date = commentDTO.Date,
                Text = commentDTO.Text,
                RefersToCommentId = commentDTO.RefersTo
                
            });

            await _dbContext.SaveChangesAsync();
            return commentDTO;
        }



        public async Task DeleteCommentAsync(long commentId)
        {
            var comment = _dbContext.Comments
                .Where(c => c.CommentId == commentId)
                .FirstOrDefault();

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
