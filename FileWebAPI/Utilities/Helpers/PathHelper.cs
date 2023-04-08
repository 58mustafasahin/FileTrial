namespace FileWebAPI.Utilities.Helpers
{
    public interface IPathHelper
    {
        string GetPathByCustomerId(string filePathSettingType, long customerId);
        string GetPath(string filePathSettingType);
    }

    public class PathHelper : IPathHelper
    {
        private readonly IConfiguration _configuration;
        public PathHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetPathByCustomerId(string filePathSettingType, long customerId)
        {
            string logoFilePath = GetPath(filePathSettingType);
            return Path.Combine(logoFilePath, customerId.ToString());
        }

        public string GetPath(string filePathSettingType)
        {
            var filePath = _configuration.GetSection("PathSetting").GetSection(filePathSettingType).Value;
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File Path Is Not Defined");
            }
            return filePath;
        }
    }
}
