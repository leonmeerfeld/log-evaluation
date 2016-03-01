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

        Sort s = new Sort();
        Filter f = new Filter();

        string[, ,] sorted_logs;
        string[] file_directories;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void updateStatusStrip ()
        {
            string status_strip_text = "Log files in selection:";

            foreach(string directory_path in file_directories)
            {
                string[] file_names = directory_path.Split('\\');
                status_strip_text = status_strip_text + " " + file_names[file_names.Count() - 1];
            }
            toolStripStatusLabel1.Text = status_strip_text;
        }

        private void directoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    file_directories = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    sorted_logs = s.sort_log_into_list(file_directories);
                    updateStatusStrip();
                }
                catch (IOException IOex)
                {
                    MessageBox.Show("Error beim lesen der Datei! " + IOex.ToString());
                }
            }
        }

        private void logFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    file_directories = openFileDialog1.FileNames;
                    sorted_logs = s.sort_log_into_list(file_directories);
                    updateStatusStrip();
                }
                catch (IOException IOex)
                {
                    MessageBox.Show("Error beim lesen der Datei! " + IOex.ToString());
                }
            }
        }

        string text1 = "";
        bool text1_changed = false;

        private void textBox1_Leave(object sender, EventArgs e)
        {
            text1_changed = (text1 == textBox1.Text) ? false : true;
            text1 = textBox1.Text;

            if (text1_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string text2 = "";
        bool text2_changed = false;

        private void textBox2_Leave(object sender, EventArgs e)
        {
            text2_changed = (text2 == textBox2.Text) ? false : true;
            text2 = textBox2.Text;

            if (text2_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string text3 = "";
        bool text3_changed = false;

        private void textBox3_Leave(object sender, EventArgs e)
        {
            text3_changed = (text3 == textBox3.Text) ? false : true;
            text3 = textBox3.Text;

            if (text3_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string text4 = "";
        bool text4_changed = false;

        private void textBox4_Leave(object sender, EventArgs e)
        {
            text4_changed = (text4 == textBox4.Text) ? false : true;
            text4 = textBox4.Text;

            if (text4_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string text5 = "";
        bool text5_changed = false;

        private void textBox5_Leave(object sender, EventArgs e)
        {
            text5_changed = (text5 == textBox5.Text) ? false : true;
            text5 = textBox5.Text;

            if (text5_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string text6 = "";
        bool text6_changed = false;

        private void textBox6_Leave(object sender, EventArgs e)
        {
            text6_changed = (text6 == textBox6.Text) ? false : true;
            text6 = textBox6.Text;

            if (text6_changed)
            {
                refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        public void refreshListing(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            treeView1.Nodes.Clear();

            if(text1 == "" && text2 == "" && text3 == "" && text4 == "" && text5 == "" && text6 == "")
            {
                
            }else
            {
                string[,,] filtered_list = f.filter_list(sorted_logs, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);

                for (int i = 0; i < filtered_list.GetLength(0); i++ )
                {
                    treeView1.Nodes.Add(file_directories[i]);

                    for (int j = 0; j < filtered_list.GetLength(1); j++)
                    {
                        if (filtered_list[i, j, 0] != null)
                        {
                            string node_row = "";
                            if (filtered_list[i, j, 2] != "WARN")
                            {
                                node_row = filtered_list[i, j, 0].PadRight(12) + filtered_list[i, j, 1].PadRight(9) + filtered_list[i, j, 4].PadRight(26) + filtered_list[i, j, 5].PadRight(26) + filtered_list[i, j, 6].PadRight(16) + filtered_list[i, j, 7].PadRight(33);
                            }else
                            {
                                node_row = filtered_list[i, j, 0].PadRight(12) + filtered_list[i, j, 1].PadRight(9) + filtered_list[i, j, 4].PadRight(52) + filtered_list[i, j, 6].PadRight(56);
                            }
                            
                            treeView1.Nodes[i].Nodes.Add(node_row);

                            if(filtered_list[i, j, 2] == "WARN")
                            {
                                treeView1.Nodes[i].Nodes[j].BackColor = Color.FromArgb(150, Color.Red);
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //f.filter_list(sorted_logs, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            refreshListing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
        }
    }
}
