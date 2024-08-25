using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race_Simulation
{
    public class Bicycle : Vehicle
    {
        public int Acceleration { get; set; }

        public Bicycle(string name, string color, int speed, int acceleration)
            : base(name, color, speed)
        { 
            Acceleration = acceleration;
        }

        /// <summary>
        /// Simulates the movement of the bicycle with deceleration.
        /// Overrides the base Vehicle.Move method.
        /// </summary>
        public override void Move()
        {
            Speed += Acceleration;
            Console.WriteLine($"{Name} the bicycle is moving at {Speed} km/h with a deceleration of {Acceleration}.");
        }
    }
}
