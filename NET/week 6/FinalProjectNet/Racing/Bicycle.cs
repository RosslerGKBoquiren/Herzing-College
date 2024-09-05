using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Bicycle : Vehicle
    {
        public int Acceleration { get; set; }

        public Bicycle(string name, string color, int speed, int acceleration)
            : base(name, color, speed)
        {
            Acceleration = acceleration;
        }

        public override void Move()
        {
            Speed += Acceleration;  // Acceleration is negative, so speed decreases
            Console.WriteLine($"{Name} is moving at {Speed} speed with deceleration of {Acceleration}.");
        }
    }

}
