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
        public static List<SubCommentIdDTO> GetCommentsHierarchy(ICollection<Core.Models.CommentModel> allComments, long parentCommentId)
        {
            var hierarchy = new List<SubCommentIdDTO>();
            
            var subComments = allComments.Where(x => x.RefersToCommentId == parentCommentId);
            

            foreach(var sub in subComments)
            {
                
                hierarchy.Add(new SubCommentIdDTO() { SubCommentId = sub.CommentId, SubComments = GetCommentsHierarchy(allComments, sub.CommentId) });
            }

            return hierarchy;

        }

        public static int TotalSubCommentsCount(List<SubCommentIdDTO> comments)
        {
            int returnCount = comments.Count;

            foreach(var comment in comments)
            {
                returnCount += TotalSubCommentsCount(comment.SubComments);
            }

            return returnCount;
        }
        
        public async Task<GetAllComentsDTO> GetAllAsync(long movieId)
        {
            var allCommentsByMovie =  _dbContext.Comments
                .Include(i => i.User)
                .Include(i => i.Movie)
                .Where(x => x.MovieId == movieId).ToList();

            

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
                    NumberOfComments = TotalSubCommentsCount(GetCommentsHierarchy(allCommentsByMovie, c.CommentId)),
                    SubComments = GetCommentsHierarchy(allCommentsByMovie, c.CommentId),


                }).ToListAsync();


            return new GetAllComentsDTO
            {
                Comments = comments,
            };
        }

        public async Task<CommentDTO> GetAllSubsByIdAsync(long commentId)
        {

            var allSubCommentsByComment = _dbContext.Comments
                .Where(x => x.CommentId == commentId)
                .SelectMany(x => x.Movie.Comments)
                .ToList();



            var comment = await _dbContext.Comments
                .Include(i => i.User)
                .Include(i => i.Movie)
                .Where(x => x.CommentId == commentId)
                .Select(c => new CommentDTO
                {
                    CommentId = c.CommentId,
                    UserName = c.User.UserName,
                    Text = c.Text,
                    ParentCommentId = c.RefersToCommentId,
                    NumberOfComments = TotalSubCommentsCount(GetCommentsHierarchy(allSubCommentsByComment, c.CommentId)),
                    SubComments = GetCommentsHierarchy(allSubCommentsByComment, c.CommentId),


                }).FirstOrDefaultAsync();

            return comment;
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
            var commentModel = new Core.Models.CommentModel()
            {
                UserId = commentDTO.UserId,
                MovieId = commentDTO.MovieId,
                Text = commentDTO.Text,
                RefersToCommentId = commentDTO.RefersTo
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
