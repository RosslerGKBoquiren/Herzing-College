// IEnumerable

using System;
using System.Colletions.Generic

public class Program
{
	public static void Main()
	{
		IEnumerable<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

		foreach (int number in numbers)
		{
			Console.WriteLine(number);
		}
	}
}

//The purpose of IEnumerable is to provide a simple way to iterate over a collection of a specified type 
// Methods: GetEnumerator() which returns an enumerator that iterates through the collection. The enumerator knows where you are in the collection (currenet item) and
// where the next item is (MoveNext method)
//IEnumeranle only allows read access to the collection
// it supports forward only iteration
// it does not support modifying the collection



// ICollection

using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		ICollection<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

		Console.WriteLine("Count: " + numbers.Count);
		numbers.Add(6);
		numbers.Remove(3);

		foreach (int number in numbers)
		{
			Console.WriteLine(number);
		}
	}
}

//The purpose of ICollection builds on IEnumerable by adding size, enumeration and synchronization methods. 
// Properties and Methods:
/*  Count: Gets the number of elements contained in the collection
	IsReadOnly: Gets a value indicating whether the collection is read-only
	Add(T item): Adds an item to the collection
	Remove(T item): Removes the first occurence of a specific object from the collection
	Clear(): removes all items from the colleciton
	Contains(I item): Determines whether the collection contains a specific value
	CopyTo(T[] array, int arrayIndex): Copies the elements of the collection to an array, starting at a particular array index */

// ICollection provides methods to manipulate the collection. It inludes the properties for getting the count and checking if the collection is read-only



// IList

using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

		Console.WriteLine("Count: " + numbers.Count);
		Console.WriteLine("Element at index 1: " numbers[1]);
		numbers[1] = 10;
		numbers.Insert(2, 15);
		numbers.RemoveAt(3);

		foreach (int number in numbers)
		{
			Console.WriteLine(number);
		}
	}
}


//The purpose of IList builds on ICollection by adding methods for indexing
/* Properties and methods
	inherits all properties and methods from ICollection
	this[int index]: gets or sets the element at the speficied index
	IndexOf(T item): Determines the index of a specific item in the list
	Insert(int index, T item): inserts an item at the specified index
	RemoveAt(int index): Removes the item at the specified index */


// System.String
// it is a class in C# for storing and manipulating text. It provides many methods to perform operations like:
/*	Concatenating strings
	replacing characters
	removing whitespace
	capitalizing text */


// Building strings in C#
/* System.String is a powerful class with many useful methods nut it has a significant limitaion: it is immutable. 
Once created, a string cannot be changed. Any modifications create new string instances which can be inefficient for repeated changes. 

string greetingText = "Hello from all the guys at Wrox Press. ";
greetingText += "We do hope you enjoy this book as much as we enjoyed writing it.";


When this code runds, a System.String object is created to hold the initial text.
Adding more text creates a new string with the comnined content.
The original string is discarded and cleaned up


string text = "Hello from all the guys at Wrox Press.";
text = text.Replace('a', 'b').Replace('b', 'c').Replace('c', 'd'); // and so on for other letters

using Replace(), a new string is created for each replacement leading to many new strings and potential performance problems. */




// System.Text.StringBuilder Class
/* StringBuilder is less powerful than String in terms of supported methods, focusing on substitution and appending or removing text.
However, it is much more efficient for these operations. 

Properties:
	Length: the current length of the string
	Capacitt: the maximum length the StringBuilder can handle before needing more memory 



using System.Text;

StringNuilder sb = new StringBuilder(150); // sets initial capacitt to 150 characters
sb.Append("Hello from all the guys at Wrox Press. ");
sb.Append("We do hope you enjoy this book as much as we enjoued writing it. ");

COnsole.WriteLine(sb.ToString())

CONLUSION:

use StringBuilder for efficient string modifications and manipulations.
use String to store or display the final result

*/


//StringBuilder Members
/* Constructors
	with initial string and capacity:  StringBuilder sb = new StringBuilder("Hello", 50);
	with only a string: StringBuilder sb = new StringBuilder("Hello");

	Properties:
		Lenght: current lenght of the string
		Capacitt: maximum length nefore requiring more memory
		MaxCapacity: Read-only property indicating the maximum limit, defaulting to int.MaxValue

	Usage:
	To get a string: Use the ToString() method.
	string result = sb.ToString();
	

	When to use:
		StringBuilder: best for manipulating strings for better performace
		string: better for simple operations like concatenating two strings. 
*/



// Format strings
// When displaying the contents of a varianle, its often necessaru to show them in various formats, depending on culture and locale. 
// example: 10 june 2007 or 10 Jun 2007
/* To accomodate different formats, classes can implement the IFormattable interface

	Formatting options:
	1. width and alignment
		Left: use negative number {0, -10}
		right: use positive numner {0, 10}

	2. format specifiers
		currency {0:C}
		scientific notation: {0:E}
		Zero Padding: {0:0000}*/



