using System.IO;

namespace DecodeBytes.Common
{
    public static class ApplicationPath
    {
        public static string PathTo(string folderName)
        {
            return Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\", folderName));
        }
    }
}
