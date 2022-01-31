using Core.Dtos.Movies;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Collections
{
    public class CollectionDTO
    {
        public long CollectionId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public CollectionType Type { get; set; }
        public int MoviesCount { get; set; }


    }
}
