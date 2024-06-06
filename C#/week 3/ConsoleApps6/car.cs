using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApps6
{
    internal class Car
    {
        private string _name;
        private int _hp;
        private string _color;

        // default constructor
        public Car()
        {
            _name = "Car";
            _hp = 0;
            _color = "Black";
        }

        // partial specification constructor
        public Car(string name, int hp = 0)
        {
            _name = name;
            _hp = hp;
            _color = "black";
            Console.WriteLine("A car {0} was created", name);
        }
        //full specification constructor
        public Car(string name, int hp, string color) 
        {
            _name = name;
            _hp = hp;
            _color = color;
            Console.WriteLine("A car, {0}, was created", _name);    
        }
        public void Drive()
        {
            Console.WriteLine("***{0} is moving***", _name);
        }
        public void Stop()
        {
            Console.WriteLine("***{0} has stopped***", _name);
        }
        public void Details()
        {
            Console.WriteLine("Car with the name of {0}, color {1}, has a horsepower of {2}", _name, _color, _hp);
        }
    }
}
