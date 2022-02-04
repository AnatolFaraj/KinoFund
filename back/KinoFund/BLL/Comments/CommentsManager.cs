using Core.Dtos.Comments;
using Core.Models;
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
        

        private List<CommentDTO> GetCommetsDTO(List<CommentModel> comments)
        {
            return comments.Select(c => new CommentDTO 
            { 
                CommentId = c.CommentId,
                ParentCommentId = c.RefersToCommentId,
                Date = c.Date,
                Text = c.Text,
                UserId = c.UserId,
                UserName = c.User.UserName,
                NumberOfComments = _dbContext.Comments.Count(ch => ch.RefersToCommentId == c.CommentId) 
            
            }).ToList();
        } 



        
        public async Task<GetAllComentsDTO> GetAllAsync(long movieId)
        {
            var allCommentsByMovie =  await _dbContext.Comments
                .Include(i => i.User)
                .Include(i => i.Movie)
                .Where(x => x.MovieId == movieId)
                .Where(x => x.RefersToCommentId == null)
                .ToListAsync();


            var commentDTO = GetCommetsDTO(allCommentsByMovie);


            return new GetAllComentsDTO
            {
                Comments = commentDTO,
            };
        }

        public async Task<List<CommentDTO>> GetAllSubsByIdAsync(long commentId)
        {

            var allSubCommentsByComment = await _dbContext.Comments
                .Include(i => i.User)
                .Where(x => x.RefersToCommentId == commentId)
                .ToListAsync();

            return GetCommetsDTO(allSubCommentsByComment);
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
            var commentModel = new CommentModel()
            {
                UserId = commentDTO.UserId,
                MovieId = commentDTO.MovieId,
                Text = commentDTO.Text,
                RefersToCommentId = commentDTO.ParentId
            };
            _dbContext.Comments.Add(commentModel);

            await _dbContext.SaveChangesAsync();

            return commentModel.CommentId;
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
