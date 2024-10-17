package PrintWordPackage;

public class IllegalFields {

	public static void main(String[] args) {
		
		// legal field names
		String firstName;
		int age;
		boolean isValidName = true;
		
		// Illegal field names
		String first-name; // Syntax Error on token "first": name cannot be resolve into a variable
		int 1stNum; // Syntax error on token "1", delete this token
		double #value; // Syntax error on token "Invalid Character", delete this token

	}

}
