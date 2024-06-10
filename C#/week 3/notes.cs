// access modifiers

1. public
access isn't restricted

2. protected
access is limited to the containing class or tpes derived from the containing class

3. internal
access is limited to the currnet assembly

4. private
access is limited to the containing type // most restrictive, members declared with the private access are only accessible within the class they are declared
// when marked with a private class, other class cannot inherit them

5. file
the declared type is only visible in the currnet source file. File scoped types are generally
used for source generators


// Dictionary pros and cons
1. key-based access
A dictionary allows you to access elements using a key, which in this case is an integer representing an employee ID. It 
provides an efficient way to access specific employees without iterating over the entire collection.  

2. Handling non sequential and sparse data  

3. flexibility in modifying the collection 



namespace ConsoleApp10
{
	internal class Program
	{
		static void Main (string[] args)
		{
			//key - value
			//declaration and initialization or a dictionary
			Dictionary<int, string> employees = new Dictionary <int, string>();

			//adding items to our dictionary
			employees.Add(101, "John Doe");
			employees.Add(102, "Bob Smith");
			employees.Add(103, "Rob Smith");
			employees.Add(104, "Flob Smith");
			employees.Add(105, "Dod Smith");

			//accessing items of my dictionary
			string name = employees[102];
			Console.WriteLine(name);

			//update items of a dictionay
			employees[102] = "Jane Smith";

			//removing items from dictionary
			employees.Remove(102);

			// read all items from our dictionary
			foreach (KeyValuePair<int, string> employee in employees)
			{
				Console.WriteLine($"ID: {employee.Key} and Name: {employee.Value}");
			}

			//duplicating the key
			//employees.Add(104, "Mike Bike"); // can't do this because 104 already exists

			//handling duplicates
			if(!employees.ContainsKey(106))
			{
				employees.Add(106, "Mike Bike");
			}
			// using counter to increment the ID# and find an ID# that doesn't exist in the dictionary
			int counter = 101;
			while (employees.ContainsKey(counter))
			{
				counter++;
			}
			employees.Add(counter, "Mike Bike");

			//TryAdd
			bool added = employees.TryAdd(107, "Sam Chabot"); // returns true if not exists, false if otherwise
			if (!added)
			{
				Console.WriteLine("Employee already added!");
			}
			Console.WriteLine("\nNew Dictionary Items: ");
			foreach (KeyValuePair<int, string> employee in employees)
			{
				Console.WriteLine($"ID: {employee.Key} and Name: {employee.Value}");
			}

			Console.ReadKey();
		}
	}
}