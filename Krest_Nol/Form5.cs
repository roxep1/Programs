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
    public partial class Form5 : Form
    {
        Panel panel = new Panel();
        Label label = new Label();
        Button send = new Button();
        ProgressBar bar = new ProgressBar();
        int win = 0;
        int now = 0;

        Quest Now
        {
            get
            {
                return quests[now];
            }
        }
        class Quest
        {
            public string quest
            {
                get
                {
                    StreamReader reader = new StreamReader($@"D:\Prak\{Num}.txt");
                    string st = reader.ReadLine();
                    reader.Close();
                    return st;
                }
            }
            public int answer
            {
                get
                {
                    StreamReader reader = new StreamReader($@"D:\Prak\{Num}.txt");
                    reader.ReadLine();
                    int rez = int.Parse(reader.ReadLine());
                    reader.Close();
                    return rez;
                }
            }
            public string this[int index]
            {
                get
                {
                    StreamReader reader = new StreamReader($@"D:\Prak\{Num}.txt");
                    reader.ReadLine();
                    for (int i = 0; i < index; i++)
                        reader.ReadLine();
                    string rez = reader.ReadLine();
                    reader.Close();
                    return rez;
                }
            }
            public int Num { get; }
            public Quest(int Num)
            {
                this.Num = Num;
            }
        }
        List<Quest> quests = new List<Quest>();
        public Form5()
        {
            InitializeComponent();
            panel.BackColor = Color.BurlyWood;
            panel.Size = this.Size;
            this.Controls.Add(panel);
            Random rnd = new Random();
            List<int> check = new List<int>();
            int num;
            while (check.Count != 10)
            {
                num = rnd.Next(1, 11);
                if (!check.Contains(num))
                {
                    check.Add(num);
                    quests.Add(new Quest(num));
                }
            }

            label.Font = new Font("Microsoft Sans Serif", 15);
            label.Location = new Point(0, 0);
            label.AutoSize = true;

            send.Text = "Отправить";
            send.Location = new Point(this.Width - 50 - send.Width, this.Height / 2);
            send.Click += Send_Click;

            bar.Height = 25;
            bar.Location = new Point(Width / 2 - bar.Width / 2, Height - bar.Height * 2);
            bar.Maximum = 10;
            bar.Value = 0;

            Button button = new Button
            {
                Text = "Уходим",
                AutoSize = true
            };
            button.Location = new Point(Width - button.Width * 2, Height - button.Height * 3);
            button.Click += Button_Click;
            
            panel.Controls.Add(label);
            panel.Controls.Add(send);
            panel.Controls.Add(bar);
            panel.Controls.Add(button);

            Updater();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            Close();
        }

        bool isChecked
        {
            get
            {
                bool check = false;
                switch (Now.Num)
                {
                    case 7:
                        bool yes = false;
                        bool eles = false;
                        foreach (CheckBox rb in (panel.Controls[panel.Controls.Count - 1] as Panel).Controls)
                            if (rb.Checked)
                            {
                                if ((panel.Controls[panel.Controls.Count - 1] as Panel).Controls.IndexOf(rb) == Now.answer - 1)
                                    yes = true;
                                else
                                    eles = true;
                            }
                        if (yes && !eles)
                            win++;
                        foreach (CheckBox rb in (panel.Controls[panel.Controls.Count - 1] as Panel).Controls)
                            if (rb.Checked)
                            {
                                check = true;
                                bar.Value++;
                                break;
                            }
                        break;
                    default:
                        for (int i = 0; i < 4; i++)
                        {
                            RadioButton rb = ((panel.Controls[panel.Controls.Count - 1] as Panel).Controls[i]) as RadioButton;
                            if (rb.Checked)
                            {
                                check = true;
                                bar.Value++;
                                if ((panel.Controls[panel.Controls.Count - 1] as Panel).Controls.IndexOf(rb) == Now.answer - 1)
                                    win++;
                                break;
                            }
                        }
                        break;
                }

                return check;
            }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            if (isChecked)
            {
                panel.Controls.RemoveAt(panel.Controls.Count - 1);
                now++;
                if (now > 9)
                    End();
                else
                    Updater();
            }
        }
        private void End()
        {
            panel.Controls.Remove(send);
            label.Text = $"Ваш результат {win} из 10! Поздравляю!";
        }
        private void Updater()
        {
            label.Text = Now.quest;
            Panel n_pan = new Panel
            {
                Location = new Point(0, Height / 10),
                AutoSize = true
            };
            switch (Now.Num)
            {
                case 2:
                    for (int i = 0; i < 4; i++)
                    {
                        RadioButton rd = new RadioButton
                        {
                            Location = new Point(0, 50 + 100 * i),
                            AutoSize = true
                        };
                        n_pan.Controls.Add(rd);
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        PictureBox rd = new PictureBox
                        {
                            Location = new Point(50, 100 * i),
                            Size = new Size(100, 100),
                            ImageLocation = $@"D:\Prak\{i + 1}.jpg",
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };
                        n_pan.Controls.Add(rd);
                    }
                    break;
                case 7:
                    for (int i = 0; i < 4; i++)
                    {
                        CheckBox rd = new CheckBox
                        {
                            Location = new Point(0, 50 * i),
                            Text = Now[i + 1],
                            AutoSize = true
                        };
                        n_pan.Controls.Add(rd);
                    }
                    break;
                default:
                    for (int i = 0; i < 4; i++)
                    {
                        RadioButton rd = new RadioButton
                        {
                            Location = new Point(0, 50 * i),
                            Text = Now[i + 1],
                            AutoSize = true
                        };
                        n_pan.Controls.Add(rd);
                    }
                    break;
            }
            panel.Controls.Add(n_pan);
        }
    }
}