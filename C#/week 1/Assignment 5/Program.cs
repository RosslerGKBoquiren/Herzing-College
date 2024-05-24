using System;

namespace Assignment5
{
    class Program
    {
        const int minLength = 8;
        static string[] userInformation = new string[8];

        /// <summary>
        /// Provides the user with the options to Register, Edit, Login or exit the code
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Hello, what would you like to do?: (1 - Register New User, 2 - Login User, 3 - Exit): ");
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "register new user":
                    case "register":
                        RegisterUser();
                        break;

                    case "2":
                    case "login user":
                    case "login":
                        Login();

                        while (true)
                        {
                            Console.Write("Hello, what would you like to do?: (1 - Register New User, 2 - Edit User, 3 - Exit): ");
                            string userInput2 = Console.ReadLine().ToLower();
                            switch (userInput2)
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

        /// <summary>
        /// Asks the user to register their information to be stored in userInformation
        /// </summary>
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
                Console.WriteLine("Cannot be empty or have numbers");
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
                Console.WriteLine("Cannot be empty or have numbers");
            }

            while (true)
            {
                Console.Write("Age: ");
                if (int.TryParse(Console.ReadLine(), out int age) && age > 0)
                {
                    userInformation[2] = age.ToString();
                    break;
                }
                Console.WriteLine("Please enter a valid number");
            }

            while (true)
            {
                Console.Write("GPA: ");
                if (double.TryParse(Console.ReadLine(), out double gpa) && gpa > 0)
                {
                    userInformation[3] = gpa.ToString();
                    break;
                }
                Console.WriteLine("Please enter a valid number");
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
                if (!string.IsNullOrEmpty(teacherInput) && IsAllLettersOrSpaces(teacherInput))
                {
                    userInformation[5] = teacherInput;
                    break;
                }
                Console.WriteLine("Cannot be empty or have numbers");
            }

            userInformation[6] = GetValidUsername();
            userInformation[7] = GetValidPassword();

            Console.Clear();
            Console.WriteLine("Registration Successful!");
        }

        /// <summary>
        /// Checks if characters in the string have letters or spaces
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if characters have letters or spaces, else false.</returns>
        static bool IsAllLettersOrSpaces(string str)
        {
            foreach (char abc in str)
            {
                if (!char.IsLetter(abc) && !char.IsWhiteSpace(abc))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// asks the user to provide a valid username by following the conditions set
        /// </summary>
        /// <returns>need a valid username that meets the requirements</returns>
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

        /// <summary>
        /// asks the user to enter a valid password
        /// </summary>
        /// <returns>need a valid password that meets multiple conditions</returns>
        static string GetValidPassword()
        {
            const string symbols = "~`!@#$%^&*-_=+";
            const string capLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowLetters = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";

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
                    Console.WriteLine("Please use a mix of uppercase letters, lowercase letters, symbols, and numbers.");
                }
                else
                {
                    return passwordInput;
                }
            }
        }

        /// <summary>
        /// verifies if the password meets multiple requirements
        /// </summary>
        /// <param name="passwordInput">verifies the password input</param>
        /// <param name="capLetters">verifies if there is uppercase</param>
        /// <param name="lowLetters">verifies if there is lowercase</param>
        /// <param name="symbols">verifies if there are symbols</param>
        /// <param name="numbers">verifies if there are numbers</param>
        /// <returns>True if the password meets the requirements, else false</returns>
        static bool PasswordHasRequirements(string passwordInput, string capLetters, string lowLetters, string symbols, string numbers)
        {
            bool hasCapLetters = ContainsCharacters(passwordInput, capLetters);
            bool hasLowLetters = ContainsCharacters(passwordInput, lowLetters);
            bool hasSymbols = ContainsCharacters(passwordInput, symbols);
            bool hasNumbers = ContainsCharacters(passwordInput, numbers);

            return hasCapLetters && hasLowLetters && hasSymbols && hasNumbers;
        }

        /// <summary>
        /// verifies if the input contains any characters from the set of characters
        /// </summary>
        /// <param name="input">verifies the input</param>
        /// <param name="characters">verifies the set of characters</param>
        /// <returns>True if the input contains any characters from the set, else False</returns>
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

        /// <summary>
        /// Asks the user to edit and verify inputs in the user information
        /// </summary>
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

                Console.Write("Select the number of the user information you want to edit (1-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("New First Name: ");
                        string firstName = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(firstName) && IsAllLetters(firstName))
                        {
                            userInformation[0] = firstName;
                        }
                        break;

                    case "2":
                        Console.Write("New Last Name: ");
                        string lastName = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(lastName) && IsAllLetters(lastName))
                        {
                            userInformation[1] = lastName;
                        }
                        break;

                    case "3":
                        Console.Write("New Age: ");
                        string ageInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out int age) && age > 0)
                        {
                            userInformation[2] = age.ToString();
                        }
                        break;

                    case "4":
                        Console.Write("New GPA: ");
                        string gpaInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(gpaInput) && double.TryParse(gpaInput, out double gpa) && gpa > 0)
                        {
                            userInformation[3] = gpa.ToString();
                        }
                        break;

                    case "5":
                        Console.Write("New Program: ");
                        string program = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(program))
                        {
                            userInformation[4] = program;
                        }
                        break;

                    case "6":
                        Console.Write("New Teacher: ");
                        string teacher = Console.ReadLine().ToLower();
                        if (!string.IsNullOrWhiteSpace(teacher) && IsAllLettersOrSpaces(teacher))
                        {
                            userInformation[5] = teacher;
                        }
                        break;

                    case "7":
                        string newUsername = GetValidUsername();
                        if (!string.IsNullOrWhiteSpace(newUsername))
                        {
                            userInformation[6] = newUsername;
                        }
                        break;

                    case "8":
                        string newPassword = GetValidPassword();
                        if (!string.IsNullOrWhiteSpace(newPassword))
                        {
                            userInformation[7] = newPassword;
                        }
                        break;

                    case "9":
                        return;

                    default:
                        Console.WriteLine("Please select a valid number.");
                        break;
                }
            }
        }

        /// <summary>
        /// verifies if all characters in the string are letters
        /// </summary>
        /// <param name="str">verifies the string</param>
        /// <returns>True if the characters are all letters, else False</returns>
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

        /// <summary>
        /// asks the user to enter a string that only contains letters
        /// </summary>
        /// <param name="prompt">displays the message to the user</param>
        /// <returns>A valid string that only contains letters </returns>
        static string GetValidString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (IsAllLettersOrSpaces(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input. Please enter letters only.");
            }
        }

        /// <summary>
        /// User log in section by verifying the entered username and password
        /// </summary>
        static void Login()
        {
            if (string.IsNullOrWhiteSpace(userInformation[0]))
            {
                Console.WriteLine("No user found. Please register a new user!");
                return;
            }

            Console.WriteLine("LOGIN");
            while (true)
            {
                Console.Write("Enter your username: ");
                string usernameLog = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(usernameLog))
                {
                    Console.WriteLine("Cannot be empty");
                }
                else if (usernameLog != userInformation[6])
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
                        else if (passwordLog != userInformation[7])
                        {
                            Console.WriteLine("Password Invalid");
                        }
                        else
                        {
                            Console.WriteLine("Login Successful!");
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }
}
