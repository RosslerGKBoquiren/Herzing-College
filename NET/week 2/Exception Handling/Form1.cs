using System;
using System.Windows.Forms;

namespace Exception_Handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles multiple exceptions by attempting to parse an integer from a string
        /// and accessing an element in an array by the parsed integer
        /// </summary>
        /// <param name="userInput">the user input string to be parsed</param>
        public void HandleMultipleExceptions(string userInput) // declare method
        {
            int[] array = { 10, 26, 30, 47, 51 }; // declare and initialize array

            try
            {
                int parsedInt = int.Parse(userInput); // attempt to parse an integer from a string
                int accessedElement = array[parsedInt]; // access an element in an array by the integer from the string
                MessageBox.Text = $"Operation successful. Value: {accessedElement}"; // if no exception occurs - success message
            }
            catch (FormatException)
            {
                MessageBox.Text = "Invalid format."; // failed attempt to parse int 
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Text = "Index out of range."; // failed accessed element in array
            }
        }


        /// <summary>
        /// handles the Click event of the runButton control
        /// Gets the user input and calls the HandleMultipleExceptions method
        /// </summary>
        /// <param name="sender">the source of the event</param>
        /// <param name="e">an eventArgs that contains the event data</param>
        private void runButton_Click(object sender, EventArgs e)
        {
            string userInput = inputTextBox.Text;

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Text = "Please enter a value."; // failed execution, values are empty
                return;
            }

            HandleMultipleExceptions(userInput);
        }


        /// <summary>
        /// clears the values of the MessageBox lavel and the inputTextBox
        /// </summary>
        private void ClearValues() // reset 
        {
            MessageBox.Text = "Result: "; 
            inputTextBox.Text = "";
        }


        /// <summary>
        /// Handles the click event of the btnClear control
        /// Calls the ClearValues method to reset the form controls
        /// </summary>
        /// <param name="sender">the source of the event</param>
        /// <param name="e">An eventArgs that contains the event data</param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearValues();
        }
    }
}
