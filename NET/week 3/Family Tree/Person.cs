using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
     public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Parent { get; set; }

        public string DisplayInfo()
        {
            string parentName = Parent != null ? Parent.Name : "None";
            return string.Format("ID: {0} \nName: {1} \nAge: {2} \nParent: {3}", ID, Name, Age, parentName);
        }
    }
}
