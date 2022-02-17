using Core.Dtos.Authentication;
using Core.Dtos.Collections;
using Core.Dtos.Movies;
using Core.Models;
using DAL.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Collections
{
    public class CollectionsManager
    {
        private readonly MyContext _dbContext;

        public CollectionsManager(MyContext context)
        {
            _dbContext = context;
        }

        public async Task<GetAllCollectionsDTO> GetAllAsync(string role, string userName)
        {
            var collections = await _dbContext.Collections
                .Include(i => i.Movies)
                .Include(i => i.User)
                .Select(c => new CollectionDTO
                {
                    CollectionId = c.CollectionId,
                    Name = c.Name,
                    Author = c.User.UserName,
                    Type = c.Type,
                    MoviesCount = c.Movies.Count

                }).ToListAsync();

            if(role == AuthConsts.User)
            {
                var userCollections = collections
                    .Where(x => Enum.GetName(x.Type) == CollectionConsts.Public || x.Author == userName)
                    .ToList();

                return new GetAllCollectionsDTO
                {
                    Collections = userCollections
                };
            }
            

            return new GetAllCollectionsDTO
            {
                Collections = collections,
            };
        }

        public async Task<CollectionInfoDTO> GetInfoAsync(long collectionId, string userRole, long userId)
        {
            var collection = await _dbContext.Collections
                .Include(i => i.Movies)
                .ThenInclude(i => i.MovieDetail)
                .Include(i => i.User)
                
                .FirstAsync(c => c.CollectionId == collectionId);

            if(userRole == AuthConsts.User && Enum.GetName(collection.Type) == CollectionConsts.Private && collection.UserId != userId)
            {
                throw new Exception("The collection is private");
            }

            var movies = collection.Movies.Select(x => new CollectionMovieDTO
            { 
                MovieId = x.MovieId

            }).ToList();

            return collection.ToDto(movies);
        }

        public async Task<long> CreateAsync(CreateCollectionDTO collectionDTO, long userId)
        {
            var movieIds = collectionDTO.Movies.Select(x => x.MovieId).ToList();
            var movieModels = await _dbContext.Movies.Where(x => movieIds.Contains(x.MovieId)).ToListAsync();


            var collectionModel = new CollectionModel()
            {
                Name = collectionDTO.Name,
                Type = collectionDTO.Type,
                UserId = userId,
                Movies = movieModels
            };
            _dbContext.Collections.Add(collectionModel);

            await _dbContext.SaveChangesAsync();

            return collectionModel.CollectionId;
        }


        public async Task<bool> EditAsync(EditCollectionDTO collectionDTO, string userRole, long userId)
        {
            var collectionModel = await _dbContext.Collections
                .Where(c => c.CollectionId == collectionDTO.CollectionId)
                .FirstOrDefaultAsync();

            if(userRole == AuthConsts.User && userId != collectionModel.UserId)
            {
                throw new Exception("You can't modify other people's collections");
            }

            var movieIds = collectionDTO.Movies.Select(x => x.MovieId).ToList();
            var movieModels = await _dbContext.Movies.Where(x => movieIds.Contains(x.MovieId)).ToListAsync();

            if (collectionModel != null)
            {
                collectionModel.Name = collectionDTO.Name;
                collectionModel.Type = collectionDTO.Type;
                collectionModel.Movies = movieModels;
                

                await _dbContext.SaveChangesAsync();
            }

            return true;

        }

        public async Task<bool> DeleteAsync(long collectionId, string userRole, long userId)
        {
            var collection = await _dbContext.Collections
                .Where(c => c.CollectionId == collectionId)
                .FirstAsync();

            if(userRole == AuthConsts.User && collection.UserId != userId)
            {
                throw new Exception("You can't delete other people's collections");
            }

            _dbContext.Collections.Remove(collection);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
