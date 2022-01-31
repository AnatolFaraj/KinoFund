using Core.Dtos.Collections;
using Core.Dtos.Movies;
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

        public async Task<GetAllCollectionsDTO> GetAllCollectionsAsync()
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

            return new GetAllCollectionsDTO
            {
                Collections = collections,
            };
        }

        public async Task<CollectionInfoDTO> GetCollectionAsync(long collectionId)
        {
            var collection = await _dbContext.Collections
                .Include(i => i.Movies)
                .ThenInclude(i => i.MovieDetail)
                .Include(i => i.User)
                
                .FirstAsync(c => c.CollectionId == collectionId);

            return collection.ToDto();
        }

        public async Task<CreateCollectionDTO> CreateCollectionAsync(CreateCollectionDTO collectionDTO)
        {
            var movieIds = collectionDTO.Movies.Select(x => x.MovieId).ToList();
            var movieModels = await _dbContext.Movies.Where(x => movieIds.Contains(x.MovieId)).ToListAsync();

            _dbContext.Collections.Add(new Core.Models.CollectionModel()
            {

                Name = collectionDTO.Name,
                Type = collectionDTO.Type,
                UserId = collectionDTO.UserId,
                Movies = movieModels

            });


            


            await _dbContext.SaveChangesAsync();
            return collectionDTO;
        }


        public async Task<EditCollectionDTO> EditCollectionAsync(EditCollectionDTO collectionDTO, long collectionId)
        {
            var existingCollection = _dbContext.Collections
                .Where(c => c.CollectionId == collectionId)
                .Include(i => i.Movies)
                .ThenInclude(i => i.MovieDetail)
                .FirstOrDefault();

            var movieIds = collectionDTO.Movies.Select(x => x.MovieId).ToList();
            var movieModels = await _dbContext.Movies.Where(x => movieIds.Contains(x.MovieId)).ToListAsync();

            if (existingCollection != null)
            {
                existingCollection.Name = collectionDTO.Name;
                existingCollection.Type = collectionDTO.Type;
                existingCollection.Movies = movieModels;
                

                await _dbContext.SaveChangesAsync();
            }

            return collectionDTO;

        }

        public async Task DeleteCollectionAsync(long collectionId)
        {
            var collection = _dbContext.Collections
                .Where(c => c.CollectionId == collectionId)
                .FirstOrDefault();

            _dbContext.Collections.Remove(collection);
            await _dbContext.SaveChangesAsync();
        }
    }
}
