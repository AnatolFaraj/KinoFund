using Core.Dtos.Movies;
using Core.Enums;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Collections
{
    public class CollectionInfoDTO
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public CollectionType Type { get; set; }

        public List<CollectionMovieDTO> Movies { get; set; }
    }

    public static class CollectionInfoDtoExtensionMethods
    {
        public static CollectionInfoDTO ToDto(this CollectionModel collectionModel, CollectionInfoDTO movies)
        {
            return new CollectionInfoDTO
            {
                Name = collectionModel.Name,
                Author = collectionModel.User.UserName,
                Type = collectionModel.Type,
                Movies = movies.Movies
            };


            
        }
    }
}
