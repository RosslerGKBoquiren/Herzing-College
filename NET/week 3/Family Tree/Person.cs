using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    /// <summary>
    /// Represents a person with properties such as ID, Name, Age and Parent
    /// </summary>
     public class Person
    {
        // define a simple "Person" class with properties such as ID, Name, Age, Parent
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Parent { get; set; } // Parent property as a self-referential relationship in the Person class


        /// <summary>
        /// Displays the person's information
        /// </summary>
        /// <returns>returns a formatted string containing the person's information</returns>
        public string DisplayInfo()
            // use string.Format to display the properties
        {
            string parentName = Parent != null ? Parent.Name : "None";
            return $"{ID.ToString().PadRight(10)} {Name.PadRight(20)} {Age.ToString().PadRight(10)} {parentName.PadRight(20)}";
        }
    }
}
