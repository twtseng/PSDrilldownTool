using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSDrilldownTool.Util
{
    public class FileUtil
    {
        public static string GetRelativePath(string fullPath)
        {
            // Require trailing backslash for path
            string basePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            if (!basePath.EndsWith("\\"))
                basePath += "\\";

            Uri baseUri = new Uri(basePath);
            Uri fullUri = new Uri(fullPath);

            Uri relativeUri = baseUri.MakeRelativeUri(fullUri);

            // Uri's use forward slashes so convert back to backward slashes
            return relativeUri.ToString().Replace("/", "\\");

        }
    }
}
