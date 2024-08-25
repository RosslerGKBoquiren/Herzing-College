using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Race_Simulation
{
    public class Truck : Vehicle
    {
        public Truck(string name, string color, int speed)
                : base(name, color, speed)
        {
        }

        /// <summary>
        /// Simulates the movement of the truck.
        /// Overrides the base Vehicle.Move method.
        /// </summary>
        public override void Move()
        {
            Console.WriteLine($"{Name} the truck is hauling at {Speed} km/h.");
        }
    }
}
