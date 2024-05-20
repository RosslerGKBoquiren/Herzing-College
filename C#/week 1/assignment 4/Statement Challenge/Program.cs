using System;

namespace StatementChallenge
{
    class Program
    { 
        static void Main(string[] args) 
        {
            const string symbols = "~`!@#$%^&*-_=+";
            const string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const int minLength = 8;
            string savedUsername;
            string savedPassword;


            Console.WriteLine("CREATE ACCOUNT");
            while (true)
            {
                Console.Write("Username: ");
                string usernameInput = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(usernameInput))
                {
                    Console.WriteLine("Cannot be empty");
                }
                else if (usernameInput.Length < minLength)
                {
                    Console.WriteLine("Minimum of 8 characters");
                }
                /* else if (!UsernameHasRequirements(usernameInput, lowLetters, symbols, numbers))
                {
                    Console.WriteLine("Please use a mix of a-z");
                }*/
                else
                {
                    savedUsername = usernameInput;
                    break;
                }
            }


            while (true)
            {
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(passwordInput))
                {
                    Console.WriteLine("Cannot be empty");
                }
                else if (passwordInput.Length < minLength)
                {
                    Console.WriteLine("Minimum of 8 characters");
                }
                else if (!PasswordHasRequirements(passwordInput, capLetters, lowLetters, symbols, numbers))
                {
                    Console.WriteLine("Please use a mix of a-Z, @#$ and 0-9");
                }
                else
                {
                    savedPassword = passwordInput;
                    break;
                }
            }

            Console.Clear();

            Console.WriteLine("LOGIN");
            while (true)
            {
                Console.Write("Enter your username: ");
                string usernameLog = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(usernameLog))
                {
                    Console.Write("Cannot be empty");
                }
                else if (usernameLog != savedUsername)
                {
                    Console.WriteLine("Username Invalid or not found");
                }
                else
                {
                    while (true)
                    {
                        Console.Write("Enter your password: ");
                        string passwordLog = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(passwordLog))
                        {
                            Console.WriteLine("Cannot be empty");
                        }
                        else if (passwordLog != savedPassword)
                        {
                            Console.WriteLine("Password Invalid");
                        }
                        else
                        {
                            Console.Write("Login Sucessful!");
                            break;
                        }
                    }

                    break;
                }
            }

        }

        /// <summary>
        /// For each loop 
        /// </summary>
        /// <param name="usernameInput"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        static bool ContainsCharacters(string usernameInput, string characters)
        {
            foreach (char abc in usernameInput)
            {
                if (characters.Contains(abc))
                {
                    return true;
                }
            }
            return false;
        }

        /* static bool UsernameHasRequirements(string usernameInput, string lowLetters, string symbols, string numbers)
        {
            bool hasLowLetters = ContainsCharacters(usernameInput, lowLetters);
            bool hasSymbols = ContainsCharacters(usernameInput, symbols);
            bool hasNumbers = ContainsCharacters(usernameInput, numbers);

            return hasLowLetters && hasSymbols && hasNumbers;
        }*/

        static bool PasswordHasRequirements(string passwordInput, string capLetters, string lowLetters, string symbols, string numbers)
        { 
            bool hasCapLetters = ContainsCharacters(passwordInput, capLetters);
            bool hasLowLetters = ContainsCharacters (passwordInput, lowLetters);
            bool hasSymbols = ContainsCharacters (passwordInput, symbols);
            bool hasNumbers = ContainsCharacters (passwordInput, numbers);

            return (hasCapLetters && hasLowLetters && hasSymbols && hasNumbers);
        }
    }
}