using System;

namespace RacingSimulator
{
    public class Truck : Vehicle
    {
        public Truck(string model, string color, int speed)
            : base(model, color, speed)
        {
        }

        public override void CalculatePosition()
        {
            // Since the truck has no acceleration, the position is calculated purely based on speed
            Position = Speed;
        }

        public override void Move()
        {
            Console.WriteLine($"The truck {Name} is moving at {Speed} km/h.");
        }
    }
}
