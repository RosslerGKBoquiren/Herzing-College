public class Car : Vehicle
{
    public int Acceleration { get; set; }

    public Car(string model, string color, int speed, int acceleration)
        : base(model, color, speed)
    {
        Acceleration = acceleration;
    }

    public override void CalculatePosition()
    {
        Position = Speed + Acceleration / 2;  // Formula for vehicles with acceleration
    }

    public override void Move()
    {
        Console.WriteLine($"The car {Name} is moving at {Speed} km/h.");
    }
}

