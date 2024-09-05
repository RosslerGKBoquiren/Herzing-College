using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Truck : Vehicle
    {
        public Truck(string name, string color, int speed)
            : base(name, color, speed)
        {
        }

        public override void Move()
        {
            // No acceleration, only speed is used
            Console.WriteLine($"{Name} is moving at {Speed} speed.");
        }
    }

}
