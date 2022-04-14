using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Graph;
using Syncfusion.Windows.Forms.Tools;

namespace Krest_Nol
{
    public partial class Form3 : Form
    {
        CalculatorControl calc = new CalculatorControl();
        bool isFirst = true;
        string second = "";
        string Nums
        {
            get
            {
                if (isFirst)
                    return NumTxtIng.Text;
                else
                    return second;
            }
            set
            {
                try
                {
                    if (!String.IsNullOrEmpty(value) && !value.Contains(","))
                        double.Parse(value);
                    if (isFirst)
                        NumTxtIng.Text = value;
                    else
                        second = value;
                }
                catch { }
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Controls.Add(calc);
            Ing0.Click += button36_Click;
            Ing2.Click += button36_Click;
            Ing3.Click += button36_Click;
            Ing4.Click += button36_Click;
            Ing5.Click += button36_Click;
            Ing6.Click += button36_Click;
            Ing7.Click += button36_Click;
            Ing8.Click += button36_Click;
            Ing9.Click += button36_Click;
            Multi.Click += Divide_Click;
            Plus.Click += Divide_Click;
            Minus.Click += Divide_Click;
            Pow.Click += Divide_Click;
            Prog2.Click += Prog1_Click;
            Prog3.Click += Prog1_Click;
            Prog4.Click += Prog1_Click;
            Prog5.Click += Prog1_Click;
            Prog6.Click += Prog1_Click;
            Prog7.Click += Prog1_Click;
            Prog8.Click += Prog1_Click;
            Prog9.Click += Prog1_Click;
            Prog0.Click += Prog1_Click;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            Nums += (sender as Button).Text;
        }

        private void Dot_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums))
                Nums += (sender as Button).Text;
        }

        private void PlusMinus_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums) && 1 * double.Parse(Nums) != 0)
            {
                string txt = Nums;
                if (double.Parse(Nums) > 0)
                {
                    Nums = "-" + txt;
                }
                else
                {
                    Nums = txt.Substring(1);
                }
            }
        }

        private void BackSpace_Click(object sender, EventArgs e)
        {
            Nums = "";
        }

        private void sqrBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums))
                Nums = Math.Pow(double.Parse(Nums), 2).ToString();
        }

        private void Pow3_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums))
                Nums = Math.Pow(double.Parse(Nums), 3).ToString();
        }

        private void Pow1_2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums))
                Nums = Math.Sqrt(double.Parse(Nums)).ToString();
        }

        private void Modul_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Nums))
                if (double.Parse(Nums) < 0)
                {
                    Nums = Nums.Substring(1);
                }
        }

        private void pi_Click(object sender, EventArgs e)
        {
            Nums = Math.PI.ToString();
        }

        private void E_Click(object sender, EventArgs e)
        {
            Nums = Math.E.ToString();
        }

        private void TenPow_Click(object sender, EventArgs e)
        {
            try
            {
                Nums = Math.Pow(10, double.Parse(Nums)).ToString();
            }
            catch { }
        }

        private void TwoPow_Click(object sender, EventArgs e)
        {
            try
            {
                Nums = Math.Pow(2, double.Parse(Nums)).ToString();
            }
            catch { }
        }

        private void Ln_Click(object sender, EventArgs e)
        {
            try
            {
                Nums = Math.Log(double.Parse(Nums)).ToString();
            }
            catch { }
        }

        private void Log10_Click(object sender, EventArgs e)
        {
            try
            {
                Nums = Math.Log10(double.Parse(Nums)).ToString();
            }
            catch { }
        }

        private void Fact_Click(object sender, EventArgs e)
        {
            try
            {
                int num = 1;
                for (int i = 1; i <= int.Parse(Nums); i++)
                {
                    num *= i;
                }
                Nums = num.ToString();
            }
            catch { }
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NumTxtIng.Text))
                isFirst = false;
            Znak.Text = (sender as Button).Text;
        }

        private void equal_Click(object sender, EventArgs e)
        {
            try
            {
                double num1 = double.Parse(NumTxtIng.Text);
                double num2 = double.Parse(second);
                double rez = 0;
                switch (Znak.Text)
                {
                    case "/":
                        rez = num1 / num2;
                        break;
                    case "*":
                        rez = num1 * num2;
                        break;
                    case "-":
                        rez = num1 - num2;
                        break;
                    case "+":
                        rez = num1 + num2;
                        break;
                    case "^":
                        rez = Math.Pow(num1, num2);
                        break;
                }
                Znak.Text = "";
                isFirst = true;
                second = "";
                NumTxtIng.Text = rez.ToString();
            }
            catch { }
        }

        private void Prog1_Click(object sender, EventArgs e)
        {
            ProgTxt.Text += (sender as Button).Text;
        }

        private void ProgDel_Click(object sender, EventArgs e)
        {
            ProgTxt.Text = "";
            SS2.Text = "";
            SS8.Text = "";
            SS16.Text = "";
        }

        private void ProgEqual_Click(object sender, EventArgs e)
        {
            try
            {
                SS2.Text = Convert.ToString(int.Parse(ProgTxt.Text), 2);
                SS8.Text = Convert.ToString(int.Parse(ProgTxt.Text), 8);
                SS16.Text = Convert.ToString(int.Parse(ProgTxt.Text), 16);
            }
            catch { }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Owner.Visible = true;
            Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            IntYear.Text = "";
            IntMonth.Text = "";
            IntDay.Text = "";
            IntAllDays.Text = "";
            StYear.Text = "";
            StMonth.Text = "";
            StDays.Text = "";
            StAllDays.Text = "";
            int check = DateTime.Compare(Date1.Value.Date, Date2.Value.Date);
                if (check > 0)
                    DoDate(Date1.Value.Date, Date2.Value.Date);
                else
                    DoDate(Date2.Value.Date, Date1.Value.Date);
        }

        private void DoDate(DateTime big, DateTime small)
        {
            TimeSpan span = big - small;
            IntYear.Text = (span.Days / 365).ToString();
            int month = int.Parse(Math.IEEERemainder(span.Days, 365).ToString()) / 30;
            if (month < 0)
                month = 12 + month;
            IntMonth.Text = month.ToString();
            int days = int.Parse(Math.IEEERemainder(int.Parse(Math.IEEERemainder(span.Days, 365).ToString()), 30).ToString());
            if (days < 0)
                days = 30 + days;
            IntDay.Text = days.ToString();
            IntAllDays.Text = span.Days.ToString();
            CheckSklon("лет", "год", "года", IntYear, StYear);
            CheckSklon("месяцев", "месяц", "месяца", IntMonth, StMonth);
            CheckSklon("дней", "день", "дня", IntDay, StDays);
            CheckSklon("дней", "день", "дня", IntAllDays, StAllDays);
        }
        private void CheckSklon(string Nol, string One, string Two, Label LInt, Label LSt)
        {
            bool isLet = false;
            for (int i = 11; i <= 19; i++)
            {
                if (int.Parse(LInt.Text) == i)
                {
                    isLet = true;
                    break;
                }
            }
            if (isLet)
                LSt.Text = Nol;
            else
            {
                switch (int.Parse(LInt.Text.Last().ToString()))
                {
                    case 0:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case
                    9:
                        LSt.Text = Nol;
                        break;
                    case 1:
                        LSt.Text = One;
                        break;
                    case 2:
                    case 3:
                    case 4:
                        LSt.Text = Two;
                        break;
                }
            }
        }
    }
}
