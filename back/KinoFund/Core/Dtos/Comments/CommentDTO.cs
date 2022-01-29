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
        public string MovieTitle { get; set; }
        public string Text { get; set; }

        public long? RefersTo { get; set; }


    }
}
