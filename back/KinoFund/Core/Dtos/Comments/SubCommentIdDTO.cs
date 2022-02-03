using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Comments
{
    public class SubCommentIdDTO
    {
        public long SubCommentId { get; set; }

        public List<SubCommentIdDTO> SubComments { get; set; }
    }

    public static class SubCommentIdDTOExtensionMethods
    {
        public static List<SubCommentIdDTO> GetSubComments(this CommentModel commentModel)
        {
            var subCommentsList = commentModel.Movie.Comments
                .Where(x => x.RefersToCommentId == commentModel.CommentId)
                .Select(s => new SubCommentIdDTO
                {
                    SubCommentId = s.CommentId,
                    SubComments = s.GetSubComments()


                }).ToList();

            return subCommentsList;



        }
    }
}
