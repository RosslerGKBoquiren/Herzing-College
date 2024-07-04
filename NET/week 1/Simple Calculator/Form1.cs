using System;
using System.Windows.Forms;

namespace Simple_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            PerformOperation("*");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        /*private void form1_Load(object sender, EventArgs e)
        {

        }*/



        private void PerformOperation(string operation)
        {
            try
            {
                double firstNumber = Convert.ToDouble(txtFirstNumber.Text);
                double secondNumber = Convert.ToDouble(txtSecondNumber.Text);
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    case "*":
                        result = firstNumber * secondNumber;
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Cannot divide by Zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        result = firstNumber / secondNumber;
                        break;
                }

                lblResult.Text = "Result: " + result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearValues()
        {
            txtFirstNumber.Text = " ";
            txtSecondNumber.Text = " ";
            lblResult.Text = " ";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearValues();
        }
    }
}
