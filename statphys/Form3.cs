using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace statphys
{
    public partial class Form3 : Form
    {
        Form2 par_;
        public Form3(Form2 parent)
        {
            InitializeComponent();
            par_ = parent;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            par_.Show();
            Hide();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            par_.Close();
        }
    }
}
