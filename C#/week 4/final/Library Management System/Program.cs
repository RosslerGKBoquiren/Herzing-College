using Library_Management_System;
using System;
using System.Text.RegularExpressions;

namespace Library_Management_System
{
    internal class Program
    {
        static Library library = new Library();

        static void Main(string[] args)
        {
            // adding some initial data
            AddMember("Alice", "Gold", 5);
            AddMember("Bob", "Silver", 3);
            AddStaff("Charlie", "Librarian");

            AddBook("C# Programming", "Author A", "ISBN001");
            AddBook("Java Programming", "Author B", "ISBN002");

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("********** Welcome to the Library Management System **********\n");
                Console.WriteLine("Please Select an option: \n");
                Console.WriteLine("1 - Add New Member");
                Console.WriteLine("2 - Add New Staff");
                Console.WriteLine("3 - Add New Book");
                Console.WriteLine("4 - Borrow a Book");
                Console.WriteLine("5 - Return a Book");
                Console.WriteLine("6 - Display all Books");
                Console.WriteLine("7 - Display all Members");
                Console.WriteLine("8 - Display all Staff");
                Console.WriteLine("9 - Exit\n");
                Console.ResetColor();
                string userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "1":
                    case "add member":
                        AddNewMember();
                        break;
                    case "2":
                    case "add staff":
                        AddNewStaff();
                        break;
                    case "3":
                    case "add book":
                        AddNewBook();
                        break;
                    case "4":
                    case "borrow book":
                        BorrowBook();
                        break;
                    case "5":
                    case "return book":
                        ReturnBook();
                        break;
                    case "6":
                    case "display books":
                        library.ListBooks();
                        break;
                    case "7":
                    case "display members":
                        library.ListMembers();
                        break;
                    case "8":
                    case "display staff":
                        library.ListStaff();
                        break;
                    case "9":
                    case "exit":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n***** Good Bye! *****");
                        Console.ResetColor();
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid selection, try again!");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddMember(string name, string membershipType, int maxBooksAllowed)
        {
            int id = Library.IdGenerator();
            Member newMember = new Member(name, id.ToString(), "Unknown", $"M{id}", membershipType, maxBooksAllowed.ToString());
            library.AddMember(newMember);
        }

        static void AddStaff(string name, string jobTitle)
        {
            int id = Library.IdGenerator();
            Staff newStaff = new Staff(name, id.ToString(), "Unknown", $"S{id}", jobTitle);
            library.AddStaff(newStaff);
        }

        static void AddBook(string title, string author, string isbn)
        {
            Book newBook = new Book(title, author, isbn);
            library.Addbook(newBook);
        }

        static void AddNewMember()
        {
            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Membership Type: ");
            string membershipType = Console.ReadLine();
            Console.Write("Enter Maximum Books Allowed: ");
            int maxBooksAllowed = int.Parse(Console.ReadLine());

            AddMember(name, membershipType, maxBooksAllowed);
        }

        static void AddNewStaff()
        {
            Console.Write("Enter Staff Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Job Title: ");
            string jobTitle = Console.ReadLine();

            AddStaff(name, jobTitle);
        }

        static void AddNewBook()
        {
            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            AddBook(title, author, isbn);
        }

        static void BorrowBook()
        {
            Console.Write("Enter Book ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            library.BorrowBook(isbn, memberId);
        }

        static void ReturnBook()
        {
            Console.Write("Enter Book ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine();

            library.ReturnBook(isbn, memberId);
        }
    }
}

