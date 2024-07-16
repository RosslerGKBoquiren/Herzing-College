/*

IEnumerable interface can be used in C#

using System;
using System.Collections;
using System.Collections.Generic;

class Program
{
	static void Main()
	{
		// create a list of integers
		List<int> numbers = new List<int> { 1, 2, 3, 4, 5};

		// iterate over the list using foreach
		foreach (int number in numbers)
		{
			Console.Writeline(number);
		}

		// Use LINQ to query the list
		IEnumerable<int> evenNumbers = GetEvenNumbers(numbers);

		// iterate over the even numbers using foreach
		foreach(int number in evenNumvers)
		{
			Console.WriteLine(number);
		}
	}

	static IEnumerable<int> GetEvenNumbers(IEnumerable<int> numbers)
	{
		foreach(int number in numbers)
		{
			if (number % 2 == 0)
			{
				yield return number;
			}
		}
	}
}


Self referential classes

in object oriented programing, a self-referential class is a class that contains a reference to an instance
of its own type as a member variable. This can be achieved by declaring a class with a member variable of the same claass type

Self referential classes are crucial for representing hierarchical structures like trees, graphs, and linked lists.
These structures are widely used in software development for data organization and manipulation. 

Benefits:
Recursive algorithms: enable the implementation of recursive algorithms which solve problems by breaking them down into
smaller sub problems. For example, a recursive algorithm can traverse a tree.

Dynamic data structures: allow for the creation of flexivle and dunamic data structures, linking objects of the same
class in various ways.

example:

public class FruitBasket
{
	public string Fruit; // data stored in the string Fruit
	public FruitBasket Next; // reference to the next FruitBasket

	public FruitBasket(string fruit)
	{
		Fruit = fruit;
		Next = null;
	}
}

class Program
{
	static void Main()
	{
		FruitBasket red = new FruitBasket('apple');
		FruitBasket yellow = new FruitBasket('banana');
		FruitBasket pink = new FruitBasket(cherry);

		red.Next = yellow;
		yellow.Next = pink;

		FruitBasket current = red;
		while (current != null)
		{
			Console.WriteLine(current.Fruit)
			current = current.Next;
		}
	}
}

*/