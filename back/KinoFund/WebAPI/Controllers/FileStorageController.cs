using BLL.Files;
using FileServices;

using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Authorize]

    [Route("api/fileStorage")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {

        private readonly FilesManager _filesManager;

        public FileStorageController(FilesManager filesManager)
        {
            _filesManager = filesManager;
        }

        [HttpGet("{fileKey}")]
        public async Task<IActionResult> DownloadAsync(string fileKey)
        {
            var file = await _filesManager.DownloadAsync(fileKey);
            
            return File(file, "image/png");
            
        }


        [HttpPost("")]
        public async Task<IActionResult> UploadAsync(IFormFile incomingFile, string fileName)
        {
            string fileKey = null;

            if (incomingFile.Length > 0)
            {
                using(var ms = new MemoryStream())
                {
                    await incomingFile.CopyToAsync(ms);
                    var fileInBytes = ms.ToArray();
                    fileKey = await _filesManager.UploadAsync(fileInBytes, fileName);
                    
                }
            }

            return Ok(fileKey);
        }
    }
}
