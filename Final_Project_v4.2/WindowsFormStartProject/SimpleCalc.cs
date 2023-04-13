using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormStartProject
{

    public partial class SimpleCalc : Form
    {
        
        public SimpleCalc()
        {
            InitializeComponent();
        }

        string path = @".\Files\Calculator.txt";
        FileStream fs = null;

        //Constructor
        Calculator calculator = new Calculator(); 

        private void button1_Click(object sender, EventArgs e)
        {

            textBox1.Text = $"{textBox1.Text}1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = $"{textBox1.Text}0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bool hasPoint = Regex.IsMatch(textBox1.Text, @"\."); //regex to verify if already exist some "." in the number. It is allowed only one "." for each number. 
            if(hasPoint == false)
            {
                textBox1.Text = $"{textBox1.Text}.";
            }
            
        }

        
        
        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == ".")
            {
                MessageBox.Show("Enter with a number first");
            }
            else
            {
                calculator.Op = "+";
                calculator.Operand1 = Convert.ToDecimal(textBox1.Text);
                label1.Text = calculator.Operand1.ToString() + " " + calculator.Op;
                textBox1.Clear();
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == ".")
            {
                MessageBox.Show("Enter with a number first");
            }
            else
            {
                calculator.Op = "-";
                calculator.Operand1 = Convert.ToDecimal(textBox1.Text);
                label1.Text = calculator.Operand1.ToString() + " " + calculator.Op;
                textBox1.Clear();
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == ".")
            {
                MessageBox.Show("Enter with a number first");
            }
            else
            {
                calculator.Op = "*";
                calculator.Operand1 = Convert.ToDecimal(textBox1.Text);
                label1.Text = calculator.Operand1.ToString() + " " + calculator.Op;
                textBox1.Clear();
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == ".")
            {
                MessageBox.Show("Enter with a number first");
            }
            else
            {
                calculator.Op = "/";
                calculator.Operand1 = Convert.ToDecimal(textBox1.Text);
                label1.Text = calculator.Operand1.ToString() + " " + calculator.Op;
                textBox1.Clear();
                button12.Enabled = false;
                button13.Enabled = false;
                button14.Enabled = false;
                button15.Enabled = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            calculator.Operand2 = Convert.ToDecimal(textBox1.Text);
            switch (calculator.Op)
            {
                case "+":
                    {
                        
                        textBox1.Text = calculator.Add().ToString();
                        label1.Text = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = {calculator.CurrentValue}";
                        textBox1.Text = calculator.CurrentValue.ToString();
                        break;
                    }
                case "-":
                    {
                        textBox1.Text = calculator.Subtract().ToString();
                        label1.Text = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = {calculator.CurrentValue}";
                        textBox1.Text = calculator.CurrentValue.ToString();
                        break;
                    }
                case "*":
                    {
                        textBox1.Text = calculator.Multiply().ToString();
                        label1.Text = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = {calculator.CurrentValue}";
                        textBox1.Text = calculator.CurrentValue.ToString();
                        break;
                    }
                case "/":
                    {
                        if(calculator.Operand2 != 0)
                        {
                            textBox1.Text = calculator.Divide().ToString();
                            label1.Text = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = {calculator.CurrentValue}";
                            textBox1.Text = calculator.CurrentValue.ToString();
                        }
                        else
                        {
                            label1.Text = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = NaN";
                            textBox1.Clear();
                        }
                        
                        break;
                    }
            }
            //liberate the operation numbers
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;

            //save the conversions in a text file

            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter txt = new StreamWriter(fs);

            //StreamWriter txt = new StreamWriter(@".\Files\Calculator.txt", true); //path where will be generated the text file

            string print = $"{calculator.Operand1} {calculator.Op} {calculator.Operand2} = {calculator.CurrentValue}"; //creating the string to save in the txt file,


            txt.Write($"{print}\n"); //printing in the txt file
            txt.Close();
            txt.Dispose();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            textBox1.Clear();
            calculator.Operand1 = 0;
            calculator.Operand2 = 0;
            calculator.CurrentValue = 0;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the application Simple Calculator?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
