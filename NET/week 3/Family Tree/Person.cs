using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }

        // self-referencing
        public Person Parent { get; set; }


        public string DisplayInfo()
        {
            // check if the person has a parent, else "None" 
            string parentName = Parent != null ? Parent.Name : "None";

            // string formatting - string.Format
            return string.Format("ID: {0}, Name: {1}, Age: {2}, Parent: {3},", Id, Name, Age, parentName);
        }
    }
}
