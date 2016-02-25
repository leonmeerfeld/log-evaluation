using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace log_evaluation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        sort s = new sort();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        List<string[]> sorted_log_list = new List<string[]>();

        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            string file;
            string text;

            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    text = File.ReadAllText(file, System.Text.Encoding.UTF8);

                    sorted_log_list = s.sort_log_into_list(text);

                    toolStripStatusLabel1.Text = file;
                }
                catch (IOException IOex)
                {
                    MessageBox.Show("Error beim lesen der Datei! " + IOex.ToString());
                }
            }
        }
    }
}
