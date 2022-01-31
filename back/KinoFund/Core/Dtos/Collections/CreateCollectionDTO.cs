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
    public class CreateCollectionDTO
    {
        public string Name { get; set; }
        public long UserId { get; set; }
        public CollectionType Type { get; set; }
        public List<MovieIdDTO> Movies { get; set; }


    }

    //public static class CollectionCreateDtoExtensionMethods
    //{
    //    public static CollectionCreateDTO TurnDto(this Collection collectionModel)
    //    {
    //        return new CollectionCreateDTO
    //        {
    //            CollectionId = collectionModel.CollectionId,
    //            Name = collectionModel.Name,
    //            UserId = collectionModel.UserId,
    //            Type = collectionModel.Type,
    //            Movies = collectionModel.Movies.Select(x => new MovieDTO
    //            {
    //                MovieId = x.MovieId,
    //                Title = x.Title,
    //                Category = x.CategoryId,
    //                Description = x.MovieDetail.Description

    //            }).ToList()
    //        };



    //    }
    //}
}
