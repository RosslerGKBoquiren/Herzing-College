using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Person
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string ContactNumber { get; set; }

        public Person(string name, string id, string contactNumber)
        {
            Name = name;
            ID = id;
            ContactNumber = contactNumber;
        }
    }
}
