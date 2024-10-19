package GuessRandomNumberPackage;

import java.util.Random;
import java.util.Scanner;

public class GuessRandomNumber {

	public static void main(String[] args) {
		
		PlayGuessingGame();

		}
	
		public static void PlayGuessingGame() {
		
			Scanner input = new Scanner(System.in);
			Random random = new Random();
			boolean exit = false;
			
		
			do {
				int randomNumber = random.nextInt(10) + 1;
				int attempts = 3;
				boolean guessedCorrectly = false;
				
				System.out.println("Guess the number between 1 and 10 inclusively. (3 Attempts left)");
				
				for (int attempt = 1; attempt <= attempts; attempt++) {
					System.out.print("\nAttempt " + attempt + ". Enter your guess: ");
					
					if (!input.hasNextInt()) {
						System.out.println("Invalid input. Please enter a valid number between 1 and 10 inclusively.");
						
						input.next();
						attempt--;
						continue;
					}
					
					int userGuess = input.nextInt();
					
					if (userGuess < 1 || userGuess > 10) {
						System.out.println("Invalid input. The number must be between 1 and 10 inclusively.");
						
						attempt--;
						continue;
					}
					
						if (userGuess == randomNumber) {
							System.out.printf("\nCongratulations! You guess the correct number: %d", randomNumber);
							guessedCorrectly = true;
		                    break;
						} else {
							if (attempt < attempts) {
		                        System.out.printf("\nWrong guess. Try again (%d attempt(s) left)\n", attempts - attempt);
							}
						}
				}
				
			if (!guessedCorrectly) {
				System.out.println("\nSorry, you've used all your tries. The correct number was: " + randomNumber);
			}
			
			System.out.print("\nPlay again? 'x' to exit or Press any key to play again");
			String userInput = input.next();
			
			if (userInput.toLowerCase().equals("x")) {
				exit = true;
			}
				
		} while (!exit); 
			
		System.out.println("\nThank you for playing!");
        input.close();

	}

}
