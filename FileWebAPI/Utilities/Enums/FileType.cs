using System.ComponentModel;

namespace FileWebAPI.Utilities.Enums
{
    public enum FileType
    {
        [Description("Logo")]
        Logo = 0,
        [Description("Category")]
        Category = 1,
        [Description("Profile")]
        Profile = 2,
    }
}
