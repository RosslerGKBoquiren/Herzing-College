package DiceGamePackage;

import java.util.Scanner;

public class DiceGame {

	public static void main(String[] args) {
		
		String userResponse = "";
		boolean exit = false;
		
		Scanner input = new Scanner(System.in);
		
		do {
			
			System.out.print("Let's play a game of dice! Roll two six-side dices and we will add their total sum.\n");
			System.out.print("\nReady to play? Y or X\n");
			userResponse = input.next().toLowerCase();
			
			if(userResponse.equals("y")) {
				System.out.printf("\nRolling dice #1 and #2...");
				
				int dice1 = (int) (Math.random() * 6) + 1;
				int dice2 = (int) (Math.random() * 6) + 1;
				
				System.out.printf("\nHere are the results: \nDice #1 = %d \nDice #2 = %d", dice1, dice2);
				
				int totalSum = dice1 + dice2;
				System.out.printf("\n\nThe total sum of both dice is: %d\n\n", totalSum);
				
			} else if(userResponse.equals("x")) {
				System.out.print("\nThank you for playing!");
				exit = true;
			}
			else {
				System.out.println("Please provide a valid response. 'Y' to play or 'X' to quit.\n");
			}
			
		} while (!exit);
		
		input.close();

	}

}
