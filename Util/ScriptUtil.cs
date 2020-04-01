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
            sb.AppendLine(@"\pard\f0\fs20\lang1033 ");
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
        /*
                    StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Courier New;}{\f1\fnil\fcharset0 Calibri;}}");
            sb.AppendLine(@"{\colortbl ;\red192\green192\blue192;\red0\green255\blue0;\red255\green255\blue0;\red255\green105\blue180;}");
            sb.AppendLine(@"{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs18");
            foreach (XmlNode n in xmlDoc.SelectNodes("Results/Result"))
            {
                switch (n.SelectSingleNode("Column[@Name='Status']").InnerText)
                {
                    case "NOT STARTED":
                        sb.Append(@"\highlight1 "); // Gray
                        break;
                    case "RUNNING":
                        sb.Append(@"\highlight1 "); // Gray
                        break;
                    case "ABORTED":
                        sb.Append(@"\highlight3 "); // Yellow
                        break;
                    case "TIMEOUT":
                        sb.Append(@"\highlight3 "); // Yellow
                        break;
                    case "COMPLETED":
                        sb.Append(@"\highlight2 "); // Green
                        break;
                    case "FAILED":
                        sb.Append(@"\highlight4 ");  // Hot Pink
                        break;
                    default:
                        sb.Append(@"\highlight3 "); // Yellow
                        break;
                }
                sb.AppendLine("=============================================");
                sb.AppendLine(@"\line");
                sb.AppendLine(description);
                sb.AppendLine(@"\line");
                sb.AppendLine("==================== SCRIPT =================");
                sb.AppendLine(@"\line");
                string scriptText = GetXmlTextValue(n, "Column[@Name='ScriptText']");
                sb.Append(scriptText.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}").Replace("\r", @"\line"));
                sb.AppendLine(@"\line");
                sb.AppendLine("==================== OUTPUT =================");
                sb.AppendLine(@"\line");
                sb.AppendLine(@"\highlight0 ");
                // Replace RTF special characters and then write the line
                string output = GetXmlTextValue(n, "Column[@Name='Output']");
                textBox_Output.Text = output;
                sb.Append(output.Replace(@"\", @"\\").Replace(@"{", @"\{").Replace(@"}", @"\}").Replace("\r", @"\line"));
                sb.AppendLine(@"\line");
            }

            richTextBox_History.Rtf = sb.ToString();
            richTextBox_History.SelectionStart = richTextBox_History.Text.Length;
            richTextBox_History.ScrollToCaret();
            richTextBox_History.Refresh();* 
         * */
    }
}
