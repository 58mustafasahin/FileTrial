using FileWebAPI.Utilities.File.Model;

namespace FileWebAPI.Utilities.File
{
    public interface IFileService
    {
        Task<string> SaveFile(SaveFileRequest saveFileReq);
        string DeleteFile(string path);
        Task<byte[]> GetFile(string path);
    }
}
