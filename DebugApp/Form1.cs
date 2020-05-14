using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DebugApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void runAsyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSDrilldownTool.Util.PowershellTask powershellTask = new PSDrilldownTool.Util.PowershellTask(
                scriptText:textBox_Script.Text
                , variables: new Dictionary<string, object>()
                , scriptFiles: new List<string>()
       
                );

            powershellTask.StartPsTaskAsync();
            while (!powershellTask.TaskCompleted)
            {
                System.Threading.Thread.Sleep(1000);
            }
            textBox_output.Text = powershellTask.ResultText;
        }

        private void runSyncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PSDrilldownTool.Util.PowershellTask powershellTask = new PSDrilldownTool.Util.PowershellTask(
                scriptText: textBox_Script.Text
                , variables: new Dictionary<string, object>()
                , scriptFiles: new List<string>()

                );

            powershellTask.RunPsTaskSync();
            while (!powershellTask.TaskCompleted)
            {
                System.Threading.Thread.Sleep(1000);
            }
            textBox_output.Text = powershellTask.ResultText;
        }
    }
}
