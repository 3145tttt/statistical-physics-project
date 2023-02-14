using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace statphys
{
    public partial class Form2 : Form
    {
        Form3 author;
        Form1 model;
        public Form2()
        {
            InitializeComponent();
            author = new Form3(this);
            model = new Form1(this);
        }

        private void Button_author_Click(object sender, EventArgs e)
        {
            author.Show();
            Hide();
        }

        private void Button_model_Click(object sender, EventArgs e)
        {
            model.Show();
            Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + "/Теория.pdf";
            ProcessStartInfo proc = new ProcessStartInfo(file);
            proc.UseShellExecute = true;
            Process.Start(proc);
        }
    }
}
