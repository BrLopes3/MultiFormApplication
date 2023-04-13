using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormStartProject
{
    internal class Calculator
    {
        //private fields
        private decimal currentValue;
        private decimal operand1;
        private decimal operand2;
        private string op;

        //properties
        public decimal CurrentValue
        {
            get { return currentValue; }
            set { currentValue = value; }
        }
        public decimal Operand1
        {
            get { return operand1; }
            set { operand1 = value; }
        }
        public decimal Operand2
        {
            get { return operand2; }
            set { operand2 = value; }
        }
        public string Op
        {
            get { return op; }
            set { op = value; }
        }

        

        //Methods
        public decimal Add()
        {
            currentValue = operand1 + operand2;
            return currentValue;
        }

        public decimal Subtract()
        {
            currentValue = operand1 - operand2;
            return currentValue;
        }

        public decimal Multiply()
        {
            currentValue = operand1 * operand2;
            return currentValue;
        }

        public decimal Divide()
        {     
           currentValue = Math.Round(operand1 / operand2, 4);
           return currentValue;
        }

        public void Equals()
        {
            switch (op)
            {
                case "+":
                    {
                        Add();
                        break;
                    }
                    
                case "-":
                    {
                        Subtract();
                        break;
                    }
                    
                case "*":
                    {
                        Multiply();
                        break;
                    }
                    
                case "/":
                    {
                        Divide();
                        break;
                    }
                    
            }
        }




    }
}
