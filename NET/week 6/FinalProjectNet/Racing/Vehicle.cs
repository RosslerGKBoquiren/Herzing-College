using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Vehicle
    {
        // Properties common to all vehicles
        public string Name { get; set; }
        public string Color { get; set; }
        public int Speed { get; set; }

        // Constructor to initialize the properties
        public Vehicle(string name, string color, int speed)
        {
            Name = name;
            Color = color;
            Speed = speed;
        }

        // Virtual Move() method to allow overriding in subclasses
        public virtual void Move()
        {
            // Basic movement logic using Speed
            Console.WriteLine($"{Name} is moving at {Speed} speed.");
        }
    }

}
