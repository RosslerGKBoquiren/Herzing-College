using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fitness_Center_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInputs())
                {
                    // Convert height to inches before calculations
                    double heightInInches = ConvertHeightToInches(double.Parse(textHeight.Text));

                    // Create a new User instance with converted height
                    User user = new User(
                        textName.Text,
                        int.Parse(textAge.Text),
                        double.Parse(textWeight.Text),
                        heightInInches,
                        radioMale.Checked);

                    // Perform calculations
                    double bmi = Calculator.CalculateBMI(user.Weight, user.Height);
                    double bodyFat = Calculator.CalculateBodyFat(bmi, user.Age, user.IsMale);

                    // Display results
                    labelResults.Text = $"{user.Name}, here are your results!";
                    lblBmi.Text = $"Your BMI is {bmi:F2}";
                    labelBodyFat.Text = $"Your body fat % is {bodyFat:F2}";
                    string category = Calculator.DetermineBMICategory(bmi);
                    labelCategory.Text = category;
                    string risk = Calculator.DetermineRisk(bmi);
                    labelRisk.Text = risk;

                    // Set the ForeColor based on the Risk category
                    if (risk == "High Risk")
                    {
                        labelRisk.ForeColor = Color.Red;
                    }
                    else if (risk == "Low Risk")
                    {
                        labelRisk.ForeColor = Color.Green;
                    }

                    // Set the ForeColor based on the BMI category
                    switch (category)
                    {
                        case "Underweight":
                            labelCategory.ForeColor = Color.Orange;
                            break;
                        case "Lowest Normal":
                        case "Middle Normal":
                        case "Highest Normal":
                            labelCategory.ForeColor = Color.Green;
                            break;
                        case "Obesity":
                        case "Morbid Obesity":
                            labelCategory.ForeColor = Color.Red;
                            break;
                    }

                    // Update visual feedback based on the BMI category
                    string imagePath = Calculator.GetImagePath(bmi, user.IsMale);
                    if (System.IO.File.Exists(imagePath))
                    {
                        pictureBox.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        labelErrorMessage.Text = $"Image not found: {imagePath}";
                    }
                }
            }
            catch (Exception ex)
            {
                labelErrorMessage.Text = $"An error occurred: {ex.Message}";
                labelErrorMessage.ForeColor = Color.Red;
            }
        }

        private bool ValidateInputs()
        {
            // Validate Name
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                labelErrorMessage.Text = "Please enter a name.";
                labelErrorMessage.ForeColor = Color.Red;
                textName.Focus();
                return false;
            }

            // Validate Age
            if (!int.TryParse(textAge.Text, out int age) || age <= 0)
            {
                labelErrorMessage.Text = "Please enter a valid age.";
                labelErrorMessage.ForeColor = Color.Red;
                textAge.Focus();
                return false;
            }

            // Validate Gender
            if (!radioMale.Checked && !radioFemale.Checked)
            {
                labelErrorMessage.Text = "Please select your gender.";
                labelErrorMessage.ForeColor = Color.Red;
                return false;
            }

            // Validate Weight
            if (!double.TryParse(textWeight.Text, out double weight) || weight <= 0)
            {
                labelErrorMessage.Text = "Please enter a valid weight in pounds.";
                textWeight.ForeColor = Color.Red;
                textWeight.Focus();
                return false;
            }

            // Validate Height
            if (!double.TryParse(textHeight.Text, out double height) || height <= 0)
            {
                labelErrorMessage.Text = "Please enter a valid height in feet and inches.";
                labelErrorMessage.ForeColor = Color.Red;
                textHeight.Focus();
                return false;
            }

            // If all validations pass, return true
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear all inputs
                textName.Clear();
                textAge.Clear();
                textWeight.Clear();
                textHeight.Clear();
                radioMale.Checked = false;
                radioFemale.Checked = false;

                // Clear all outputs
                lblBmi.Text = string.Empty;
                labelBodyFat.Text = string.Empty;
                labelCategory.Text = string.Empty;
                labelRisk.Text = string.Empty;
                pictureBox.Image = null;

                // Reset colors
                labelCategory.ForeColor = DefaultForeColor;
            }
            catch (Exception ex)
            {
                labelErrorMessage.Text = $"An error occurred: {ex.Message}";
                labelErrorMessage.ForeColor = Color.Red;
            }
        }

        private double ConvertHeightToInches(double height)
        {
            int feet = (int)height;
            double inches = (height - feet) * 100; // assuming the user enters height as feet.inches (e.g., 5.11)
            return (feet * 12) + inches;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    

