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
        public static void SetRichtextWithHighlights(System.Windows.Forms.RichTextBox richTextBox, List<string> highlightTokens)
        {
            // Generate richtext from logfile, adding gray highlight for comments
            string scriptText = richTextBox.Text.Replace("\n",(@"\par"+"\n"));
            int selectionStart = richTextBox.SelectionStart;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 " + richTextBox.Font.FontFamily.Name + @";}}");
            sb.AppendLine(@"{\colortbl ;\red145\green42\blue166;\red255\green255\blue0;}");
            sb.AppendLine(@"{\*\generator Riched20 10.0.18362}\viewkind4\uc1 ");
            sb.AppendLine(@"\pard\f0\fs"+ (int)richTextBox.Font.SizeInPoints*2 + @"\lang1033 ");
            foreach (string token in highlightTokens)
            {
                if (!string.IsNullOrEmpty(token))
                {
                    string richtextToken = "{"+string.Format(@"\cf1\b {0}", token.Replace(@"\", @"\\").Replace(@"/", @"\/").Replace(@"{", @"\{").Replace(@"}", @"\}")+"}");
                    scriptText = scriptText.Replace(token, richtextToken);
                }
            }
            sb.Append(scriptText);
            richTextBox.Rtf = sb.ToString();
            richTextBox.SelectionStart = selectionStart;
            richTextBox.ScrollToCaret();
            richTextBox.Refresh();
        }
        
    }
}
