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

        public async Task<GetAllComentsDTO> GetAllAsync(long movieId)
        {

            var comments = await _dbContext.Comments
                .Include(i => i.User)
                .Include(i => i.Movie)
                .Where(x => x.MovieId == movieId)
                .Select(c => new CommentDTO
                {
                    CommentId = c.CommentId,
                    UserName = c.User.UserName,
                    Text = c.Text,
                    ParentCommentId = c.RefersToCommentId,
                    SubComments = c.Movie.Comments.Where(x => x.RefersToCommentId == c.CommentId).Select(x => new SubCommentIdDTO
                    { 
                        SubCommentId = x.CommentId

                        
                    }).ToList()

                }).ToListAsync();

            

            return new GetAllComentsDTO
            {
                Comments = comments,
            };
        }

        public async Task<bool> EditAsync(EditCommentDto commentDTO)
        {
            var commentModel = await _dbContext.Comments
                .Where(c => c.CommentId == commentDTO.CommentId)
                .FirstOrDefaultAsync();

            if(commentModel != null)
            {
                commentModel.Text = commentDTO.Text;

                await _dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<long> CreateAsync(CreateCommentDTO commentDTO)
        {
            _dbContext.Comments.Add(new Core.Models.CommentModel()
            { 
                UserId = commentDTO.UserId,
                MovieId = commentDTO.MovieId,
                Text = commentDTO.Text,
                RefersToCommentId = commentDTO.RefersTo
                
            });

            await _dbContext.SaveChangesAsync();

            var newId = _dbContext.Comments.Select(x => x.CommentId).Max();
            return newId;
        }



        public async Task<bool> DeleteAsync(long commentId)
        {
            var comment = await _dbContext.Comments
                .Where(c => c.CommentId == commentId)
                .FirstOrDefaultAsync();

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
