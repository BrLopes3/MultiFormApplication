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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LottoMAX obj1 = new LottoMAX();
            obj1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lotto649 obj2 = new Lotto649();
            obj2.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(@".\Files\") == false) //creation of the file "Files" if it does not exist yet when the form is loaded
            {
                Directory.CreateDirectory(@".\Files\");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the Multiform App.? ", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoneyEx obj3 = new MoneyEx();
            obj3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TempConv obj4 = new TempConv();
            obj4.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IP4Valid obj5 = new IP4Valid();
            obj5.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SimpleCalc obj6 = new SimpleCalc();
            obj6.ShowDialog();
        }
    }
}
