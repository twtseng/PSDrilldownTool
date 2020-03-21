using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSDrilldownTool.Util
{
    public class ScriptUtil
    {
        public static string ScriptNameToken(string scriptName)
        {
            return "{" + scriptName + "}";
        }
    }
}
