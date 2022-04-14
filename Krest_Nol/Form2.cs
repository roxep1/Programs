using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krest_Nol
{
    public partial class Form2 : Form
    {
        int X
        {
            get
            {
                return int.Parse(ScoreX.Text);
            }
            set
            {
                ScoreX.Text = value.ToString();
            }
        }
        int O
        {
            get
            {
                return int.Parse(ScoreO.Text);
            }
            set
            {
                ScoreO.Text = value.ToString();
            }
        }
        List<Button> btns = new List<Button>();
        bool isX = true;
        List<List<int>> combos = new List<List<int>>
        {
            new List<int> {0, 1, 2},
            new List<int> {3, 4, 5},
            new List<int> {6, 7, 8},
            new List<int> {0, 3, 6},
            new List<int> {1, 4, 7},
            new List<int> {2, 5, 8},
            new List<int> {0, 4, 8},
            new List<int> {2, 4, 6}
        };
        bool End = false;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            string XO;
            if (isX)
                XO = "X";
            else
                XO = "O";
            Print(sender as Button, XO, false);
            if (IsWin(XO))
                Win(XO);
            if (IsDraw())
                Draw();
            isX = !isX;
        }
        private void Print(Button btn, string XO, bool Switcher)
        {
            btn.Text = XO;
            btn.Enabled = Switcher;
        }
        private bool IsWin(string XO)
        {
            foreach (List<int> combo in combos)
            {
                int check = 0;
                foreach (int i in combo)
                {
                    if (XO == btns[i].Text)
                    {
                        check++;
                    }
                }
                if (check == 3)
                    return true;
            }
            return false;
        }
        private bool IsDraw()
        {
            if (!End)
            {
                foreach (Button btn in btns)
                {
                    if (btn.Enabled == true)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        private void Draw()
        {
            EndTrue("Ничья!");
        }
        private void Win(string XO)
        {
            EndTrue("Победил " + XO + "!");
            if (XO == "X")
                X++;
            else
                O++;
        }
        private void EndTrue(string txt)
        {
            End = true;
            foreach (Button btn in btns)
            {
                btn.Enabled = false;
            }
            WinTxt.Text = txt;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            WinTxt.Text = "";
            foreach (Button btn in btns)
                Print(btn, "", true);
            End = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btns.Add(button1);
            btns.Add(button2);
            btns.Add(button3);
            btns.Add(button4);
            btns.Add(button5);
            btns.Add(button6);
            btns.Add(button7);
            btns.Add(button8);
            btns.Add(button9);
            foreach (Button btn in btns)
            {
                btn.Click += Btn_Click;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            Close();
        }
    }
}
