using FileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Files
{
    public class FilesManager
    {
        private readonly FileService _fileService;
        public FilesManager(FileService fileService)
        {
            _fileService = fileService;
        }

        public async Task<string> UploadAsync(byte[] incomingFile, string fileName)
        {
            var fileObj = await _fileService.UploadAsync(incomingFile, fileName);

            if(fileObj.IsValid == false)
            {
                throw new Exception(fileObj.ErrorMessage);
            }

            return fileObj.FileKey;
        }

        public async Task<byte[]> DownloadAsync(string fileKey)
        {
            var fileObj = await _fileService.DownloadAsync(fileKey);

            if(fileObj.IsValid == false)
            {
                throw new Exception(fileObj.ErrorMessage);
            }

            return fileObj.FileArray;
        }
    }
}
