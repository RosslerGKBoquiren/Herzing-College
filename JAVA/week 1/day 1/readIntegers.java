import java.util.Scanner;

public class ReadIntegers {

	public static void main(String[] args) {
		
		//declaration of variables
		String str;
		int number1;
		int number2;
		int number3;
		int sum;
		//initializing the variables
		str = "Herzing College";
		number1 = 10;
		number2 = -4;
		sum = number1 + number2;
		
		System.out.println("Hello." + "\tMy name is Nasrin." + "\nI am an instructor in the " + str + ".");
		System.out.println("The addition of number1 and number2 equals " + sum);
		
		// create a Scanner to obtain input from the command window
		Scanner sc = new Scanner(System.in);
		System.out.println("Please enter an integer number:");
		number3 = sc.nextInt();//nextInt to take the integer that provided by user
		
		System.out.printf("Number3 is %d\n", number3);
		
		sc.close();
		

	}

}
