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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace WindowsFormStartProject
{
    public partial class LottoMAX : Form
    {
        public LottoMAX()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creation of extra 7 numbers generated bellow the picture
            Random random1 = new Random(); //constructor of the obj random1
            int tempNumber;
            string tempString = "";
            int[] randomNumber1 = new int[7]; //creating an array with random numbers

            for (int i = 0; i < 7; i++) {

                tempNumber = random1.Next(1,9);
                randomNumber1[i] = tempNumber; //variable randomNumber1 is equal to the obj random1 with a random number between 0 and 9
                tempString += randomNumber1[i].ToString(); //variable randomNumber1 converted to string 
             
            }
            label2.Text = tempString; //display the variable at label 2
            tempString = ""; //clear the string for the next generation of numbers

            //creation of the main 8 random numbers 

            Random random = new Random(); //constructor of the obj random
            string tempLoto = ""; 
            List<int> randomNumber = new List <int>(); //creating a list with random numbers
            
            for (int i = 0; i < 7; i++) 
            {
                int rand = random.Next(1,50); //generate the random number
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
 label1:    int numBonus = random.Next(1, 50); 
            if (!randomNumber.Contains(numBonus)) //compare the bonus number with all other 7 numbers in the list
            {
                randomNumber.Add(numBonus);
                tempBonus = numBonus.ToString();
            }
            else
            {
                goto label1;
            }


            textBox1.Text = tempLoto+tempBonus; //display the numbers at the textbox 1
            string txtFile = tempLoto + $" Bonus {tempBonus}"; //line of text that will be printed in a txt file

            tempLoto = ""; //clear the string for the next generation of numbers
            tempBonus = "";

            //save the numbers in a text file
            
            StreamWriter txt = new StreamWriter("G:\\My Drive\\AULAS\\LASALLE\\Lasalle - Winter2023\\OOP\\FINAL PROJECT\\LottoNbrs.txt", true); //path where will be generated the text file

            string print = txtFile.Replace("\t",","); //change the text in the txt file, replacing the tabs for ,
            

            txt.Write("Max, "+DateTime.Now+" "+print+"\n"); //printing in the txt file
            txt.Close();
            txt.Dispose();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader txt = new StreamReader("G:\\My Drive\\AULAS\\LASALLE\\Lasalle - Winter2023\\OOP\\FINAL PROJECT\\LottoNbrs.txt",true);
            string prevNumbers;
            prevNumbers = txt.ReadToEnd();
            MessageBox.Show(prevNumbers, "Previous Numbers Generated");
        }
    }
}
