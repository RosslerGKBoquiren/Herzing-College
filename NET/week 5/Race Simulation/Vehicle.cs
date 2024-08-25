using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Race_Simulation
{
    /// <summary>
    /// Represents a generic vehicle with common properties like Name, Color and Speed
    /// </summary>
    public class Vehicle
    {
        // properties
        public string Name { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }


        // Constructor
        public Vehicle(string name, string color, int speed)
        {
            Name = name;
            Color = color;
            Speed = speed;
        }

        /// <summary>
        /// Method to simulate movement
        /// Method can be overridden by derived classes to provide specific behaviour
        /// </summary>
        public virtual void Move()
        {
            Console.WriteLine($"{Name} is moving at {Speed} km/h.");
        }
    }
}
