using System;

namespace WeightConversion
{
    class Program
    {
       const double conversionFactor = 2.2;
       static void Main(string[] args) 
        {
            Console.Write("Enter a weight in kilograms: ");
            double kilogramsInput = Convert.ToDouble(Console.ReadLine());
            double poundsOutput = KilogramToPounds(kilogramsInput);
            Console.WriteLine("The weight {0} kilograms is equivalent to {1} pounds.", kilogramsInput, poundsOutput);

            Console.Write("Enter a weight in pounds: ");
            double poundsInput = Convert.ToDouble(Console.ReadLine());
            double kilogramsOutput = PoundsToKilograms(poundsInput);
            Console.WriteLine("The weight {0} pounds is equivalent to {1} kilograms.", poundsInput, kilogramsOutput);
        }

        static double KilogramToPounds(double kilogramsInput) 
        {
            double inPounds = kilogramsInput * conversionFactor;
            return inPounds;
        }

        static double PoundsToKilograms(double poundsInput)
        {
            double inKilograms = Math.Round(poundsInput / conversionFactor);
            return inKilograms;
        }
            
    }
}