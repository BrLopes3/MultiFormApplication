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

namespace WindowsFormStartProject
{
    public partial class Lotto649 : Form
    {
        public Lotto649()
        {
            InitializeComponent();
        }
        
        string path = @".\Files\LottoNbrs.txt";
        FileStream fs = null;

        private void button1_Click(object sender, EventArgs e)
        {
            //creation of extra 7 numbers generated bellow the picture
            Random random1 = new Random(); //constructor of the obj random1
            int tempNumber;
            string tempString = "";
            int[] randomNumber1 = new int[7]; //creating an array with random numbers

            for (int i = 0; i < 7; i++)
            {

                tempNumber = random1.Next(1, 9);
                randomNumber1[i] = tempNumber; //variable randomNumber1 is equal to the obj random1 with a random number between 0 and 9
                tempString += randomNumber1[i].ToString(); //variable randomNumber1 converted to string 

            }
            label2.Text = tempString; //display the variable at label 2
            tempString = ""; //clear the string for the next generation of numbers

            //creation of the main 7 random numbers 

            Random random = new Random(); //constructor of the obj random
            string tempLoto = "";
            List<int> randomNumber = new List<int>(); //creating a list with random numbers

            for (int i = 0; i < 6; i++)
            {
                int rand = random.Next(1, 49); //generate the random number
                if (!randomNumber.Contains(rand)) //if the random number is not in the list already
                {
                    randomNumber.Add(rand); //add the random number in the list
                    tempLoto += randomNumber[i].ToString() + "\t"; //store the number in the variable that will be printed in the textbox
                }
                else
                {
                    i = i - 1; //if the number generated already exists in the list, the counter back to try again

                }

            }
            //bonus number
            string tempBonus = "";
        label1: int numBonus = random.Next(1, 49);
            if (!randomNumber.Contains(numBonus)) //compare the bonus number with all other 7 numbers in the list
            {
                randomNumber.Add(numBonus);
                tempBonus = numBonus.ToString();
            }
            else
            {
                goto label1;
            }


            textBox1.Text = tempLoto + tempBonus; //display the numbers at the textbox 1
            string txtFile = tempLoto + $" Bonus {tempBonus}"; //line of text that will be printed in a txt file

            tempLoto = ""; //clear the string for the next generation of numbers
            tempBonus = "";

            //save the numbers in a text file

            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter txt2 = new StreamWriter(fs);

            string print = txtFile.Replace("\t", ","); //change the text in the txt file, replacing the tabs for ,


            txt2.Write("649, " + DateTime.Now + " " + print + "\n"); //printing in the txt file
            txt2.Close();
            txt2.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = "Previous Numbers Generated";
            string textToPrint = "";
            FileStream stream = null;
            byte counter = 0;

            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader txt = new StreamReader(stream);
                while (txt.Peek() != -1)
                {
                    string prevNumbers = txt.ReadLine();
                    textToPrint += prevNumbers + "\n";
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
            if (MessageBox.Show("Do you want to close the Lotto649 ? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}
