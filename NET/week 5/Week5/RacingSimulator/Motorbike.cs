public class Motorbike : Vehicle
{
    public int Acceleration { get; set; }

    public Motorbike(string model, string color, int speed, int acceleration)
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
        Console.WriteLine($"The motorbike {Name} is moving at {Speed} km/h.");
    }
}
