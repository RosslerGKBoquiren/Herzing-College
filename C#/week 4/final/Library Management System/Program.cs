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
            // Adding initial members
            library.AddMember(new Member("Michael Jordan", Library.IdGenerator().ToString(), "1234567890", "M1", "Gold", "5"));
            library.AddMember(new Member("LeBron James", Library.IdGenerator().ToString(), "2345678901", "M2", "Silver", "3"));
            library.AddMember(new Member("Kobe Bryant", Library.IdGenerator().ToString(), "3456789012", "M3", "Siler", "3"));
            library.AddMember(new Member("Shaquille O'Neal", Library.IdGenerator().ToString(), "4567890123", "M4", "Bronze", "1"));
            library.AddMember(new Member("Tim Duncan", Library.IdGenerator().ToString(), "5678901234", "M5", "Gold", "5"));

            // Adding initial staff
            library.AddStaff(new Staff("Phil Jackson", Library.IdGenerator().ToString(), "6789012345", "S1", "Library Manager"));
            library.AddStaff(new Staff("Gregg Popovich", Library.IdGenerator().ToString(), "7890123456", "S2", "IT Support"));
            library.AddStaff(new Staff("Pat Riley", Library.IdGenerator().ToString(), "8901234567", "S3", "Public Relations"));
            library.AddStaff(new Staff("Steve Kerr", Library.IdGenerator().ToString(), "9012345678", "S4", "Librarian"));
            library.AddStaff(new Staff("Red Auerbach", Library.IdGenerator().ToString(), "0123456789", "S5", "Information Specialist"));

            // Adding initial books
            library.Addbook(new Book("The Art of War", "Sun Tzu", "9780140449198"));
            library.Addbook(new Book("The History of the Peloponnesian War", "Thucydides", "9780140440393"));
            library.Addbook(new Book("The Diary of a Young Girl", "Anne Frank", "9780553296983"));
            library.Addbook(new Book("The Prince", "Niccolò Machiavelli", "9780486272740"));
            library.Addbook(new Book("Guns, Germs, and Steel", "Jared Diamond", "9780393317558"));

            // List initial data
            Console.WriteLine("Initial Members:");
            library.ListMembers();
            Console.WriteLine("\nInitial Staff:");
            library.ListStaff();
            Console.WriteLine("\nInitial Books:");
            library.ListBooks();

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
                Console.WriteLine("9 - Modify Book");
                Console.WriteLine("10 - Modify Member");
                Console.WriteLine("11 - Modify Staff");
                Console.WriteLine("12 - Delete Book");
                Console.WriteLine("13 - Delete Member");
                Console.WriteLine("14 - Delete Staff");
                Console.WriteLine("15 - Exit\n");
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
                    case "modify book":
                        ModifyBook();
                        break;
                    case "10":
                    case "modify member":
                        ModifyMember();
                        break;
                    case "11":
                    case "modify staff":
                        ModifyStaff();
                        break;
                    case "12":
                    case "delete book":
                        DeleteBook();
                        break;
                    case "13":
                    case "delete member":
                        DeleteMember();
                        break;
                    case "14":
                    case "delete staff":
                        DeleteStaff();
                        break;
                    case "15":
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

        static void AddNewMember()
        {
            string namePattern = @"^[a-zA-Z\s]+$";
            string membershipTypePattern = @"^(Gold|Silver|Bronze)$";
            string contactNumberPattern = @"^\d{10,}$";

            Console.WriteLine("Enter Member Details (or type 'exit' to cancel):");

            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit") return;
            while (!Regex.IsMatch(name, namePattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name. Name can only include letters. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Member Name: ");
                name = Console.ReadLine();
                if (name.ToLower() == "exit") return;
            }

            Console.Write("Enter Contact Number: ");
            string contactNumber = Console.ReadLine();
            if (contactNumber.ToLower() == "exit") return;
            while (!Regex.IsMatch(contactNumber, contactNumberPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid contact number. It must be at least 10 digits long. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Contact Number: ");
                contactNumber = Console.ReadLine();
                if (contactNumber.ToLower() == "exit") return;
            }

            Console.Write("Enter Membership Type (Gold, Silver, Bronze): ");
            string membershipType = Console.ReadLine();
            if (membershipType.ToLower() == "exit") return;
            while (!Regex.IsMatch(membershipType, membershipTypePattern, RegexOptions.IgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid membership type. Please enter Gold, Silver, or Bronze.");
                Console.ResetColor();
                Console.Write("Enter Membership Type (Gold, Silver, Bronze): ");
                membershipType = Console.ReadLine();
                if (membershipType.ToLower() == "exit") return;
            }

            int maxBooksAllowed = 0;
            if (string.Equals(membershipType, "Gold", StringComparison.OrdinalIgnoreCase))
            {
                maxBooksAllowed = 5;
            }
            else if (string.Equals(membershipType, "Silver", StringComparison.OrdinalIgnoreCase))
            {
                maxBooksAllowed = 3;
            }
            else if (string.Equals(membershipType, "Bronze", StringComparison.OrdinalIgnoreCase))
            {
                maxBooksAllowed = 1;
            }

            library.AddMember(new Member(name, Library.IdGenerator().ToString(), contactNumber, $"M{Library.IdGenerator()}", membershipType, maxBooksAllowed.ToString()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Member added successfully.");
            Console.ResetColor();
        }

        static void AddNewStaff()
        {

            string namePattern = @"^[a-zA-Z\s]+$";
            string contactNumberPattern = @"^\d{10,}$";
            string jobTitlePattern = @"^(Library assistant|Library technician|Information specialist|Public relations|IT support|Librarian|Library manager|Circulation manager)$";

            Console.WriteLine("Enter Staff Details (or type 'exit' to cancel):");

            Console.Write("Enter Staff Name: ");
            string name = Console.ReadLine();
            if (name.ToLower() == "exit") return;
            while (!Regex.IsMatch(name, namePattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid name. Name can only include letters. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Staff Name: ");
                name = Console.ReadLine();
                if (name.ToLower() == "exit") return;
            }

            Console.Write("Enter Contact Number: ");
            string contactNumber = Console.ReadLine();
            if (contactNumber.ToLower() == "exit") return;
            while (!Regex.IsMatch(contactNumber, contactNumberPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid contact number. It must be at least 10 digits long. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Contact Number: ");
                contactNumber = Console.ReadLine();
                if (contactNumber.ToLower() == "exit") return;
            }

            Console.Write("Enter Job Title (Library assistant, Library technician, Information specialist, Public relations, IT support, Librarian, Library manager, Circulation manager): ");
            string jobTitle = Console.ReadLine().ToLower();
            if (jobTitle.ToLower() == "exit") return;
            while (!Regex.IsMatch(jobTitle, jobTitlePattern, RegexOptions.IgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid job title. Please choose a valid job title from the list.");
                Console.ResetColor();
                Console.Write("Enter Job Title (Library assistant, Library technician, Information specialist, Public relations, IT support, Librarian, Library manager, Circulation manager): ");
                jobTitle = Console.ReadLine();
                if (jobTitle.ToLower() == "exit") return;
            }

            library.AddStaff(new Staff(name, Library.IdGenerator().ToString(), contactNumber, $"S{Library.IdGenerator()}", jobTitle));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Staff added successfully.");
            Console.ResetColor();
        }

        static void AddNewBook()
        {
            string titlePattern = @"^[a-zA-Z\s]+$";
            string authorPattern = @"^[a-zA-Z\s]+$";

            Console.WriteLine("Enter Book Details (or type 'exit' to cancel):");

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            if (title.ToLower() == "exit") return;
            while (!Regex.IsMatch(title, titlePattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid title. Title can only include letters. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Book Title: ");
                title = Console.ReadLine();
                if (title.ToLower() == "exit") return;
            }

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            if (author.ToLower() == "exit") return;
            while (!Regex.IsMatch(author, authorPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid author. Author can only include letters. Please try again.");
                Console.ResetColor();
                Console.Write("Enter Author: ");
                author = Console.ReadLine();
                if (author.ToLower() == "exit") return;
            }

            AddBook(title, author);
        }

        static void AddBook(string title, string author)
        {
            string isbn = GenerateISBN();
            Book newBook = new Book(title, author, isbn);
            library.Addbook(newBook);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book added successfully with ISBN: " + isbn);
            Console.ResetColor();
        }

        static string GenerateISBN()
        {
            Random random = new Random();
            string isbn;
            do
            {
                isbn = new string(Enumerable.Range(0, 13).Select(_ => (char)('0' + random.Next(10))).ToArray());
            } while (library.Books.Any(b => b.ISBN == isbn));
            return isbn;
        }


        static void BorrowBook()
        {
            if (library.Books.All(b => b.IsBorrowed))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books available to borrow.");
                Console.ResetColor();
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Available Books:\n");
            library.ListAvailableBooks();

            Console.Write("\nEnter Book ISBN to borrow (or type 'exit' to return to main menu): ");
            string isbn = Console.ReadLine();
            if (isbn.ToLower() == "exit") return;

            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine().ToLower();
            if (memberId.ToLower() == "exit") return;

            library.BorrowBook(isbn, memberId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book borrowed successfully.");
            Console.ResetColor();
        }



        static void ReturnBook()
        {
            if (!library.BorrowedBooks.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No books to return.");
                Console.ResetColor();
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine("Borrowed Books:\n");
            library.ListBorrowedBooks();

            Console.Write("\nEnter Book ISBN to return: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter Member ID: ");
            string memberId = Console.ReadLine().ToLower(); 

            library.ReturnBook(isbn, memberId);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book returned successfully.");
            Console.ResetColor();
        }

        static void ModifyBook()
        {
            library.ListBooks(); // Display all books
            Console.Write("\nEnter Book ISBN to modify (or type 'exit' to return to main menu): ");
            string isbn = Console.ReadLine();
            if (isbn.ToLower() == "exit") return;

            var book = library.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter new Title (or press Enter to keep current): ");
            string newTitle = Console.ReadLine();
            if (newTitle.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newTitle))
            {
                book.Title = newTitle;
            }

            Console.Write("Enter new Author (or press Enter to keep current): ");
            string newAuthor = Console.ReadLine();
            if (newAuthor.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newAuthor))
            {
                book.Author = newAuthor;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book modified successfully.");
            Console.ResetColor();
        }


        static void ModifyMember()
        {
            library.ListMembers(); // Display all members
            Console.Write("\nEnter Member ID to modify (or type 'exit' to return to main menu): ");
            string memberId = Console.ReadLine();
            if (memberId.ToLower() == "exit") return;

            var member = library.Members.FirstOrDefault(m => m.MemberID == memberId);
            if (member == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Member not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter new Name (or press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (newName.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newName))
            {
                member.Name = newName;
            }

            Console.Write("Enter new Contact Number (or press Enter to keep current): ");
            string newContact = Console.ReadLine();
            if (newContact.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newContact))
            {
                member.ContactNumber = newContact;
            }

            Console.Write("Enter new Membership Type (Gold, Silver, Bronze) (or press Enter to keep current): ");
            string newMembershipType = Console.ReadLine();
            if (newMembershipType.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newMembershipType))
            {
                int maxBooksAllowed = 0;
                if (string.Equals(newMembershipType, "Gold", StringComparison.OrdinalIgnoreCase))
                {
                    maxBooksAllowed = 5;
                }
                else if (string.Equals(newMembershipType, "Silver", StringComparison.OrdinalIgnoreCase))
                {
                    maxBooksAllowed = 3;
                }
                else if (string.Equals(newMembershipType, "Bronze", StringComparison.OrdinalIgnoreCase))
                {
                    maxBooksAllowed = 1;
                }

                member.MembershipType = newMembershipType;
                member.MaxBooksAllowed = maxBooksAllowed.ToString();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Member modified successfully.");
            Console.ResetColor();
        }

        static void ModifyStaff()
        {
            library.ListStaff(); // Display all staff
            Console.Write("\nEnter Staff ID to modify (or type 'exit' to return to main menu): ");
            string staffId = Console.ReadLine();
            if (staffId.ToLower() == "exit") return;

            var staff = library.Staffs.FirstOrDefault(s => s.StaffID == staffId);
            if (staff == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Staff not found.");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter new Name (or press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (newName.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newName))
            {
                staff.Name = newName;
            }

            Console.Write("Enter new Contact Number (or press Enter to keep current): ");
            string newContact = Console.ReadLine();
            if (newContact.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newContact))
            {
                staff.ContactNumber = newContact;
            }

            Console.Write("Enter new Job Title (or press Enter to keep current): ");
            string newJobTitle = Console.ReadLine();
            if (newJobTitle.ToLower() == "exit") return;
            if (!string.IsNullOrEmpty(newJobTitle))
            {
                staff.JobTitle = newJobTitle;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Staff modified successfully.");
            Console.ResetColor();
        }

        // deletes a book if it is not borrowed
        static void DeleteBook()
        {
            library.ListBooks(); // Display all books
            Console.Write("\nEnter Book ISBN to delete (or type 'exit' to return to main menu): ");
            string isbn = Console.ReadLine();
            if (isbn.ToLower() == "exit") return;

            var book = library.Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found.");
                Console.ResetColor();
                return;
            }

            if (book.IsBorrowed)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot delete a borrowed book.");
                Console.ResetColor();
                return;
            }

            Console.Write("Are you sure you want to delete this book? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                library.Books.Remove(book);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book deleted successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Book deletion canceled.");
                Console.ResetColor();
            }
        }


        // delete member if they have no borrowed books
        static void DeleteMember()
        {
            library.ListMembers(); // Display all members
            Console.Write("\nEnter Member ID to delete (or type 'exit' to return to main menu): ");
            string memberId = Console.ReadLine();
            if (memberId.ToLower() == "exit") return;

            var member = library.Members.FirstOrDefault(m => m.MemberID == memberId);
            if (member == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Member not found.");
                Console.ResetColor();
                return;
            }

            if (library.BorrowedBooks.Values.Contains(memberId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot delete a member with borrowed books.");
                Console.ResetColor();
                return;
            }

            Console.Write("Are you sure you want to delete this member? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                library.Members.Remove(member);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Member deleted successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Member deletion canceled.");
                Console.ResetColor();
            }
        }


        // delete staff if they have no borrowed books
        static void DeleteStaff()
        {
            library.ListStaff(); // Display all staff
            Console.Write("\nEnter Staff ID to delete (or type 'exit' to return to main menu): ");
            string staffId = Console.ReadLine();
            if (staffId.ToLower() == "exit") return;

            var staff = library.Staffs.FirstOrDefault(s => s.StaffID == staffId);
            if (staff == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Staff not found.");
                Console.ResetColor();
                return;
            }

            if (library.BorrowedBooks.Values.Contains(staffId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot delete a staff member with borrowed books.");
                Console.ResetColor();
                return;
            }

            Console.Write("Are you sure you want to delete this staff member? (yes/no): ");
            string confirmation = Console.ReadLine().ToLower();
            if (confirmation == "yes")
            {
                library.Staffs.Remove(staff);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Staff member deleted successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Staff member deletion canceled.");
                Console.ResetColor();
            }
        }


    }
}

