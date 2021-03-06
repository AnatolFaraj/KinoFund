using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CollectionModel
    {
        public long CollectionId { get; set; }
        public string Name { get; set; }
        public long UserId { get; set; }
        public  UserModel User { get; set; }

        public CollectionType Type { get; set; }


        public  ICollection<MovieModel> Movies { get; set; }
    }
}
