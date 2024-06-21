using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Person // publicly accessible by any other class within the project
    {
        public string Name { get; set; }
        public string ID { get; set; } 
        public string ContactNumber { get; set; }

        // constructor takes three parameters and assigns to corresponding properties
        public Person(string name, string id, string contactNumber) 
        {
            Name = name;
            ID = id;
            ContactNumber = contactNumber;
        }

        // method to return a string representing a person's details
        public string GetPersonDetails()
        {
            return $"Name: {Name}, ID: {ID}, Contact: {ContactNumber}";
        }
    }
}

