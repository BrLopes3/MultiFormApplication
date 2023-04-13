using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormStartProject
{
    public partial class TempConv : Form
    {
        public TempConv()
        {
            InitializeComponent();
            
        }
        string path = @".\Files\TempConv.txt";
        FileStream fs = null;

        private void button1_Click(object sender, EventArgs e)
        {
            double temp1=0; //create a variable for the first temperature
            double temp2=0; //create a variable for the temperature converter
            label5.Text = "";

            try
            {
                temp1 = Convert.ToDouble(textBox1.Text); //store the input in the first temperature
            }
            catch(Exception ex)
            {
                MessageBox.Show("Type a Temperature in correct format",ex.Message);
                textBox2.Text = "";
                textBox1.Text = "";
            }

            //creation of a dictionary for the message descriptions
            Dictionary<double, string> Coments = new Dictionary<double, string>();
            Coments.Add(100, "Water boils");
            Coments.Add(40, "Hot Bath");
            Coments.Add(37, "Body temperature");
            Coments.Add(30, "Beach weather");
            //Coments.Add(21, "Room temperature");
            Coments.Add(10, "Cool Day");
            Coments.Add(0, "Freezing point of water");
           //Coments.Add(-18, "Very Cold Day");
            Coments.Add(-40, "Extremely Cold Day\r\n(and the same number!)");



                if (textBox1.Text!="" && radioButton1.Checked)
                {
                    temp2 = Math.Round((temp1 * 9/5)+32,2); //convertion from C to F
                    textBox2.Text = temp2.ToString(); //display the result on the textbox 2

                    if (temp1 >= 20 && temp1 < 24)
                    {
                        Coments.Add(temp1, "Room temperature");
                    }
                    else if (temp1 >= -39 && temp1 < -15)
                    {
                        Coments.Add(temp1, "Very Cold Day");
                    }


                    foreach (KeyValuePair<double,string> t in Coments)
                    {
                        if(temp1 == t.Key)
                        {
                            if (temp1 >= 40)
                            {
                                label5.ForeColor = Color.Red;  
                                label5.Text = t.Value.ToString();
                            }
                            else if (temp1 >= 21)
                            {
                                label5.ForeColor = Color.Green;
                                label5.Text = t.Value.ToString();
                            }
                            else if (temp1 <= 10)
                            {
                                label5.ForeColor = Color.Blue;
                                label5.Text = t.Value.ToString();
                            }
                  
                        }
                    }
                    
                }
                if (textBox1.Text != "" && radioButton2.Checked)
                {
                    temp2 = Math.Round((temp1 - 32)*5/9,2); //convertion from C to F
                    textBox2.Text = temp2.ToString(); //display the result on the textbox 2

                    if (temp2>=20 && temp2 < 24)
                    {
                        Coments.Add(temp2, "Room temperature");
                    }
                    else if (temp2>=-20 && temp2 < -15)
                    {
                        Coments.Add(temp2, "Very Cold Day");
                    }
                    

                    foreach (KeyValuePair<double, string> t in Coments)
                    {
                        if (temp2 == t.Key)
                        {
                            if (temp2 >= 40)
                            {
                                label5.ForeColor = Color.Red;
                                label5.Text = t.Value.ToString();
                            }
                            else if (temp2 >= 21)
                            {
                                label5.ForeColor = Color.Green;
                                label5.Text = t.Value.ToString();
                            }
                            else if (temp2 <= 10)
                            {
                                label5.ForeColor = Color.Blue;
                                label5.Text = t.Value.ToString();
                            }
                        }
                    }

                }

            //save the conversions in a text file

            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter txt = new StreamWriter(fs);

            string print = $"{temp1} {label1.Text} = {temp2} {label2.Text}"; //change the text in the txt file, replacing the tabs for ,


            txt.Write($"{print}, {DateTime.Now} {label5.Text}\n"); //printing in the txt file
            txt.Close();
            txt.Dispose();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "C";
            label2.Text = "F";
            textBox2.Text = "";
            label5.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "F";
            label2.Text = "C";
            textBox2.Text = "";
            label5.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the application Temperature Conversion ?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void TempConv_Load(object sender, EventArgs e)
        {

        }
    }
}
