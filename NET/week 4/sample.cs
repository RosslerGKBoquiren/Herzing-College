namespace Fitness_Center_Application
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


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs()) // if inputs are valid in Method ValidateInputs
                {
                    // proceed to calculations if validation passes
                    CalculateBMI();
                    CalculateBodyFat();
                    DisplayResults();
                }
            } catch (Exception ex) 
            {
                labelErrorMessage.Text = $"An error occurred: {ex.Message}";
                labelErrorMessage.ForeColor = Color.Red;
            }
            
            
        }

        private double CalculateBMI()
        {
            // retrieve and parse weigth and height inputs
            double weight = double.Parse(textWeight.Text);
            double height = double.Parse(textHeight.Text);

            // calculate BMI
            double bmi = (weight / (Math.Pow(height, 2))) * 703;
            return bmi;
        }

        private double CalculateBodyFat(double bmi)
        {
            int age = int.Parse(textAge.Text);
            double bodyFat;

            if (radioMale.Checked)
            {
                // formula for men
                bodyFat = (1.20 * bmi) + (0.23 * age) - (10.8 * 1) - 5.4;
            }
            else
            {
                // formula for women
                bodyFat = (1.20 * bmi) + (0.23 * age) - (10.8 - 0) - 5.4;
            }

            return bodyFat;
        }

        private bool ValidateInputs()
        {
            // validate Name
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                labelErrorMessage.Text = "Please enter a name.";
                labelErrorMessage.ForeColor = Color.Red;
                textName.Focus();
                return false;
            }

            // validate Age
            if (!int.TryParse(textAge.Text, out int age) || age <= 0)
            {
                labelErrorMessage.Text = "Please enter a valid age.";
                labelErrorMessage.ForeColor = Color.Red;
                textAge.Focus();
                return false;
            }

            // validate Gender
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                labelErrorMessage.Text = "Please select your gender.";
                labelErrorMessage.ForeColor = Color.Red;
                return false;
            }

            // validate Weight

            if (!double.TryParse(textWeight.Text, out double weight) || weight <= 0)
            {
                labelErrorMessage.Text = "Please enter a valid weight in pounds.";
                textWeight.ForeColor = Color.Red;
                textWeight.Focus();
                return false;
            }

            // validate Height
            if (!double.TryParse(textHeight.Text, out double height) || height <= 0)
            {
                labelErrorMessage.Text = "Please enter a vlid height in feet and inches.";
                labelErrorMessage.ForeColor = Color.Red;
                textHeight.Focus();
                return false;
            }

            // if all validations pass, return true
            return true;
        }

        private void DisplayResults()
        {
            double bmi = CalculateBMI();
            double bodyFat = CalculateBodyFat(bmi);

            lblBmi.Text = $"Your BMI is {bmi}";
            labelBodyFat.Text = $"Your body fat % is {bodyFat}";

            if (radioMale.Checked)
            {
                if (bmi <= 17.5)
                {
                    labelRisk.Text = "Underweight";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("underweightm.jpg");
                }
                else if (bmi > 17.5 && bmi < 18.5)
                {
                    labelRisk.Text = "Lowest Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("lowestNormalm.jpg");
                }
                else if (bmi >= 18.5 && bmi < 22)
                {
                    labelRisk.Text = "Middle Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("middleNormalm.jpg");
                }
                else if (bmi >= 22 && bmi < 24.9)
                {
                    labelRisk.Text = "Highest Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("highestNormalm.jpg");
                }
                else if (bmi >= 24.9 && bmi < 30)
                {
                    labelRisk.Text = "Obesity";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("obesitym.jpg");
                }
                else
                {
                    labelRisk.Text = "Morbid Obesity";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("morbidObesitym.jpg");
                }
            }
            else
            {
                if (bmi <= 17.5)
                {
                    labelRisk.Text = "Underweight";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("anorexiaf.jpg");
                }
                else if (bmi > 17.5 && bmi < 18.5)
                {
                    labelRisk.Text = "Lowest Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("lowestNormalf.jpg");
                }
                else if (bmi >= 18.5 && bmi < 22)
                {
                    labelRisk.Text = "Middle Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("middleNormalf.jpg");
                }
                else if (bmi >= 22 && bmi < 24.9)
                {
                    labelRisk.Text = "Highest Normal";
                    labelRisk.ForeColor = Color.Green;
                    pictureBox.Image = Image.FromFile("highestNormalf.jpg");
                }
                else if (bmi >= 24.9 && bmi < 30)
                {
                    labelRisk.Text = "Obesity";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("obesityf.jpg");
                }
                else
                {
                    labelRisk.Text = "Morbid Obesity";
                    labelRisk.ForeColor = Color.Red;
                    pictureBox.Image = Image.FromFile("morbidObesity.jpg");
                }
            }
        }

        private void labelWeight_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // clear all inputs
                textName.Clear();
                textAge.Clear();
                textWeight.Clear();
                textHeight.Clear();
                radioMale.Checked = false;
                radioFemale.Checked = false;

                // clear all outputs
                lblBmi.Text = string.Empty;
                labelBodyFat.Text = string.Empty;
                labelCategory.Text = string.Empty;
                labelRisk.Text = string.Empty;
                pictureBox.Image = null;

                // reset colors
                labelCategory.ForeColor = DefaultForeColor;
            }
            catch (Exception ex)
            { 
                labelErrorMessage.Text = $"An error occurred: {ex.Message}";
                labelErrorMessage.ForeColor = Color.Red;
            }
        }
    }
}