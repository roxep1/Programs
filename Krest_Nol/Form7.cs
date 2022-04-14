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
using System.Security.Cryptography.X509Certificates;

namespace Krest_Nol
{
    public partial class Form7 : Form
    {
        public class User
        {
            public string Mail { get; set; }
            public string Password { get; set; }
            public SmtpClient Send { get; set; }
            public bool IsLoged = false;
            public User()
            {
                Send = new SmtpClient();
            }
            public User(string mail, string pass)
            {
                Mail = mail;
                Password = pass;
                try
                {
                    Send = new SmtpClient();
                    Send.EnableSsl = true;
                    Send.Host = "smtp.gmail.com";
                    Send.Port = 587;
                    Send.Credentials = new NetworkCredential(mail, pass);
                    IsLoged = true;
                }
                catch (Exception e)
                {
                    IsLoged = false;
                    Pochat.Dialog("Не удалось войти в вашу почту. :/\n" + e.Message);
                }
            }
        }
        User user = new User();
        public Form7()
        {
            InitializeComponent();
        }   

        private void auth_Click(object sender, EventArgs e)
        {
            user = new User(login.Text, password.Text);
            if (user.IsLoged)
            {
                Pochat f = new Pochat(user)
                {
                    Owner = this
                };
                f.Show();
                Visible = false;
                login.Text = "";
                password.Text = "";
            }
        }
    }
}
