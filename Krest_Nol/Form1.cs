using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krest_Nol
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2
            {
                Owner = this
            };
            f2.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3
            {
                Owner = this
            };
            f3.Show();
            Visible = false;
        }

        private void CalcDate_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(5)
            {
                Owner = this
            };
            f4.Show();
            Visible = false;
        }

        private void test_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5
            {
                Owner = this
            };
            f5.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6
            {
                Owner = this
            };
            f6.Show();
            Visible = false;
        }

        private void mail_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7
            {
                Owner = this
            };
            f.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8
            {
                Owner = this
            };
            f.Show();
            Visible = false;
        }

        private void word_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9
            {
                Owner = this
            };
            f.Show();
            Visible = false;
        }
    }
}
