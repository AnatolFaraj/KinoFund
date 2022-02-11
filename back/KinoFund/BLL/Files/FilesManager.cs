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

        public async Task<FileUploadObject> UploadAsync(byte[] incomingFile, string fileName)
        {
            var fileObj = await _fileService.UploadAsync(incomingFile, fileName);

            return fileObj;
        }

        public async Task<FileDownloadObject> DownloadAsync(string fileKey)
        {
            var file = await _fileService.DownloadAsync(fileKey);

            return file;
        }
    }
}
