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
    public partial class Form8 : Form
    {
        Bitmap bit;
        int x = 0, y = 0;
        public Form8()
        {
            InitializeComponent();
            bit = new Bitmap(pic.Width, pic.Height);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p = new Pen(color.BackColor, trackBar.Value);
            p.DashCap = System.Drawing.Drawing2D.DashCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Graphics g = Graphics.FromImage(bit);
            if (e.Button == MouseButtons.Left)
            {
                if (line.Checked)
                {
                    g.DrawLine(p, x, y, e.X, e.Y);
                }
                if (rec.Checked)
                {
                    g.DrawRectangle(p, e.X, e.Y, 100, 100);
                }
                if (kru.Checked)
                {
                    g.DrawEllipse(p, e.X, e.Y, 100, 100);
                }
                if (tri.Checked)
                {
                    g.DrawPolygon(p, new List<Point> { new Point(e.X, e.Y), new Point(e.X - 50, e.Y + 50), new Point(e.X+50, e.Y+50) }.ToArray());
                }
                if (six.Checked)
                {
                    List<Point> points = new List<Point>();
                    points.Add(new Point(e.X, e.Y));
                    points.Add(new Point(e.X - 25, e.Y + 25));
                    points.Add(new Point(e.X, e.Y + 50));
                    points.Add(new Point(e.X + 25, e.Y + 50));
                    points.Add(new Point(e.X + 50, e.Y + 25));
                    points.Add(new Point(e.X + 25, e.Y));
                    g.DrawPolygon(p, points.ToArray());
                }
                if (eght.Checked)
                {
                    List<Point> points = new List<Point>();
                    points.Add(new Point(e.X, e.Y));
                    points.Add(new Point(e.X - 25, e.Y + 25));
                    points.Add(new Point(e.X - 25, e.Y + 50));
                    points.Add(new Point(e.X, e.Y + 75));
                    points.Add(new Point(e.X + 25, e.Y + 75));
                    points.Add(new Point(e.X + 50, e.Y + 50));
                    points.Add(new Point(e.X + 50, e.Y + 25));
                    points.Add(new Point(e.X + 25, e.Y));
                    g.DrawPolygon(p, points.ToArray());
                }
                if (LASTK.Checked)
                {
                    p.Color = SystemColors.Control;
                    g.DrawLine(p, x, y, e.X, e.Y);
                }
                pic.Image = bit;
                
            }
            x = e.X;
            y = e.Y;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bit);
            g.Clear(SystemColors.Control);
            pic.Image = bit;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            if(!String.IsNullOrEmpty(save.FileName))
            {
                bit.Save(save.FileName);
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
                    bit = (Bitmap)Image.FromFile(open.FileName);
                    pic.Image = bit;
                }
            }
            catch { }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            Close();
        }

        private void color_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            color.BackColor = colorDialog.Color;
        }
    }
}
