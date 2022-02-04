using Core.Dtos.Comments;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Comments
{
    public class CommentDTO
    {
        public long CommentId { get; set; }
        public string UserName { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

        public long? ParentCommentId { get; set; }

        public int NumberOfComments { get; set; }
        



    }
}


