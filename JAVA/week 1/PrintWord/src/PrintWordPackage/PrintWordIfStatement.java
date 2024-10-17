package PrintWordPackage;

import java.util.Scanner;

public class PrintWordIfStatement {

    public static void main(String[] args) {
        
        String printWord = "";
        int number = 0; 
        boolean isValidNumber = false;
        
        Scanner input = new Scanner(System.in);
        
        do {
            System.out.print("Enter a number between 1 to 9 to be printed out as a word: \n");
            
            if (input.hasNextInt()) {
                number = input.nextInt();
                
                if (number >= 1 && number <= 9) {
                    isValidNumber = true;
                    
                    if (number == 1) {
                        printWord = "ONE";
                    } else if (number == 2) {
                        printWord = "TWO";
                    } else if (number == 3) {
                        printWord = "THREE";
                    } else if (number == 4) {
                        printWord = "FOUR";
                    } else if (number == 5) {
                        printWord = "FIVE";
                    } else if (number == 6) {
                        printWord = "SIX";
                    } else if (number == 7) {
                        printWord = "SEVEN";
                    } else if (number == 8) {
                        printWord = "EIGHT";
                    } else if (number == 9) {
                        printWord = "NINE";
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