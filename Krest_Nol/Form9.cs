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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            shrift.Text = fontDialog.Font.Name;
            rich.Font = fontDialog.Font;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            colorDialogText.ShowDialog();
            colortxt.BackColor = colorDialogText.Color;
            rich.SelectionColor = colorDialogText.Color;
        }

        private void colorfon_Click(object sender, EventArgs e)
        {
            colorDialogFon.ShowDialog();
            colorfon.BackColor = colorDialogFon.Color;
            rich.BackColor = colorDialogFon.Color;
        }

        private void shrift_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
            rich.Font = fontDialog.Font;
            shrift.Text = fontDialog.Font.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rich.SelectionFont = new Font(rich.SelectionFont.FontFamily, int.Parse((sender as TextBox).Text));
            }
            catch 
            {
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (rich.Font.Italic)
                rich.Font = new Font(rich.Font, FontStyle.Regular);
            else
                rich.Font = new Font(rich.Font, FontStyle.Italic);
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rich.Font.Bold)
                rich.Font = new Font(rich.Font, FontStyle.Regular);
            else
                rich.Font = new Font(rich.Font, FontStyle.Bold);
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            if (!String.IsNullOrEmpty(save.FileName))
            {
                rich.SaveFile(save.FileName);
            }

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                if (!String.IsNullOrEmpty(open.FileName))
                {
                    rich.LoadFile(open.FileName);
                }
            }
            catch { }
        }

        private void выйтиКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            Close();
        }

        private void left_Click(object sender, EventArgs e)
        {
            rich.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void mid_Click(object sender, EventArgs e)
        {
            rich.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void right_Click(object sender, EventArgs e)
        {
            rich.SelectionAlignment = HorizontalAlignment.Right;
        }
    }
}
