using System;

namespace Assignment7
{
    class Program
    {
        //declaring and initializating a new dictionary
        static Dictionary<Country, Embassy> dicEmbassy = new Dictionary<Country, Embassy>();

        static void Main(string[] args)
        {
            AddEmbassyEntry("php", "Philippines", "514 Manila St.", "Jon Do", 5146614578);
        }

        static void AddEmbassyEntry(string code, string countryName, string address, string ambassador, long telephoneNumber)
        { 
            Country country = new Country { code = code, name = countryName };
            Embassy embassy = new Embassy { address = address, ambassador = ambassador, telephoneNumber = telephoneNumber };

            if (!dicEmbassy.Contains(code))
            {
                dicEmbassy.Add(country, embassy);
                Console.WriteLine($"{countryName}'s embassy has been added!");
            }
            else
            {
                Console.WriteLine($"{countryName}'s embassy already exists.");
            }
            
        }
    }
}