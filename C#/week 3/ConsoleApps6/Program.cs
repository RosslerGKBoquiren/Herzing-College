using ConsoleApps6;

namespace ConsoleApp6
{
    internal class Program// class is a blueprint of an object and assumed as a datatype when called in an instance method
                          // for example, object: car, it will have abilities such as drive, break or open window, and inheritance: A5
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Name = "Mazda";
            Console.WriteLine(myCar.Name);

            /* myCar.Details();

            Car audi = new Car("Audi", 260, "red");
            audi.Details();
            audi.Drive();
            Car bmw = new Car("Bmw", 600);
            bmw.Details();
            bmw.Drive();
            Console.WriteLine("Enter 1 to stop");
            string userInput = Console.ReadLine();
            if (userInput == "1")
                audi.Stop();
            else
                Console.WriteLine("Car is still moving."); */
        }
    }
}