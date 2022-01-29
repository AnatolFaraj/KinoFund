using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Comments
{
    public class GetAllComentsDTO
    {
        public List<CommentDTO> Comments { get; set; }
    }
}
