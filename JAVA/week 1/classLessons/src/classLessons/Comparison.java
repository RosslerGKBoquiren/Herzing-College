package classLessons;

import java.util.Scanner;

public class Comparison {

	public static void main(String[] args) {
		// declaration of variables
		int number1;
		int number2;
		
		// create scanner to obtain input 
		Scanner input = new Scanner(System.in);
		
		// request the user to input a number
		System.out.print("Enter the first number: ");
		// save the input in variable number1
		number1 = input.nextInt();
		
		System.out.print("Enter the second number: ");
		number2 = input.nextInt();
		
		
		if (number1 == number2) 
			System.out.printf("%d == %d\n", number1, number2);
		
		if (number1 != number2)
			System.out.printf("%d != %d\n", number1, number2);
		
		if (number1 < number2)
			System.out.printf("%d < %d\n", number1, number2);
		
		if (number1 > number2)
			System.out.printf("%d > %d\n", number1, number2);
		
		if (number1 <= number2)
			System.out.printf("%d <= %d\n", number1, number2);
		
		if (number1 >= number2)
			System.out.printf("%d >= %d\n", number1, number2);
		
		input.close();
	}

}
