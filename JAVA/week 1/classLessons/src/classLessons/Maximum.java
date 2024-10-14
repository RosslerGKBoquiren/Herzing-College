package classLessons;

import java.util.Scanner;

public class Maximum {

	public static void main(String[] args) {
		// declare variables
		double number1, number2 ,number3, result;
		
		
		Scanner input = new Scanner(System.in);
		// prompt user to input 3 numbers
		
		System.out.print("Enter three numbers separated by space: ");
		number1 = input.nextDouble();
		number2 = input.nextDouble();
		number3 = input.nextDouble();
		
		
		// determine the maximum value
		result = maximum(number1, number2, number3);
		
		System.out.println("Maximum value is: " + result);
		
		input.close();

	}
	
	// creating a method
	// static to avoid creating instances 
	public static double maximum(double num1, double num2, double num3) {
		
		double maximumValue = num1; // assume num1 is the largest 
		if (num2 > maximumValue) 
			maximumValue = num2;
		if (num3 > maximumValue) 
			maximumValue = num3;
		
		return maximumValue;
	}

}
