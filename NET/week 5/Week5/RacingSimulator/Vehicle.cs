public class Vehicle
{
    // Properties
    public string Name { get; set; }
    public string Color { get; set; }
    public int Speed { get; set; }
    public int Position { get; protected set; }  // Position for queuing purposes

    // Constructor
    public Vehicle(string name, string color, int speed)
    {
        Name = name;
        Color = color;
        Speed = speed;
    }

    // Calculate the position based on speed and acceleration
    public virtual void CalculatePosition()
    {
        Position = Speed; // For vehicles without acceleration
    }

    // simulate the vehicle's movement
    public virtual void Move()
    {
        Console.WriteLine($"{Name} is moving at {Speed} km/h.");
    }
}

