using System;

namespace Assignment3
{
    class Program
    { 
        static void Main(string[] args) 
        {
            double firstValueInput;
            double secondValueInput;

            while (true) //loop the first if statement until a proper value is provided
            {
                Console.Write("Enter the first value: ");
                string firstInput = Console.ReadLine();
                if (double.TryParse(firstInput, out firstValueInput)) // if true, firstInput will convert to firstValueInput as a double type
                {
                    break;   
                }
                else 
                {
                    Console.WriteLine("Invalid value. Please enter a valid numeric value."); 
                }
            }

            while (true) // loop the second if statement until a proper value is provided; value 0 is excluded as additional condition
            { 
                Console.Write("Enter the second value: ");
                string secondInput = Console.ReadLine();
                if (double.TryParse(secondInput, out secondValueInput) && secondValueInput != 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric value and that which isn't zero.");
                }
            }

            double displayQuotient = DivideFirstBySecond(firstValueInput, secondValueInput);
            Console.WriteLine("The quotient of the first value divided by the second value is: {0}", displayQuotient);
        }

        static double DivideFirstBySecond(double firstValueInput, double SecondValueInput)
        { 
            double quotient = firstValueInput / SecondValueInput;
            return Math.Round(quotient, 2); // limit variable quotient to 2 decimals
        }
    }
}
