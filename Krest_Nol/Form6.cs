using Microsoft.Graph;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krest_Nol
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            web.Navigated += Web_Navigated;
            web.FileDownload += Web_FileDownload;
            web.CanGoBackChanged += Web_CanGoBackChanged;
            web.CanGoForwardChanged += Web_CanGoForwardChanged;
            web.Navigate("https://www.google.com/");
        }

        private void Web_CanGoForwardChanged(object sender, EventArgs e)
        {
            forward.Enabled = !forward.Enabled;
        }

        private void Web_CanGoBackChanged(object sender, EventArgs e)
        {
            back.Enabled = !back.Enabled;
        }

        private void Web_FileDownload(object sender, EventArgs e)
        {
            try
            {
                if (web.Document != null)
                {
                    StreamWriter writer = new StreamWriter(@"D:\Prak\brauz\Downloads.txt", true);
                    writer.WriteLine(web.Document.Url + DateTime.Now.ToString());
                    writer.Close();
                }
            }
            catch { }
        }

        private void Web_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            StreamWriter writer = new StreamWriter(@"D:\Prak\brauz\History.txt", true);
            writer.WriteLine(e.Url + DateTime.Now.ToString());
            writer.Close();
            search.Text = e.Url.ToString();
        }

        private void search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    web.Navigate(new Uri(search.Text));
                }
                catch
                {
                    web.Navigate(new Uri($"https://www.google.com/search?q={search.Text}"));
                }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            web.GoBack();
        }

        private void forward_Click(object sender, EventArgs e)
        {
            web.GoForward();
        }

        private void hist_Click_1(object sender, EventArgs e)
        {
            work(@"D:\Prak\brauz\History.txt", true);
        }

        private void hist_clear_Click(object sender, EventArgs e)
        {
            work(@"D:\Prak\brauz\History.txt", false);
        }

        private void downloads_Click(object sender, EventArgs e)
        {
            work(@"D:\Prak\brauz\Downloads.txt", true);
        }
        private void work(string path, bool isCheck)
        {
            Form dlg = new Form
            {
                AutoSize = true
            };
            dlg.Controls.Add(new Label { AutoSize = true });
            if (isCheck)
            {
                StreamReader reader = new StreamReader(path);
                (dlg.Controls[0] as Label).Text = reader.ReadToEnd();
                reader.Close();
            }
            else
            {
                StreamWriter writer = new StreamWriter(path, false);
                writer.Close();
                dlg.Controls.Add(new Label { Text = "Успешно!" });
            }
            dlg.ShowDialog();
        }

        private void downloads_clear_Click(object sender, EventArgs e)
        {
            work(@"D:\Prak\brauz\Downloads.txt", false);
        }

        private void GOBack_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            Close();
        }
    }
}
