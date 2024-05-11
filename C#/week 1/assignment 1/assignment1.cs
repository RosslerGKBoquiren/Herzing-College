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
            // price of total sold cases
            decimal totalCostSoldCases = soldCases * caseCost;
            // gross sales
            decimal grossSales = (soldCases * unitInCases) * unitCost;
            // net sales 
            decimal netSales = grossSales - totalCostSoldCases;
            // student government association fees
            decimal feesNetSales = netSales * 0.10m;

            // bottom line
            decimal bottomLine = netSales - feesNetSales;

            Console.WriteLine($"The total money they would make is: ${bottomLine}");

        }
    }
}