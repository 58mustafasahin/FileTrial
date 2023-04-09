using FileWebAPI.Utilities.Enums;
using FileWebAPI.Utilities.File;
using FileWebAPI.Utilities.File.Model;
using FileWebAPI.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FileWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IPathHelper _pathHelper;

        public FilesController(IFileService fileService, IPathHelper pathHelper)
        {
            _fileService = fileService;
            _pathHelper = pathHelper;
        }

        [HttpGet("path")]
        public async Task<IActionResult> GetFilePath(FileType fileType)
        {
            var filePaths = _pathHelper.GetPath(fileType.ToString());
            return Ok(filePaths);
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles(FileType fileType)
        {
            var filePaths = _pathHelper.GetPath(fileType.ToString());
            var files = Directory.GetFiles(filePaths, "*.*");
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] SaveFileRequest data)
        {
            var fullPath = _pathHelper.GetPath(data.FileType.ToString());
            var saveFileResult = await _fileService.SaveFile(new SaveFileRequest { File = data.File, Path = fullPath });

            return Ok(saveFileResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] SaveFileRequest data)
        {
            _fileService.DeleteFile(data.Path);
            var fullPath = _pathHelper.GetPath(data.FileType.ToString());
            var saveFileResult = await _fileService.SaveFile(new SaveFileRequest { File = data.File, Path = fullPath });

            return Ok(saveFileResult);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string fullPath)
        {
            var result = _fileService.DeleteFile(fullPath);
            return Ok(result);
        }
    }
}
