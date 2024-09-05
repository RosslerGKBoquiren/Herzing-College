using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
    public class Car : Vehicle
    {
        public int Acceleration { get; set; }

        public Car(string name, string color, int speed, int acceleration)
            : base(name, color, speed)
        {
            Acceleration = acceleration;
        }

        public override void Move()
        {
            Speed += Acceleration;
            Console.WriteLine($"{Name} is moving at {Speed} speed with acceleration of {Acceleration}.");
        }
    }

}
