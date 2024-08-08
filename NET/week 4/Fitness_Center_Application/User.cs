using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Center_Application
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }  // in pounds
        public double Height { get; set; }  // in inches
        public bool IsMale { get; set; }

        public User(string name, int age, double weight, double height, bool isMale)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
            IsMale = isMale;
        }
    }
}
