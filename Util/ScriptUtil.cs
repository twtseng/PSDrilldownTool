using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PSDrilldownTool.Util
{
    public class ScriptUtil
    {
        public static string ScriptNameToken(string scriptName)
        {
            return "#" + scriptName + "#";
        }
        private static string RtfColorString(Color color)
        {
            return string.Format("\\red{0}\\green{1}\\blue{2}", color.R, color.G, color.B);
        }
        public static string GenerateRichtextWithHighlights(string scriptText, Font font, Color highlightColor, Color replacementMissingColor, Dictionary<string, string> tokenReplacementKeyValuePair)
        {
            if (string.IsNullOrEmpty(scriptText))
            {
                return string.Empty;
            }
            // Generate RTF header
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"{\rtf1\ansi\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 " + font.FontFamily.Name + @";}}");
            sb.AppendLine("{\\colortbl ;"+ RtfColorString (highlightColor) + ";"+ RtfColorString(replacementMissingColor) + ";}");
            sb.AppendLine(@"{\*\generator Riched20 10.0.18362}\viewkind4\uc1 ");
            sb.AppendLine(@"\pard\f0\fs" + (int)font.SizeInPoints * 2 + @"\lang1033 ");

            // 1) Escape richtext from the scriptText
            string escapedScriptText = scriptText.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}").Replace("\n", (@"\par" + "\n"));

            // 2) Replace tokens with values
            // If tokenReplacementKeyValuePair value is not empty, we will print the value in highlightColor
            // If tokenReplacementKeyValuePair value is empty, we will print the key in replacementMissingColor
            foreach (var kvp in tokenReplacementKeyValuePair)
            {
                if (string.IsNullOrEmpty(kvp.Value))
                {
                    string richtextToken = string.Format("{{\\cf2\\b {0}}}", kvp.Key);
                    escapedScriptText = escapedScriptText.Replace(kvp.Key, richtextToken);
                }
                else
                {
                    string richtextToken = string.Format("{{\\cf1\\b {0}}}", kvp.Value);
                    escapedScriptText = escapedScriptText.Replace(kvp.Key, richtextToken);
                }
            }
            sb.Append(escapedScriptText);
            sb.AppendLine("}");
            return sb.ToString();
        }
        /*
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
                    string richtextToken = "{"+string.Format(@"\cf1\b {0}", token.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}")+"}");
                    scriptText = scriptText.Replace(token, richtextToken);
                }
            }
            sb.Append(scriptText);
            richTextBox.Rtf = sb.ToString();
            richTextBox.SelectionStart = selectionStart;
            richTextBox.ScrollToCaret();
            richTextBox.Refresh();
        }
        */
    }
}
