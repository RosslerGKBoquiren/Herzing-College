using System;

namespace Assignment5
{
    class Program
    {
  
        const int minLength = 8;
        static string[] userInformation = new string[8];

        static void Main(string[] args)
        {

            while (true)
            {

                Console.Write("Hello, what would you like to do?: (1 - Register New User, 2 - Edit User, 3 - Exit): ");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "register new user":
                    case "register":
                        RegisterUser(); 
                        break;

                    case "2":
                    case "edit user":
                    case "edit":
                        EditUser();
                        break;

                    case "3":
                    case "exit":
                        return;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;

                }
            }
        }

        
        static void RegisterUser()
        {

            Console.WriteLine("REGISTER NEW USER");
            while (true)
            {
                Console.Write("First Name: ");
                string firstNameInput = Console.ReadLine().ToLower();
                if (!string.IsNullOrWhiteSpace(firstNameInput) && IsAllLetters(firstNameInput))
                {
                    userInformation[0] = firstNameInput;
                    break;
                }
                Console.WriteLine("Cannot be empty");
            }

            while (true)
            {
                Console.Write("Last Name: ");
                string lastNameInput = Console.ReadLine().ToLower();
                if (!string.IsNullOrWhiteSpace(lastNameInput) && IsAllLetters(lastNameInput))
                {
                    userInformation[1] = lastNameInput;
                    break;
                }
                Console.WriteLine("Cannot be empty");
            }

            while (true)
            {
                Console.Write("Age: ");
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    userInformation[2] = age.ToString();
                    break;
                }
                Console.WriteLine("Please enter a number");
            }

            while (true)
            {
                Console.Write("GPA: ");
                if (double.TryParse(Console.ReadLine(), out double gpa))
                {
                    userInformation[3] = gpa.ToString();
                    break;
                }
                Console.WriteLine("Please enter a number");
            }

            while (true)
            {
                Console.Write("Program: ");
                string programInput = Console.ReadLine().ToLower();
                if (!string.IsNullOrWhiteSpace(programInput))
                {
                    userInformation[4] = programInput;
                    break;
                }
                Console.WriteLine("Cannot be empty");
            }

            while (true)
            {
                Console.Write("Teacher: ");
                string teacherInput = Console.ReadLine().ToLower();
                if (!string.IsNullOrWhiteSpace(teacherInput) && IsAllLetters(teacherInput))
                {
                    userInformation[5] = teacherInput;
                    break;
                }
                Console.WriteLine("Cannot be empty");
            }

            userInformation[6] = GetValidUsername();
            userInformation[7] = GetValidPassword();

            Console.Clear();
            Console.WriteLine("Registration Sucessful!");

        }

        static string GetValidUsername()
        {
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
                else
                {
                    return usernameInput;
                }
            }
        }

        static string GetValidPassword()
        {
            const string symbols = "~`!@#$%^&*-_=+";
            const string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";
            const int minLength = 8;

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
                    return passwordInput;
                }
            }
        }

        static bool PasswordHasRequirements(string passwordInput, string capLetters, string lowLetters, string symbols, string numbers)
        {
            bool hasCapLetters = ContainsCharacters(passwordInput, capLetters);
            bool hasLowLetters = ContainsCharacters(passwordInput, lowLetters);
            bool hasSymbols = ContainsCharacters(passwordInput, symbols);
            bool hasNumbers = ContainsCharacters(passwordInput, numbers);

            return (hasCapLetters && hasLowLetters && hasSymbols && hasNumbers);
        }


        static bool ContainsCharacters(string input, string characters)
        {
            foreach (char abc in input)
            {
                if (characters.Contains(abc))
                {
                    return true;
                }
            }
            return false;
        }



        static void EditUser()
        {
            if (string.IsNullOrWhiteSpace(userInformation[0]))
            {
                Console.WriteLine("No user found. Please register a new user!");
                return;
            }

            Console.WriteLine("EDIT USER");

            while (true)
            {
                Console.WriteLine("User Information:");
                Console.WriteLine($"1 - First Name: {userInformation[0]}");
                Console.WriteLine($"2 - Last Name: {userInformation[1]}");
                Console.WriteLine($"3 - Age: {userInformation[2]}");
                Console.WriteLine($"4 - GPA: {userInformation[3]}");
                Console.WriteLine($"5 - Program: {userInformation[4]}");
                Console.WriteLine($"6 - Teacher: {userInformation[5]}");
                Console.WriteLine($"7 - Username: {userInformation[6]}");
                Console.WriteLine($"8 - Password: {userInformation[7]}");
                Console.WriteLine("9 - Exit Edit Mode");

                Console.Write("Select the number of the user information you want to edit: 1 - 9");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("New First Name: ");
                        userInformation[0] = GetValidString("New First Name: ");
                        break;

                    case "2":
                        Console.Write("New Last Name: ");
                        userInformation[1] = GetValidString("New Last Name: ");
                        break;

                    case "3":
                        Console.Write("New Age: ");
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            userInformation[2] = age.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Invalid age, please enter a number.");
                        }
                        break;

                    case "4":
                        Console.Write("New GPA: ");
                        if (double.TryParse(Console.ReadLine(), out double gpa))
                        {
                            userInformation[3] = gpa.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Invalid GPA, please enter a number.");
                        }
                        break;

                    case "5":
                        Console.Write("New Program: ");
                        userInformation[4] = GetValidString("New Program: ");
                        break;

                    case "6":
                        Console.Write("New Teacher: ");
                        userInformation[5] = GetValidString("New Teacher: ");
                        break;

                    case "7":
                        userInformation[6] = GetValidUsername();
                        break;

                    case "8":
                        userInformation[7] = GetValidPassword();
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Please select a valid number.");
                        break;
                }
            }

        }

        static bool IsAllLetters(string str)
        {
            foreach (char abc in str)
            {
                if (!char.IsLetter(abc))
                {
                    return false;
                }
            }
            return true;
        }

        static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (IsAllLetters(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Please enter letters only.");
            }
        }

    }
}