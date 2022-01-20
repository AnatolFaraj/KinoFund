﻿using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Collection
    {
        public long CollectionId { get; set; }
        public string CollectionName { get; set; }
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public CollectionType Type { get; set; }


        public virtual ICollection<Movie> Movies { get; set; }
    }
}