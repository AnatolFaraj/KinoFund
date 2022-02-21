using BLL.Collections;
using Core.Dtos.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Infrastructure;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/collections")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly CollectionsManager _collectionsManager;
        private readonly UserClaims _userClaims;
        public CollectionsController(CollectionsManager collectionsManager, UserClaims userClaims)
        {
            _collectionsManager = collectionsManager;
            _userClaims = userClaims;
        }

        [HttpGet("")]
        public async Task<GetAllCollectionsDTO> GetAllAsync()
        {

            var collections = await _collectionsManager.GetAllAsync(_userClaims.Role, _userClaims.Id);
            return collections;
        }

        [HttpGet("{collectionId}/info")]
        public async Task<CollectionInfoDTO> GetInfoAsync(long collectionId)
        {
            var collection = await _collectionsManager.GetInfoAsync(collectionId, _userClaims.Role, _userClaims.Id);
            return collection;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAsync(CreateCollectionDTO collection)
        {
            var newCollectionId = await _collectionsManager.CreateAsync(collection, _userClaims.Id);
            return Ok(newCollectionId);
        }

        [HttpPut("{collectionId}")]
        public async Task<IActionResult> EditAsync(long collectionId, EditCollectionDTO collection)
        {

            await _collectionsManager.EditAsync(collection, _userClaims.Role, _userClaims.Id);
            return Ok(collection);
        }

        [HttpDelete("{collectionId}")]
        public async Task<IActionResult> DeleteAsync(long collectionId)
        {
            await _collectionsManager.DeleteAsync(collectionId, _userClaims.Role, _userClaims.Id);
            return Ok();
        }
    }
}
