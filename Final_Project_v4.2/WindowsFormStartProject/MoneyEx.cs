using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormStartProject
{
   
    public partial class MoneyEx : Form
    {
        public MoneyEx()
        {
            InitializeComponent();
        }

        string path = @".\Files\MoneyConv.txt";
        FileStream fs = null;

        private void button1_Click(object sender, EventArgs e)
        {
            double money_in = 0.00;
            try
            {
                money_in = Convert.ToDouble(textBox1.Text); // try and catch to check if the user input a number in the text box.
            }
            catch(Exception ex0)
            {
                MessageBox.Show(ex0.Message);
            }

            double money1 = money_in;
            double money2 = 0.00;
            string currency1 = "";
            string currency2 = "";
            

                if (radioButton1.Checked)
                {

                    double rate = 1;
                    currency1 = "CAD";
                    if (radioButton6.Checked)
                    {
                        rate = 1;
                        currency2 = "CAD";
                    }
                    if (radioButton7.Checked)
                    {
                        rate = 0.73;
                        currency2 = "USD";
                    }
                    if (radioButton8.Checked)
                    {
                        rate = 0.68;
                        currency2 = "EUR";
                    }
                    if (radioButton9.Checked)
                    {
                        rate = 0.59;
                        currency2 = "GBP";
                    }
                    if (radioButton10.Checked)
                    {
                        rate = 3.82;
                        currency2 = "BRL";
                    }
                    money2 = Math.Round(money1 * rate, 2);
                    textBox2.Text = $" {currency2} {money2.ToString()}";

                }
                if (radioButton2.Checked)
                {

                    double rate = 1;
                    currency1 = "USD";
                    if (radioButton6.Checked)
                    {
                        rate = 1.37;
                        currency2 = "CAD";
                    }
                    if (radioButton7.Checked)
                    {
                        rate = 1;
                        currency2 = "USD";
                    }
                    if (radioButton8.Checked)
                    {
                        rate = 0.93;
                        currency2 = "EUR";
                    }
                    if (radioButton9.Checked)
                    {
                        rate = 0.82;
                        currency2 = "GBP";
                    }
                    if (radioButton10.Checked)
                    {
                        rate = 5.25;
                        currency2 = "BRL";
                    }
                    money2 = Math.Round(money1 * rate, 2);
                    textBox2.Text = $" {currency2} {money2.ToString()}";

                }

                if (radioButton3.Checked)
                {

                    double rate = 1;
                    currency1 = "EUR";
                    if (radioButton6.Checked)
                    {
                        rate = 1.48;
                        currency2 = "CAD";
                    }
                    if (radioButton7.Checked)
                    {
                        rate = 1.08;
                        currency2 = "USD";
                    }
                    if (radioButton8.Checked)
                    {
                        rate = 1;
                        currency2 = "EUR";
                    }
                    if (radioButton9.Checked)
                    {
                        rate = 0.88;
                        currency2 = "GBP";
                    }
                    if (radioButton10.Checked)
                    {
                        rate = 5.65;
                        currency2 = "BRL";
                    }
                    money2 = Math.Round(money1 * rate, 2);
                    textBox2.Text = $" {currency2} {money2.ToString()}";

                }
                if (radioButton4.Checked)
                {

                    double rate = 1;
                    currency1 = "GBP";
                    if (radioButton6.Checked)
                    {
                        rate = 1.68;
                        currency2 = "CAD";
                    }
                    if (radioButton7.Checked)
                    {
                        rate = 1.22;
                        currency2 = "USD";
                    }
                    if (radioButton8.Checked)
                    {
                        rate = 1.14;
                        currency2 = "EUR";
                    }
                    if (radioButton9.Checked)
                    {
                        rate = 1;
                        currency2 = "GBP";
                    }
                    if (radioButton10.Checked)
                    {
                        rate = 6.43;
                        currency2 = "BRL";
                    }
                    money2 = Math.Round(money1 * rate, 2);
                    textBox2.Text = $" {currency2} {money2.ToString()}";

                }
                if (radioButton5.Checked)
                {

                    double rate = 1;
                    currency1 = "BRL";
                    if (radioButton6.Checked)
                    {
                        rate = 0.26;
                        currency2 = "CAD";
                    }
                    if (radioButton7.Checked)
                    {
                        rate = 0.19;
                        currency2 = "USD";
                    }
                    if (radioButton8.Checked)
                    {
                        rate = 0.18;
                        currency2 = "EUR";
                    }
                    if (radioButton9.Checked)
                    {
                        rate = 0.16;
                        currency2 = "GBP";
                    }
                    if (radioButton10.Checked)
                    {
                        rate = 1;
                        currency2 = "BRL";
                    }
                    money2 = Math.Round(money1 * rate, 2);
                    textBox2.Text = $" {currency2} {money2.ToString()}";

                }


            //save the numbers in a text file
            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter txt = new StreamWriter(fs);

            string print = $"{money1} {currency1} = {money2} {currency2}"; //change the text in the txt file, replacing the tabs for ,


            txt.Write($"{print}, { DateTime.Now}\n"); //printing in the txt file
            txt.Close();
            txt.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string title = "Previous Conversions";
            string textToPrint = "";
            FileStream stream = null;
            byte counter = 0;

            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader txt = new StreamReader(stream);
                while (txt.Peek() != -1)
                {
                    string prevConv = txt.ReadLine();
                    textToPrint += prevConv + "\n";
                    counter++;
                    if (counter == 12)
                    {
                        MessageBox.Show(textToPrint, title);
                        textToPrint = "";
                        counter = 0;
                    }
                }
                if (counter > 0) { MessageBox.Show(textToPrint, title); }

                txt.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("IO Exception\n" + ex.Message);
            }
            finally { if (stream != null) stream.Close(); }

        }
        DateTime dateOn; //variable that store the time the form is loaded
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            TimeSpan timeSpent = new TimeSpan();
            timeSpent = DateTime.Now.Subtract(dateOn); //interval between the time the form was loaded and the form required to close.
            string ts = $"{timeSpent.Minutes:D2}min:{timeSpent.Seconds:D2}s";


            if (MessageBox.Show($"You spent {ts} in this application.\nDo you want to quit the application Money Exchange?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }

        }

        private void MoneyEx_Load(object sender, EventArgs e)
        {
            DateTime time_on = new DateTime();
            dateOn = DateTime.Now;
            
        }
    }


}
