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

        public async Task<GetAllCollectionsDTO> GetAllAsync()
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

        public async Task<CollectionInfoDTO> GetInfoAsync(long collectionId)
        {
            var collection = await _dbContext.Collections
                .Include(i => i.Movies)
                .ThenInclude(i => i.MovieDetail)
                .Include(i => i.User)
                
                .FirstAsync(c => c.CollectionId == collectionId);

            var movies = new CollectionInfoDTO();

            return collection.ToDto(movies);
        }

        public async Task<long> CreateAsync(CreateCollectionDTO collectionDTO)
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
            return collectionDTO.CollectionId;
        }


        public async Task<bool> EditAsync(EditCollectionDTO collectionDTO)
        {
            var collectionModel = await _dbContext.Collections
                .Where(c => c.CollectionId == collectionDTO.CollectionId)
                .Include(i => i.Movies)
                .ThenInclude(i => i.MovieDetail)
                .FirstOrDefaultAsync();

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

        public async Task<bool> DeleteAsync(long collectionId)
        {
            var collection = await _dbContext.Collections
                .Where(c => c.CollectionId == collectionId)
                .FirstOrDefaultAsync();

            _dbContext.Collections.Remove(collection);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
