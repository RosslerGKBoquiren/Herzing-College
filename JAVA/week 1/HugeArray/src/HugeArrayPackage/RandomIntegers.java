package HugeArrayPackage;

import java.util.Random;

public class RandomIntegers {

	public static void main(String[] args) {
		
		int[] randomNumbers = new int[10];
		arrayWithRandomNumbers(randomNumbers);
		printArray(randomNumbers);
		printArrayReverse(randomNumbers);

	}
	
	public static void arrayWithRandomNumbers(int[] array) {
		Random random = new Random();
		for (int i = 0; i < array.length; i++) {
			array[i] = random.nextInt(100) + 1;
		}
	}
	
	public static void printArray(int[] array) {
		System.out.println("\nArray: ");
		for (int number: array) {
			System.out.print(number + " ");
		}
		System.out.println();
	}
	
	public static void printArrayReverse(int[] array) {
		System.out.println("\nArray Reverse order: "); 
			for (int i = array.length - 1; i >= 0; i--) {
				System.out.print(array[i] + " ");
			}
			
			System.out.println();
	}
}
