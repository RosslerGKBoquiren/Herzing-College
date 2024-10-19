package SumAndAveragePackage;

public class SumAndAverage {

	public static void main(String[] args) {
		
		/* Write a program called SumAndAverage 
		 * to produce the sum from 111 to 8989. 
		 * Also, compute and display the average.
		 * The output shall look like this:
		 * The sum is 40399450
		 * The average is 4550.0
		 * Using a for loop.
		 * Using a while loop. 
		 * Using a do-while loop.*/
		
		int start = 111;
        int end = 8989;
        int count = end - start + 1; // count how many numbers between start and end values + the starting number

        System.out.println("Using for loop:");
        ForLoop(start, end, count);

        System.out.println("\nUsing while loop:");
        WhileLoop(start, end, count);

        System.out.println("\nUsing do-while loop:");
        DoWhileLoop(start, end, count);
		

	}
	
	public static void ForLoop(int start, int end, int count) {
		
		long sum = 0;
		for (int i = start; i <= end; i++) {
			sum += i;
		}
		
		double average = (double) sum / count;
		System.out.println("The sum is " + sum);
		System.out.println("The average is " + average);
	}
	
	
	public static void WhileLoop(int start, int end, int count) {
        
		long sum = 0;
        int i = start;
        while (i <= end) {
            sum += i;
            i++;
        }
        
        double average = (double) sum / count;
        System.out.println("The sum is " + sum);
        System.out.println("The average is " + average);
    }
	
	
	public static void DoWhileLoop(int start, int end, int count) {
		
		long sum = 0;
		int i = start;
		do {
			sum += i;
			i++;
		} while (i <= end);
		
		double average = (double) sum / count;
		System.out.println("The sum is " + sum);
		System.out.println("The average is " + average);
	}

}
