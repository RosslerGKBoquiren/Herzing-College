package PrintWordPackage;

import java.util.Scanner;

public class PrintWord {

	public static void main(String[] args) {
		
		String printWord = "";
		int number = 0; 
		boolean isValidNumber = false;
		
		Scanner input = new Scanner(System.in);
		
		do {
			System.out.print("Enter a number between 1 to 9 to be printed out as a word: \n");
			
			if(input.hasNextInt()) {
				number = input.nextInt();
				
				if(number >= 1 && number <= 9) {
					isValidNumber = true;
			
				
					switch(number) {
						case 1:
							printWord = "ONE";
							break;
						case 2:
							printWord = "TWO";
							break;
						case 3:
							printWord = "THREE";
							break;
						case 4:
							printWord = "FOUR";
							break;
						case 5:
							printWord = "FIVE";
							break;
						case 6:
							printWord = "SIX";
							break;
						case 7:
							printWord = "SEVEN";
							break;
						case 8:
							printWord = "EIGHT";
							break;
						case 9:
							printWord = "NINE";
							break;
							
					}
					
					System.out.printf("\nThe word for the %d is %s", number, printWord);
				
				} else {
				
					System.out.println("\nPlease provide a valid number between 1 and 9.");
				
				}
				
			} else {
				
				System.out.println("\nPlease provide a number.");
				input.next();			
				
			}
		
		} while (!isValidNumber);
		
	input.close();
	
	}
}


