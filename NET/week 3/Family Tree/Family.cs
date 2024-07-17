using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class Family : IEnumerable<Person>
    {
        // List to store the family members
        private List<Person> people = new List<Person>();

        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person getPersonById(int id)
        {
            return people.Find(p => p.Id == id);
        }

        public IEnumerator<Person> GetEnumerator()
        { 
            return people.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        { 
            return GetEnumerator();
        }
    }
}
