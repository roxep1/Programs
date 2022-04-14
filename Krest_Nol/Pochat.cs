using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Krest_Nol
{
    public partial class Pochat : Form
    {
        Form7.User ur = new Form7.User();
        public Pochat(Form7.User user)
        {
            InitializeComponent();
            ur = user;
        }
        private void SendBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //isip_k.v.volk @mpt.ru
                MailMessage message = new MailMessage(new MailAddress(ur.Mail, "Test"), new MailAddress(ForWho.Text));
                message.Subject = Header.Text;
                message.Body = Body.Text;
                message.IsBodyHtml = true;
                ur.Send.Send(message);
                Dialog("Отправка прошла успешно!");
            }
            catch (Exception ex)
            {
                Dialog("Отправка не удалась ;(\n" + ex.Message);
            }
        }
        static public void Dialog(string stroka)
        {
            Form f = new Form
            {
                AutoSize = true
            };
            f.Controls.Add(new Label { Text = stroka, AutoSize = true });
            f.ShowDialog();
        }

        private void back_Click(object sender, EventArgs e)
        {
            Owner.Visible = true;
            Close();
        }
    }
}
