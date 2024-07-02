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
