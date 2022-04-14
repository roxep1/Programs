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
    public partial class Form4 : Form
    {
        int size;
        public Form4(int sz)
        {
            InitializeComponent();
            size = sz;
        }

        private void Form4_Shown(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
            bool check = true;
            for (int i = 0; i <= 500; i+= size)
            {
                for (int j = 0; j <= 75; j++)
                {
                    if (check)
                        myPath.AddRectangle(new Rectangle(j * 10, i, size, size));
                    else
                        myPath.AddRectangle(new Rectangle(j * 10 + size, i, size, size));
                    Region reg = new Region(myPath);
                    this.Region = reg;
                    System.Threading.Thread.Sleep(1);
                }
                check = !check;
            }
        }
    }
}
