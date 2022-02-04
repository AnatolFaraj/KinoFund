using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Comments
{
    public class EditCommentDto
    {
        public long CommentId { get; set; }
        public string Text { get; set; }
    }
}
