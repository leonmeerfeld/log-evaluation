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


        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
        //    {
        //        listBox1.Items.AddRange(item);
        //    }
        //}

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
        //    {
        //        listBox1.Items.AddRange(item);
        //    }
        //}

        //private void textBox3_Leave(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
        //    {
        //        listBox1.Items.AddRange(item);
        //    }
        //}

        //private void textBox4_Leave(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
        //    {
        //        listBox1.Items.AddRange(item);
        //    }
        //}

        //private void textBox5_Leave(object sender, EventArgs e)
        //{
        //    listBox1.Items.Clear();
        //    foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
        //    {
        //        listBox1.Items.AddRange(item);
        //    }
        //}

        string text1 = "";
        bool text1_changed = false;

        private void textBox1_Leave(object sender, EventArgs e)
        {
            text1_changed = (text1 == textBox1.Text) ? false : true;
            text1 = textBox1.Text;

            if (text1_changed)
            {
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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
                refresh_listing(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
            }
        }

        string row_in_listbox;

        public void refresh_listing(string text1, string text2, string text3, string text4, string text5, string text6)
        {
            listBox1.Items.Clear();
            foreach (var item in f.filter_list(sorted_log_list, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text))
            {
                row_in_listbox = item[0].PadRight(12) + item[1].PadRight(9) + item[4].PadRight(26) + item[5].PadRight(24) + item[6].PadRight(15) + item[7].PadRight(33);
                listBox1.Items.Add(row_in_listbox);
            }
        }
    }
}
