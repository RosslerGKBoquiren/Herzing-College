using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RacingSimulator
{
    public partial class Form1 : Form
    {
        // Queue to hold vehicle instances
        private Queue<Vehicle> racingQueue;
        private Dictionary<Vehicle, ProgressBar> vehicleProgressBars;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instantiate vehicles
            Vehicle car = new Car("LaFerrari", "Red", 100, 10);
            Vehicle bike = new Bicycle("Contend SL1", "Yellow", 70, -1);
            Vehicle truck = new Truck("Tundra", "Blue", 95);
            Vehicle motorbike = new Motorbike("StreetFighter V4", "Orange", 90, 10);

            // Initialize the vehicleProgressBars dictionary
            vehicleProgressBars = new Dictionary<Vehicle, ProgressBar>
    {
        { car, progressBarCar },
        { bike, progressBarBicycle },
        { truck, progressBarTruck },
        { motorbike, progressBarMotorbike }
    };

            // Set maximum and minimum values for each progress bar
            foreach (var progressBar in vehicleProgressBars.Values)
            {
                progressBar.Maximum = 100;
                progressBar.Minimum = 0;
            }

            // Set the color of each progress bar
            progressBarCar.ForeColor = System.Drawing.Color.Red;
            progressBarBicycle.ForeColor = System.Drawing.Color.Yellow;
            progressBarTruck.ForeColor = System.Drawing.Color.Blue;
            progressBarMotorbike.ForeColor = System.Drawing.Color.Orange;

            // Set progress bar labels to vehicle names (assume you have labels beside progress bars)
            labelCar.Text = car.Name;
            labelBicycle.Text = bike.Name;
            labelTruck.Text = truck.Name;
            labelMotorbike.Text = motorbike.Name;

            // Enqueue vehicles
            racingQueue = new Queue<Vehicle>(new List<Vehicle> { car, bike, truck, motorbike });

            // Now reset progress bars safely
            ResetProgressBars();
        }


        private void StartRaceButton_Click(object sender, EventArgs e)
        {
            // Start the race by enabling the timer
            raceTimer.Start();
        }

        private void ResetRaceButton_Click(object sender, EventArgs e)
        {
            // Reset the race
            raceTimer.Stop();
            ResetProgressBars();
        }

        private void raceTimer_Tick(object sender, EventArgs e)
        {
            if (racingQueue == null || vehicleProgressBars == null)
            {
                // Log an error or handle this situation accordingly
                return;
            }

            bool raceFinished = false;

            foreach (var vehicle in racingQueue)
            {
                if (vehicle == null || !vehicleProgressBars.ContainsKey(vehicle))
                {
                    // Skip if the vehicle or its progress bar is not properly initialized
                    continue;
                }

                int progress = 0;

                try
                {
                    if (vehicle is Car || vehicle is Motorbike || vehicle is Bicycle)
                    {
                        // Vehicles with acceleration
                        progress = (int)(vehicleProgressBars[vehicle].Value + vehicle.Speed + 0.5 * (vehicle as dynamic).Acceleration);
                    }
                    else
                    {
                        // Vehicles without acceleration (e.g., Truck)
                        progress = vehicleProgressBars[vehicle].Value + vehicle.Speed;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors in calculation
                    Console.WriteLine("Error calculating progress: " + ex.Message);
                    continue;
                }

                vehicleProgressBars[vehicle].Value = Math.Min(progress, 100);

                if (vehicleProgressBars[vehicle].Value >= 100)
                {
                    raceFinished = true;
                    raceTimer.Stop();
                    labelRaceResult.Text = $"{vehicle.Name} has won the race!";
                    labelRaceResult.ForeColor = System.Drawing.Color.Green; // Optionally set the text color to something noticeable
                    break;
                }
            }
        }


        private void ResetProgressBars()
        {
            // Reset all progress bars
            foreach (var progressBar in vehicleProgressBars.Values)
            {
                progressBar.Value = 0;
            }
        }
    }
}