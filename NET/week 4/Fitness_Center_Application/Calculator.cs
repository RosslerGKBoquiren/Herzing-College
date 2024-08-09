using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// project
namespace Fitness_Center_Application
{
    public static class Calculator
    {
        public static double CalculateBMI(double weight, double height)
        {
            return (weight / Math.Pow(height, 2)) * 703;
        }

        public static double CalculateBodyFat(double bmi, int age, bool isMale)
        {
            if (isMale)
            {
                return (1.20 * bmi) + (0.23 * age) - (10.8 * 1) - 5.4;
            }
            else
            {
                return (1.20 * bmi) + (0.23 * age) - 5.4;
            }
        }

        public static string DetermineBMICategory(double bmi)
        {
            if (bmi <= 17.5)
            {
                return "Underweight";
            }
            else if (bmi > 17.5 && bmi < 18.5)
            {
                return "Lowest Normal";
            }
            else if (bmi >= 18.5 && bmi < 22)
            {
                return "Middle Normal";
            }
            else if (bmi >= 22 && bmi < 24.9)
            {
                return "Highest Normal";
            }
            else if (bmi >= 24.9 && bmi < 30)
            {
                return "Obesity";
            }
            else
            {
                return "Morbid Obesity";
            }
        }

        public static string DetermineRisk(double bmi)
        {
            if (bmi < 18.5 || bmi >= 25)
            {
                return "High Risk";
            }
            return "Low Risk";
        }

        public static string GetImagePath(double bmi, bool isMale)
        {
            string basePath = @"images\";

            if (isMale)
            {
                if (bmi <= 17.5)
                {
                    return basePath + "underweightm.jpg";
                }
                else if (bmi > 17.5 && bmi < 18.5)
                {
                    return basePath + "lowestNormalm.jpg";
                }
                else if (bmi >= 18.5 && bmi < 22)
                {
                    return basePath + "middleNormalm.jpg";
                }
                else if (bmi >= 22 && bmi < 24.9)
                {
                    return basePath + "highestNormalm.jpg";
                }
                else if (bmi >= 24.9 && bmi < 30)
                {
                    return basePath + "obesitym.jpg";
                }
                else
                {
                    return basePath + "morbidObesitym.jpg";
                }
            }
            else
            {
                if (bmi <= 17.5)
                {
                    return basePath + "anorexiaf.jpg";
                }
                else if (bmi > 17.5 && bmi < 18.5)
                {
                    return basePath + "lowestNormalf.jpg";
                }
                else if (bmi >= 18.5 && bmi < 22)
                {
                    return basePath + "middleNormalf.jpg";
                }
                else if (bmi >= 22 && bmi < 24.9)
                {
                    return basePath + "highestNormalf.jpg";
                }
                else if (bmi >= 24.9 && bmi < 30)
                {
                    return basePath + "obesityf.jpg";
                }
                else
                {
                    return basePath + "morbidObesityf.jpg";
                }
            }
        }
    }
}
