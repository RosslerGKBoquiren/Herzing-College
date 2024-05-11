using System;

namespace GranolaSales
{
    class Program
    { 
        static void Main(string[] args) 
        {
            // students sell the granola bars for $1.50 per bar
            decimal unitCost = 1.50m;
            // each case of granola has 100 bars
            int unitInCases = 100;
            // each case cost $100.00
            decimal caseCost = 100.00m;
            // number of sold cases
            int soldCases = 29;

            // total cost of sold cases
            decimal totalCostSoldCases = soldCases * caseCost;
            // gross sales
            decimal grossSales = (soldCases * unitInCases) * unitCost;
            // net sales 
            decimal netSales = grossSales - totalCostSoldCases;
            // calculate student government association fees using ref
            CalculateFees(ref netSales);

            // bottom line
            decimal bottomLine = netSales;

            Console.WriteLine("")
            Console.WriteLine("The total money they would make is: {0:C}", bottomLine);

        }
        static void CalculateFees(ref decimal netSales)
        {
            decimal feesNetSales = netSales * 0.10m;
            netSales -= feesNetSales;
        }
    }
}
