using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CategoryModel
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        

        public ICollection<MovieModel> Movies { get; set; }
    }
}
