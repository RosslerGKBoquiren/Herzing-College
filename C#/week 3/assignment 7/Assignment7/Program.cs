using System;
using System.Text.RegularExpressions;

namespace Assignment7
{
    internal class Program
    {
        // Declaring and initializing a new dictionary
        static Dictionary<Country, Embassy> dicEmbassy = new Dictionary<Country, Embassy>();

        static void Main(string[] args)
        {
            // Adding pre-existing data
            AddEmbassyEntry("mnl", "Philippines", "630 Manila St.", "Jon Do", 63024567890);
            AddEmbassyEntry("jpn", "Japan", "811 Tokyo St.", "Jane Doe", 813456789);
            AddEmbassyEntry("yul", "Canada", "514 Montreal St.", "John Smith", 15146548778);
            AddEmbassyEntry("mex", "Mexico", "521 Cancun St", "Jon Do", 52112344578);
            AddEmbassyEntry("cdg", "France", "514 Paris St.", "Marie Curie", 33142275300);

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("********** Welcome to the Embassy Page **********\n");
                Console.WriteLine("Please Select an option: \n");
                Console.WriteLine("1 - Add New Embassy");
                Console.WriteLine("2 - Display all Embassy entries");
                Console.WriteLine("3 - Search for Embassy");
                Console.WriteLine("4 - Exit\n");
                Console.ResetColor();
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                    case "add":
                    case "new embassy":
                        AddNewEmbassy();
                        break;
                    case "2":
                    case "display all":
                    case "display":
                        DisplayAllEmbassies();
                        break;
                    case "3":
                    case "search":
                    case "search for embassy":
                        SearchForEmbassy();
                        break;
                    case "4":
                    case "exit":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n***** Good Bye! *****");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection, try again!");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddEmbassyEntry(string code, string countryName, string address, string ambassador, long telephoneNumber)
        {
            Country country = new Country { code = code, name = countryName };
            Embassy embassy = new Embassy { address = address, ambassador = ambassador, telephoneNumber = telephoneNumber };

            if (!dicEmbassy.ContainsKey(country))
            {
                dicEmbassy.Add(country, embassy);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{countryName}'s embassy has been added!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{countryName}'s embassy already exists.");
                Console.ResetColor();
            }
        }

        static void AddNewEmbassy()
        {
            Console.Clear();

            string code = GetValidatedInput("Enter country code (3 letters): ", input => input.Length == 3 && Regex.IsMatch(input, @"^[A-Za-z]+$"), "Invalid country code! It must be exactly 3 letters.");
            string countryName = GetValidatedInput("Enter country name: ", input => Regex.IsMatch(input, @"^[A-Za-z ]+$"), "Invalid country name! It cannot contain numbers.");
            string address = GetValidatedInput("Enter embassy address: ", input => Regex.IsMatch(input, @"^[A-Za-z0-9\s\-]+$"), "Invalid address! It must contain only letters, numbers, and dashes.");
            string ambassador = GetValidatedInput("Enter ambassador name: ", input => Regex.IsMatch(input, @"^[A-Za-z ]+$"), "Invalid ambassador name! It cannot contain numbers.");

            string phoneInput = GetValidatedInput("Enter telephone number: ", input => long.TryParse(input, out long phone) && phone >= 1000000000, "Invalid telephone number! It must be a numeric value with at least 10 digits.");
            long telephoneNumber = long.Parse(phoneInput);

            AddEmbassyEntry(code, countryName, address, ambassador, telephoneNumber);
        }

        static string GetValidatedInput(string prompt, Func<string, bool> validation, string errorMessage)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (!validation(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(errorMessage);
                    Console.ResetColor();
                }
            } while (!validation(input));
            return input;
        }


        static void DisplayAllEmbassies()
        {
            DisplayHeader();

            foreach (KeyValuePair<Country, Embassy> entry in dicEmbassy)
            {
                Console.WriteLine($"{entry.Key.code,-5} {entry.Key.name,-15} {entry.Value.address,-20} {entry.Value.ambassador,-15} {entry.Value.telephoneNumber,-15}");
            }
        }

        static void SearchForEmbassy()
        {
            Console.Clear();
            Console.Write("Enter country code or name to search: ");
            string searchInput = Console.ReadLine();
            bool entryFound = false;

            DisplayHeader();

            foreach (KeyValuePair<Country, Embassy> entry in dicEmbassy)
            {
                if (entry.Key.code.Equals(searchInput, StringComparison.OrdinalIgnoreCase) || entry.Key.name.Equals(searchInput, StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{entry.Key.code,-5} {entry.Key.name,-15} {entry.Value.address,-20} {entry.Value.ambassador,-15} {entry.Value.telephoneNumber,-15}");
                    entryFound = true;
                    Console.ResetColor();
                }
            }

            if (!entryFound)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEmbassy code or name not found!");
                Console.ResetColor();
            }
        }

        static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List of all Embassies: \n");
            Console.WriteLine($"{"Code",-5} {"Name of Country",-15} {"Address",-20} {"Ambassador",-15} {"Telephone Number",-15}");
            Console.WriteLine(new string('-', 100));
            Console.ResetColor();
        }
    }
}