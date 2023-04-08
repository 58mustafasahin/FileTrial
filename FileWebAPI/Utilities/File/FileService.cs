using FileWebAPI.Utilities.File.Model;
using System.Text;

namespace FileWebAPI.Utilities.File
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }
        public string DeleteFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return "File not found !";
            }
            System.IO.File.Delete(path);
            return "File deleted";
        }
        public async Task<string> SaveFile(SaveFileRequest saveFileReq)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(saveFileReq.File.FileName);

            if (!string.IsNullOrEmpty(saveFileReq.FileName))
            {
                DeleteFile(saveFileReq.FileName);
            }

            if (!Directory.Exists(saveFileReq.Path))
            {
                Directory.CreateDirectory(saveFileReq.Path);
            }
            var result = saveFileReq.Path + "/" + fileName;
            using (var stream = new FileStream(result, FileMode.Create))
            {
                await saveFileReq.File.CopyToAsync(stream);
            }
            return result;
        }
        public async Task<byte[]> GetFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                return Encoding.UTF8.GetBytes("File not found !");
            }
            var file = await System.IO.File.ReadAllBytesAsync(path);
            return file;
        }
    }
}
