using FileWebAPI.Utilities.Enums;

namespace FileWebAPI.Utilities.File.Model
{
    public class SaveFileRequest
    {
        public IFormFile File { get; set; }
        public string? Path { get; set; }
        public string FileName { get; set; }
        public FileType FileType { get; set; }
    }
}
