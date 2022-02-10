using FileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/fileStorage")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly FileManager _fileManager;
        public FileStorageController(FileManager fileManager)
        {
            _fileManager = fileManager;
        }


        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFileAsync(string fileName)
        {
            var file = await _fileManager.GetFileAsync(fileName);
            return File(file, "image/png");
        }


        [HttpPost("")]
        public async Task<IActionResult> SaveFileAsync(IFormFile incomingFile, string fileName)
        {
            string newFileName = null;

            if(incomingFile.Length > 0)
            {
                using(var ms = new MemoryStream())
                {
                    await incomingFile.CopyToAsync(ms);
                    var fileInBytes = ms.ToArray();
                    newFileName = await _fileManager.SaveFileAsync(fileInBytes, fileName);
                }
            }

            return Ok(newFileName);
        }
    }
}
