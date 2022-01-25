using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Comment
    {
        public long CommentId { get; set; }
        public long UserId { get; set; }
        public  User User { get; set; }
        public long MovieId { get; set; }
        public  Movie Movie { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public long? RefersToCommentId { get; set; }
        public  Comment RefersToNavigation { get; set; }
    }
}
