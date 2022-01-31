using Core.Dtos.Movies;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Collections
{
    public class EditCollectionDTO
    {
        public string Name { get; set; }
        public CollectionType Type { get; set; }

        public List<MovieIdDTO> Movies { get; set; }
    }
}