// Handling errors in C#
/* Try block and Catch block

	Try block
	You write the code that you want to run inside a try block.
	the program will try to execute all the lines inside the try block one by one.
	If everything goes well, the program moves on to the next part after the try block.


	Catch block
	right after, you write one or more catch blocks.
	Each catch block is designed to handle a specific type of error called an exception. 
	If an error occurs in the try block, the program jumps to the appropriate catch block and runs the code inside it
	after the catch block finishes, the program continues with the code that comes after the catch blocks.  

	Example:

	using System;

	class Program
	{
	    static void Main()
	    {
	        try
	        {
	            // Code that may throw different types of exceptions
	            string input = "123a"; // This will cause a FormatException
	            int number = Int32.Parse(input);

	            int result = 10 / number; // This will cause a DivideByZeroException if number is zero
	        }
	        catch (FormatException formatEx)
	        {
	            // Handle FormatException (e.g., invalid input format)
	            Console.WriteLine("Input was not in a correct format.");
	            Console.WriteLine("Error details: " + formatEx.Message);
	        }
	        catch (DivideByZeroException divideByZeroEx)
	        {
	            // Handle DivideByZeroException (e.g., division by zero)
	            Console.WriteLine("Cannot divide by zero.");
	            Console.WriteLine("Error details: " + divideByZeroEx.Message);
	        }
	        catch (Exception ex)
	        {
	            // Handle any other exceptions
	            Console.WriteLine("An unexpected error occurred.");
	            Console.WriteLine("Error details: " + ex.Message);
	        }
	        finally
	        {
	            // Code that runs regardless of whether an exception is thrown or not
	            Console.WriteLine("This code runs no matter what.");
	        }
	    }
	}
	

	Catching specific exceptions:

	1. Catch block syntax
	This is simiar to a method parameter to specify which ttpe of exception to catch.
	For example, catch(FormatException fEx) catches a FormatException and stores the exception details in the variable fEx
	It is a specific type of exception that occurs when a string is not in a valid format to be converted to a number

	2. Exception Object
	While an exception is caught, the variable fEx contains an object with the details about the error. 
	This object has various fields you can examine to understnad what went wrong.

	3. Common fields in Exception Objects
		- message fields: text description of the error. You vsn udr this message to inform the user about what went wrong
		or log the details for debugging.

		ex: try
		{
		    int number = Int32.Parse("invalid number");
		}
		catch (FormatException fEx)
		{
		    Console.WriteLine("An error occurred: " + fEx.Message);
		}
		

		- StackTrace fields: show the sequence of method calls that led to the exception. THis is helpful for debugging
		because it shows where in the code the error occured


	4. Advanced Exception handlind
		- Finally Block: it runs the code that execute whether or not an exception is thrown. It is often used for cleanup 
		tasks, like closing files or releasing resources.

		- Throw statement: You can use this to pass the exception up the stack, meaning you throw the exception to be handled 
		at a higher level



	Unhandled Exceptions in Simple Terms

	What happens when there is no Catch Block

	1. Error example: causes an OverflowException

	2. No matching catch block: the OverflowException is NOT caught

	3. Searching for a catch block: the process repeats, moving up the chain of calling methods.

	4. Execution continues: if a matching block is found, it runs and the program continues. The original method that 
	caused the error does not continue running

	5. Method returns: if the try block is a method, the method stops and returns to the method that called it

	6. Program termination: the program stops with an unhandled exception


Using multiple Catch Handlers

Different errors cause different types of exceptions. You can handle these by using multiple catch blocks, one for each type of exception. 

example: 

try
{
    // Code that might throw different types of exceptions
    string input = "123a"; // Causes FormatException
    int number = Int32.Parse(input);

    int result = 10 / number; // Could cause DivideByZeroException
}
catch (FormatException formatEx)
{
    // Handle FormatException
    Console.WriteLine("Input is not in the correct format.");
}
catch (DivideByZeroException divideByZeroEx)
{
    // Handle DivideByZeroException
    Console.WriteLine("Cannot divide by zero.");
}
catch (Exception ex)
{
    // Handle any other exceptions
    Console.WriteLine("An unexpected error occurred.");
}



Catching multiple Exceptions in Simple terms

1. Exception Hierarchy: exceptions are organized into families
FormatException and OverflowException are part of the SystemException which is part of a larger family called Exception.

2. Catching general exceptions: instead of catching each specific exception, you can catch a general exception like
SystemException or Exception. Catching Exception will handle all possinle exceptions. 

Example:

try
{
    // Code that might throw different types of exceptions
}
catch (SystemException sysEx)
{
    // Handle system exceptions like FormatException, OverflowException, etc.
    Console.WriteLine("A system error occurred: " + sysEx.Message);
}
catch (Exception ex)
{
    // Handle any other exceptions
    Console.WriteLine("An unexpected error occurred: " + ex.Message);
}


Simplified Catch-All

try
{
    // Code that might throw different types of exceptions
}
catch
{
    // Handle any exception
    Console.WriteLine("An error occurred.");
}



Order of catch Blocks

1. Specific before general
Place more specific catch blocks like FormatException before general ones like Exception

2. First Match Wins
When an exception occurs, the first matching catch is executed, and the rest are ignored. 


example: 

try
{
    // Code that might throw different types of exceptions
}
catch (FormatException formatEx)
{
    // Handle FormatException
    Console.WriteLine("Input format is incorrect.");
}
catch (Exception ex)
{
    // Handle all other exceptions
    Console.WriteLine("An unexpected error occurred.");
}



Why throwing exceptions

When writing a method, sometimes you get input that doesnt make sense. Instead of returning a meaningless value, its
better to throw an exception to indicate something went wrong.

Imagine you have called monthName that takes an integer and returns that corresponding month name.

- monthName(1) returns January
- monthName(12) returns december

but what if the input is less than 1 or greater than 12? Instead of returning something meaningless, you should throw an exception

using ArgumentOutOfRangeException

example:

public string monthName(int month)
{
    switch (month)
    {
        case 1: return "January";
        case 2: return "February";
        case 3: return "March";
        case 4: return "April";
        case 5: return "May";
        case 6: return "June";
        case 7: return "July";
        case 8: return "August";
        case 9: return "September";
        case 10: return "October";
        case 11: return "November";
        case 12: return "December";
        default:
            throw new ArgumentOutOfRangeException("month", "Month must be between 1 and 12.");
    }
}



Why use Finally Blocks 

When an exceptino is thrown, it changes the flow of the program. This means that you cant be sure that every statement 
will run as excepted

Conside the problem below:

StreamReader reader = null;
try
{
    reader = File.OpenText("file.txt");
    // Read from the file...
}
catch (Exception ex)
{
    // Handle the exception...
}
finally
{
    if (reader != null)
    {
        reader.Close(); // Ensure the file is closed
    }
}


Key points:

1. Resource management
if you open a file or a resource, you need to make sure it gets closed or released. If not, it may lead to
problems 

2. Finally block ensures that certain code runs no matter what, even if an exception is thrown

3. always executes
the finally block will always execute whether or not an exception is thrown.
using a finally block ensures that critical code such as releasing resources always runs. This prevents resource leaks
and other issues that can arise if an exceptino interrupts the normal flow of your program. */



