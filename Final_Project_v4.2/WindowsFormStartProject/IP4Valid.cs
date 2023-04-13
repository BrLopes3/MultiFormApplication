using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormStartProject
{
    public partial class IP4Valid : Form
    {
        public IP4Valid()
        {
            InitializeComponent();
        }
        private bool validIP(string ip)
        {
            Regex myRegex = new Regex(@"^(25[0-5]|2[0-4]\d|[0-1]?\d?\d)(\.(25[0-5]|2[0-4]\d|[0-1]?\d?\d)){3}$");
            return myRegex.IsMatch(ip);
        }

        DateTime load;
        private void IP4Valid_Load(object sender, EventArgs e) //form loaded
        {
            DateTime today = DateTime.Now; //time that the form is loaded
            label1.Text = $"Today: {today}";
            load = DateTime.Now;

            if (Directory.Exists(@".\Files\") == false) //if the file does not exist it is created
            {
                Directory.CreateDirectory(@".\Files\");
            }


        }

        string pathBinary = @".\Files\BIP.dat"; //global variable with the path for the file

        private void button1_Click(object sender, EventArgs e)
        {
            if (validIP(textBox1.Text) == false)
            {
                MessageBox.Show($"{textBox1.Text}\nThe IP must have 4 bytes\ninteger number between 0 to 255\nseparated by a dot(255.255.255.255)","Error");
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show($"{textBox1.Text}\nThe IP is correct", "Valid IP");

                FileStream fs = null;  //declaration of the file
                fs = new FileStream(pathBinary, FileMode.Append, FileAccess.Write);
                // create the output stream for a binary file
                BinaryWriter bw = new BinaryWriter(fs);
                string ipValid = textBox1.Text.Trim();

                bw.Write($"{ipValid}, {DateTime.Now}"); //write the IP validated and the time in a dat file

                bw.Close();
                fs.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TimeSpan timeSpent = new TimeSpan();
            timeSpent = DateTime.Now.Subtract(load); //interval between the time the form was loaded and the form required to close.
            string ts = $"{timeSpent.Minutes:D2}min:{timeSpent.Seconds:D2}s";


            if (MessageBox.Show($"You spent {ts} in this application.\nDo you want to quit the application IP Validator?", "Exit ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
