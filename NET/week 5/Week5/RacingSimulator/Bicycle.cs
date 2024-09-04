public class Bicycle : Vehicle
{
    public int Acceleration { get; set; }

    public Bicycle(string model, string color, int speed, int acceleration)
        : base(model, color, speed)
    {
        Acceleration = acceleration;
    }

    public override void CalculatePosition()
    {
        Position = Speed + Acceleration / 2;
    }

    public override void Move()
    {
        Console.WriteLine($"The bicycle {Name} is moving at {Speed} km/h.");
    }
}
