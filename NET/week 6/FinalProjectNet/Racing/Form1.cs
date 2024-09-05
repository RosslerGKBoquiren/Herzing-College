using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Racing
{
    public partial class Form1 : Form
    {
        private Queue<Vehicle> raceQueue = new Queue<Vehicle>();
        private List<Vehicle> availableVehicles = new List<Vehicle>();

        public Form1()
        {
            InitializeComponent();
            InitializeVehicles();
        }

        private void InitializeVehicles()
        {
            // Create and add vehicle objects to the available vehicles list
            availableVehicles.Add(new Car("Ferrari", "Red", 92, 8));
            availableVehicles.Add(new Car("Lamborghini", "Yellow", 91, 9));
            availableVehicles.Add(new Bicycle("Mountain Bike", "Green", 20, -2));
            availableVehicles.Add(new Bicycle("Road Bike", "Blue", 25, -1));
            availableVehicles.Add(new Motorbike("Ducati", "Black", 88, 12));
            availableVehicles.Add(new Motorbike("Harley", "Orange", 90, 10));
            availableVehicles.Add(new Truck("Ford", "Purple", 82));
            availableVehicles.Add(new Truck("Chevrolet", "Pink", 86));

            // Populate ListBox controls with vehicle names
            foreach (var vehicle in availableVehicles)
            {
                if (vehicle is Car) listBoxCar.Items.Add(vehicle.Name);
                else if (vehicle is Bicycle) listBoxBicycle.Items.Add(vehicle.Name);
                else if (vehicle is Motorbike) listBoxMotorbike.Items.Add(vehicle.Name);
                else if (vehicle is Truck) listBoxTruck.Items.Add(vehicle.Name);
            }
        }

        private void buttonAddToRace_Click(object sender, EventArgs e)
        {
            labelMessage.Text = "";

            // Clear previously selected vehicles
            listBoxSelectedVehicles.Items.Clear();
            raceQueue.Clear();

            // Reset labels to default in case less than 4 vehicles are selected
            labelCar.Text = "Car";
            labelBicycle.Text = "Bicycle";
            labelMotorbike.Text = "Motorbike";
            labelTruck.Text = "Truck";

            // Add selected vehicles to the queue
            AddSelectedVehicle(listBoxCar, "Car", labelCar);
            AddSelectedVehicle(listBoxBicycle, "Bicycle", labelBicycle);
            AddSelectedVehicle(listBoxMotorbike, "Motorbike", labelMotorbike);
            AddSelectedVehicle(listBoxTruck, "Truck", labelTruck);

            // Display selected vehicles in the listBoxSelectedVehicles
            foreach (var vehicle in raceQueue)
            {
                listBoxSelectedVehicles.Items.Add(vehicle.Name);
            }

            // ensure exactly 4 vehicles are selected
            if (raceQueue.Count != 4)
            {
                labelMessage.Text = "Please select exactly 4 vehicles.";
                labelMessage.ForeColor = Color.Tomato;
                return;
            }
        }

        private void AddSelectedVehicle(ListBox listBox, string vehicleType, Label vehicleLabel)
        {
            
            if (listBox.SelectedItem != null)
            {
                var vehicleName = listBox.SelectedItem.ToString();
                var selectedVehicle = availableVehicles
                    .Find(v => v.Name == vehicleName && v.GetType().Name == vehicleType);

                if (selectedVehicle != null) 
                {
                    raceQueue.Enqueue(selectedVehicle);
                    vehicleLabel.Text = selectedVehicle.Name;
                }
                else
                {
                    labelMessage.Text = $"Could not find a vehicle of type {vehicleType} with the name {vehicleName}.";
                    labelMessage.ForeColor = Color.Tomato;
                }
            }
            else
            {
                labelMessage.Text = $"No {vehicleType} selected.";
                labelMessage.ForeColor = Color.Tomato;
            }


        }


        private void buttonStartRace_Click(object sender, EventArgs e)
        {
            if (raceQueue.Count != 4)
            {
                labelMessage.Text = "Please select vehicles";
                labelMessage.ForeColor = Color.Tomato;
                return;
            }

            if (!timerRace.Enabled)
            {
                timerRace.Start();
            }
        }

        private void UpdateProgressBars()
        {
            foreach (var vehicle in raceQueue)
            {
                if (vehicle is Car car)
                {
                    progressBarCar.ForeColor = Color.FromName(car.Color);
                    progressBarCar.Value = Math.Min(progressBarCar.Maximum, progressBarCar.Value + car.Speed + car.Acceleration / 2);
                }
                else if (vehicle is Bicycle bicycle)
                {
                    progressBarBicycle.ForeColor = Color.FromName(bicycle.Color);
                    progressBarBicycle.Value = Math.Min(progressBarBicycle.Maximum, progressBarBicycle.Value + bicycle.Speed + bicycle.Acceleration / 2);
                }
                else if (vehicle is Motorbike motorbike)
                {
                    progressBarMotorbike.ForeColor = Color.FromName(motorbike.Color);
                    progressBarMotorbike.Value = Math.Min(progressBarMotorbike.Maximum, progressBarMotorbike.Value + motorbike.Speed + motorbike.Acceleration / 2);
                }
                else if (vehicle is Truck truck)
                {
                    progressBarTruck.ForeColor = Color.FromName(truck.Color);
                    progressBarTruck.Value = Math.Min(progressBarTruck.Maximum, progressBarTruck.Value + truck.Speed);
                }

                // Check if any progress bar has reached the maximum value
                if (progressBarCar.Value >= progressBarCar.Maximum ||
                    progressBarBicycle.Value >= progressBarBicycle.Maximum ||
                    progressBarMotorbike.Value >= progressBarMotorbike.Maximum ||
                    progressBarTruck.Value >= progressBarTruck.Maximum)
                {
                    timerRace.Stop();
                    labelMessage.Text = $"{vehicle.Name} wins the race!";
                    labelMessage.ForeColor = Color.LimeGreen;
                    return;
                }
            }
        }

        private void timerRace_Tick(object sender, EventArgs e)
        {
            UpdateProgressBars();
        }


        private void buttonResetRace_Click(object sender, EventArgs e)
        {
            timerRace.Stop();
            timerRace.Dispose();

            // Re-initialize the timer for the next race
            timerRace = new System.Windows.Forms.Timer();
            timerRace.Interval = 100; 
            timerRace.Tick += timerRace_Tick;

            // Clear the queue and reset progress bars
            raceQueue.Clear();
            progressBarCar.Value = 0;
            progressBarBicycle.Value = 0;
            progressBarMotorbike.Value = 0;
            progressBarTruck.Value = 0;

            // Clear selected vehicles list
            listBoxSelectedVehicles.Items.Clear();

            // Reset the labels to their default state
            labelCar.Text = "Car";
            labelBicycle.Text = "Bicycle";
            labelMotorbike.Text = "Motorbike";
            labelTruck.Text = "Truck";

            // Clear any messages
            labelMessage.Text = "";
        }
    }
}
