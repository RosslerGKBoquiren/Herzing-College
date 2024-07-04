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
