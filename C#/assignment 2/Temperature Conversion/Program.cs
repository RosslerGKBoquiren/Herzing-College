using System;

namespace TemperatureConversion
{
    class Program
    {
        const double ToFahrenheitFormula = 9.00 / 5.00;
        const double ToCelsiusFormula = 5.00 / 9.00;
        const double TemperatureFactor = 32.00;
        static void Main(string[] args)
        {
            /* const double ToFahrenheitFormula = 9.00 / 5.00;
            const double ToCelsiusFormula = 5.00 / 9.00;
            const double TemperatureFactor = 32.00; */

            Console.Write("Please enter a temperature in Celsius: ");
            double celsiusInput = Convert.ToDouble(Console.ReadLine());
            double fahrenheitOutput = CelsiusToFahrenheit(celsiusInput);
            Console.WriteLine("The temperature {0} Celsius is equivalent to {1} Fahrenheit", celsiusInput, fahrenheitOutput);

            Console.WriteLine("Please enter a temperature in Fahrenheit: ");
            double fahrenheitInput = Convert.ToDouble(Console.ReadLine());
            double celsiusOutput = FahrenheitToCelsius(fahrenheitInput);
            Console.WriteLine("The temperature {0} Fahrenheit is equivalent to {1} Celsius", fahrenheitInput, celsiusOutput);
        }
        static double CelsiusToFahrenheit(double celsiusInput)
        {
            double inFahrenheit = celsiusInput * ToFahrenheitFormula + TemperatureFactor;
            return inFahrenheit;
        }

        static double FahrenheitToCelsius(double fahrenheitInput)
        {
            double inCelsius = Math.Round((fahrenheitInput - TemperatureFactor) * ToCelsiusFormula);
            return inCelsius;
        }
    }
}

