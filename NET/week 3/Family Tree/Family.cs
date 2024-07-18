using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class Family : IEnumerable<Person>
    {

        private List<Person> people = new List<Person>();

        /// <summary>
        /// Adds a new person to the family.
        /// </summary>
        /// <param name="person">The person to add to the family.</param>
        public void AddMember(Person person)
        {
            people.Add(person);
        }

        /// <summary>
        /// Finds a person in the family by their ID.
        /// </summary>
        /// <param name="id">The ID of the person to find.</param>
        /// <returns>The person with the specified ID, or null if not found.</returns>
        public Person GetPersonById(int id)
        {
            return people.Find(p => p.ID == id);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the family members.
        /// </summary>
        /// <returns>An enumerator for the family collection.</returns>
        public IEnumerator<Person> GetEnumerator()
        {
            return people.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the family members.
        /// </summary>
        /// <returns>An enumerator for the family collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
