using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Simulation
{
    public class Car : Vehicle
    {
        public int Acceleration { get; set; }

        public Car(string name, string color, int speed, int acceleration)
            : base(name, color, speed)
        { 
            Acceleration = acceleration;
        }

        /// <summary>
        /// Simulates the movement of the car with acceleration.
        /// Overrides the base Vehicle.Move method.
        /// </summary>
        public override void Move()
        {
            Speed += Acceleration;
            Console.WriteLine($"{Name} the case is driving at {Speed} km/h with an acceleration of {Acceleration}.");
        }
    }
}
