namespace Exception_Handling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void HandleMultipleExceptions(string userInput) // declare method
        {
            int[] array = { 1, 2, 3, 4, 5 }; // declare and initialize array

            try
            {
                int parsedInt = int.Parse(userInput); // attempt to parse an integer from a string
                int accessedElement = array[parsedInt]; // access an element in an array by the integer from the string
                MessageBox.Show($"Operation successful. Vallue: {accessedElement}"); // if no exception occurs - success message
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid format."); // failed attempt to parse int 
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Index out of range."); // failed accessed element in array
            }
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            string userInput = inputTextBox.Text;
            HandleMultipleExceptions(userInput);
        }
    }
}
