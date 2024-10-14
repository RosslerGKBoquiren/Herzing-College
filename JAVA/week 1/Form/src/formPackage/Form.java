package formPackage;
import java.util.Scanner;
import java.math.BigInteger;

public class Form {

	public static void main(String[] args) {
		
		String firstName;
		String lastName;
		String address;
		String city;
		String postalCode;
		String phoneNumber;
		byte age;
		BigInteger lightTravel;
		BigInteger largeNumber= new BigInteger("9460730472580800");
		float earningPerHour;
		float pastEarning;
		float futureEarning;
		
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Please enter your First Name:");
		firstName = sc.nextLine();
		
		System.out.println("Please enter your Last Name:");
		lastName = sc.nextLine();
		
		System.out.println("Please enter your Address:");
		address = sc.nextLine();
		
		System.out.println("Please enter your City:");
		city = sc.nextLine();
		
		System.out.println("Please enter your Postal Code:");
		postalCode = sc.nextLine();
		
		System.out.println("Please enter your Phone number:");
		phoneNumber = sc.nextLine();
		
		System.out.println("Please enter your Age:");
		age = sc.nextByte(); 
		
		System.out.println("Please enter your Earning per hour:");
		earningPerHour = sc.nextFloat();
		
	
			
		System.out.printf("Your name is: %s %s\n", firstName, lastName);
		System.out.printf("Your address: %s, %s, %s\n", address, city, postalCode);
		System.out.printf("Your phone: %s\n", phoneNumber);
		System.out.printf("Your age is: %d\n", age);
		System.out.printf("Your earning: %.2f\n", earningPerHour);
		
		if (age <= 0) {
			System.out.println("Age must be positive.");
		} else {
			BigInteger bigAge = BigInteger.valueOf(age);
			
			lightTravel = largeNumber.divide(bigAge);
			System.out.printf("Light travel: %s\n", lightTravel);
			
			pastEarning = earningPerHour / age;
			System.out.printf("Your earnings from 100 years ago: %.2f\n", pastEarning);
			
			futureEarning = earningPerHour * 1.7f + age;
			System.out.printf("Your earnings in the near future: %.2f\n", futureEarning);
		}

	}

}
