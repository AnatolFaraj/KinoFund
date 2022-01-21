using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        

        public ICollection<Movie> Movies { get; set; }
    }
}