// Remembering arrays
/* Arrays are a way to store multiple values of the same type in a single variable.

key points:

1. declaration
int[] numbers
declare an array with a type gollowed by square brackets and a variable

2. initialization
numbers = new int[5]
initialize the array with a specified size

or 

int[] numbers = {1, 2, 3, 4, 5};

3. accessing elements
access array elements using an index, starting at 0

4. looping through arrays
use a loop to iterate through all elements
for(int i = 0; 1 < numbers.Length; i++)
{
	Console.WriteLine(numbers[i]);
}  

example

using System;

class Program
{
	static void Main()
	{
		// declare and initialize an array
		int[] numbers = {1, 2, 3, 4, 5};

		// access and modify array elements
		numbers[1] = 10;

		// loop through the array and print each element
		for (int i = 0; i < numbers.Length; i++)
		{
			Console.WriteLine(numbers[i]);
		}
	}
}
*/



// Array and Collection interfaces in C# .NET

/* IEnumerable
	Purpose: Enables iteration over a collection. Allows the use of foreacj to loop through array elements
	for example:

	intp[] numbers = {1, 2, 3, 4, 5};
	foreach (int number in numbers)
	{
		Console.WriteLine(number);
	}

	It simplifies looping through the array



	ICollection
	PUrpose: Extends IEnumerable with additional properties and methods
	Properties and Methods:
		Count: gets the number of elements in the collection
		IsSynchronized: indicates if access to the collection is synchronized
		SyncRoot: provides an object for synchronization

	example:
	int[] number = {1, 2, 3, 4, 5};
	ICollection collection = numbers;
	Console.WriteLine(collection.Count); // outputs the number of elements

	it provides more informaiton and control over the collection's elements



	IList
	purpose: extends ICollection with additional methods and properties for more detailed manipulation
	key properties and methods:
		This[int index]: gets or sets the element at the specified index
		Add(object value): adds an item to the collection
		Remove(object value): removes the first occurence of a specific object from the collection
		Insert(int index, object value): inserts an item at the specified index
		RemoveAt(int index): removes the item at the specified index

	example:
	int[] numbers = {1, 2, 3, 4, 5};
	IList list = numbers;
	Console.WriteLine(List[0]); // outputs the first element
	list[0] = 10; // sets tje first element to 10

	offers more flexibility for modifying the collection



	Here is a complete example demonstrating the use of these interfaces

	using System;
	using System.Collections;

	class Program
	{
		static void Main()
		{
			int[] numbers = {1, 2, 3, 4, 5};

			//IEnumerable
			IEnumerable enumerable = numbers;
			foreach (int number in enumerable)
			{
				Console.Write(number)
			}


			//ICollection
			ICollection collection = numbers;
			Console.WriteLine("Count: " + collection.Count);


			//IList
			IList list = numbers;
			list[0] = 10; // modifying the first element
			list.Add(6); // adding a new element

			foreach (int number in list)
			{
				Console.WriteLine(number);
			}
		}
	} 



	More about ICollection
	key features:

	1. adding and removing elements
		Add()
		Remove()
		Clear(): removes all elements from the collection

	2. Checking and copying elements
		Contains(): checks if an element is in the collection
		CopyTo(): Copies elements to an array

	3. Counting elements
		Count()

	4. Thread Safety
		IsSynchronized: indidicates if the collection is thread-safe
		SyncRoot: provides an object for synchronizing access to the collection


Example:

using System;
using System.Collections;

class Program
{
	static void Main()
	{
		ArrayList myList = new ArrayList();

		// add elements
		myList.Add(1);
		myList.Add(2);
		myList.Add(3);


		// check if element exists
		bool containsTwo = myList.Contains(2);
		Console.WriteLine("Contains 2: " + containsTwo);

		// get count
		int count = myList.Count;
		Console.WriteLine("Count: " + count);

		// copy to array
		int[] array = new int[myList.Count];
		myList.CopyTo(array, 0);

		// remove element
		myList.Remove(2);

		// final count
		Console.WriteLine("Count after removal: " + myList.Count);
	}
}


	Continue IList

	IList represents a collection of objects that can be accessed by index. it allows you to store, manipulate, and access
	a list of items. 

	key features:
	1. Access by index:
	you can get or set items in the list using an index. 
	example: myList[0] = 10; // sets the first item to 10

	2. methods
		Add()
		Remove()
		Insert(): inserts an item at a specific index
		RemoveAt(): removes the item at a specific index

	3. Properties
		Count
		IsReadOnly

	4. Advanced features
		Sort()
		BinarySearch(): searches for an item using a binary search algorithm



	Real World examples:
	1. To do list
	Tasks are stored in an IList colleciton, allowing easy additon, removal and updating of tasks

	2. Ecommerce website
	orders are stored in an IList collection, making it easy to manage orders

	3. Inventory management system
	products in stock are stored in an IList collection facilitating updates and management

	4. Social media platform
	user posts are stored in an IList collection, enabling easy display and interaction

	5. Music player application
	songs in a playlist are stored in an IList collection, allowing easy manipulation of the playlist.



	example:

	using System;
	using System.Collections.Generic;

	class Program
	{
		static void Main()
		{
			IList<int> myList = new List<int> {1, 2, 3};


			// add an item
			myList.Add(4);

			// remove an item
			myList.Remove(2);

			// insert an item
			myList.Insert(1, 5);

			// access by index
			Console.WriteLine(myList[0]); // output: 1

			// get count
			Console.WriteLine(myList.Count); // Output: 4

			// sort the list
			myList.Add(0);
			((List<int>)myList).Sort();

			foreach(var item in myList)
			{
				Console.WriteLine(item);
			}
		}
	}



	Procedures and Functions in C# .NET

	Procedures and functions are blocks of code that can be reused to make your programs more organized and modular


	Procedures:
	definition: a block of code that performs a specific tasks and does not return a value
	Syntax: using the void keyword
	example:

	void PrintMessage()
	{
		Console.WriteLine("Hello, World!");
	}


	calling a procedure:
	PrintMessage(); // this will print "Hello, World!" to the console.



	Functions:
	definition: Similar to procedures but return a value
	Syntax: defined with a return type
	example:

	int AddNumbers(int a, int b)
	{
		return a + b;
	}

	calling a function:
	int result =AddNumbers(2, 3); // result will be 5
	Console.WriteLine(result); // this will print 5 to the console



	Parameters in procedures and functions

	Both can take parameters to make them more flexible and reusable

	void PrintMessage(string message)
	{
		Console.WriteLine(message);
	}

	// calling the procedure
	PrintMessage("Hello, World!")



	Function with parameters
	int MultiplyNumbers(int a, int b)
	{
		return a * b;
	}


	In summary
	Procedures do not return a value for a specific task
	Functions return a value used for tasks that produce result
	Parameters allow both procedures and functions to accept input values*/