using BLL.Collections;
using Core.Dtos.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/collections")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly CollectionsManager _collectionsManager;

        public CollectionsController(CollectionsManager collectionsManager)
        {
            _collectionsManager = collectionsManager;
        }

        [HttpGet("")]
        public async Task<GetAllCollectionsDTO> GetAllCollectionsAsync()
        {
            var collections = await _collectionsManager.GetAllCollectionsAsync();
            return collections;
        }

        [HttpGet("{collectionId}")]
        public async Task<CollectionInfoDTO> GetCollectionAsync(long collectionId)
        {
            var collection = await _collectionsManager.GetCollectionAsync(collectionId);
            return collection;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCollectionAsync(CreateCollectionDTO collection)
        {
            await _collectionsManager.CreateCollectionAsync(collection);
            return Ok();
        }

        [HttpPut("edit/{collectionId}")]
        public async Task<IActionResult> EditCollectionAsync(EditCollectionDTO collection, long collectionId)
        {
            await _collectionsManager.EditCollectionAsync(collection, collectionId);
            return Ok(collection);
        }

        [HttpDelete("delete/{collectionId}")]
        public async Task<IActionResult> DeleteCollectionAsync(long colllectionId)
        {
            await _collectionsManager.DeleteCollectionAsync(colllectionId);
            return Ok();
        }
    }
}
