package classLessons;

import java.util.Scanner;

public class SwitchCase {

	public static void main(String[] args) {
		// declare a variable
		String strContinueYN;
		boolean blnContinueYN = true;
		
		Scanner input = new Scanner(System.in);
		
		do {
			System.out.println("Do a calculation [y or n]: ");
			strContinueYN = input.nextLine().toLowerCase();
			
			switch (strContinueYN) {
				case "y":
					blnContinueYN = true;
					break;
				case "n":
					blnContinueYN = false;
					break;
				default: 
					strContinueYN = "error";
					break;
			}
		} while (strContinueYN.equals("error"));
		
		System.out.printf("The choice was %b", blnContinueYN);
		
		
		
		
		
		input.close();
	}

}
