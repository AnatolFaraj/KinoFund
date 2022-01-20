using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public long MovieId { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public int RefersToCommentId { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Comment RefersToNavigation { get; set; }
    }
}
