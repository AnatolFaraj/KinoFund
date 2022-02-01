using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Comments
{
    public class CreateCommentDTO
    {
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public long? RefersTo { get; set; }
        public string Text { get; set; }
    }
}
