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
        public async Task<GetAllCollectionsDTO> GetAllAsync()
        {
            var collections = await _collectionsManager.GetAllAsync();
            return collections;
        }

        [HttpGet("{collectionId}/info")]
        public async Task<CollectionInfoDTO> GetInfoAsync(long collectionId)
        {
            var collection = await _collectionsManager.GetInfoAsync(collectionId);
            return collection;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CreateCollectionDTO collection)
        {
            var newCollectionId = await _collectionsManager.CreateAsync(collection);
            return Ok(newCollectionId);
        }

        [HttpPut("{collectionId}")]
        public async Task<IActionResult> EditAsync(EditCollectionDTO collection)
        {
            await _collectionsManager.EditAsync(collection);
            return Ok(collection);
        }

        [HttpDelete("{collectionId}")]
        public async Task<IActionResult> DeleteAsync(long colllectionId)
        {
             await _collectionsManager.DeleteAsync(colllectionId);
            return Ok();
        }
    }
}
