using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>(); // to represent all the books in the library
        public List<Member> Members { get; set; } = new List<Member>(); // to represent all the members of the library
        public List<Staff> Staffs { get; set; } = new List<Staff>(); // to represent all the staff of the library
        public Dictionary<string, string> BorrowedBooks { get; set; } = new Dictionary<string, string>(); // key is ISBN of a borrowed book, value is the 'MemberID' who borrowed it
        // using a dictionary for BorrowedBooks to ensure a clear and direct relationship between books and borrowers
        // one ISBN to one MemberID, preventing duplicates


        // constructor initializes the lists and dictionary to ensure they are ready to use when a 'Library' object is created
        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
            Staffs = new List<Staff>();
            BorrowedBooks = new Dictionary<string, string>();
        }

        private static int uniqueId = 1; // privately accessible within 'Library' class and can be shares among all of its instances

        // to generate unique IDs
        public static int IdGenerator()
        {
            return uniqueId++;
        }


        
        // to add a 'Book' object to the 'Books' list of the 'Library' class
        public void Addbook(Book book) // object type 'Book' class
        {
            Books.Add(book); // to refer to the 'Books' property of 'Library' class which holds 'Book' objects
        }

        // to remove a 'Book' object from the 'Books' list
        // using the ISBN to remove a book as practical choice due to their unique identifiers
        public void RemoveBook(string isbn)
        {
            // lambda expression to check if ISBN property matches the given isbn
            var book = Books.FirstOrDefault(b => b.ISBN == isbn); // return the first element that matches the condition or null if not found
            if (book != null && !book.IsBorrowed)
            {
                Books.Remove(book);
            }
        }

        // to add a 'Member' object to the 'Members' list
        public void AddMember(Member member) // object type 'Member' class
        {
            Members.Add(member); // to refer to the 'Members' property of 'Library' class which hold 'Member' objects
        }


        // to remove a 'Member' object from the 'Members' list
        // using the unique identifier memberID to remove a member
        public void RemoveMember(string memberId)
        {
            // lambda expression to check if MemberID matches the given memberId
            var member = Members.FirstOrDefault(m => m.MemberID == memberId);
            if (member != null && !BorrowedBooks.Values.Contains(memberId)) // return first element that matches the condition or null if not found
            {
                Members.Remove(member);
            }
        }


        // to add a 'Staff' object to the 'Staffs' list
        public void AddStaff(Staff staff) // object type 'Staff' class
        {
            Staffs.Add(staff); // to refer to the 'Staffs' property of 'Library' class which holds 'Staff' objects
        }


        // to remove a 'Staff' object from the 'Staffs' list
        // using the unique identifier staffID to remove a staff
        public void RemoveStaff(string staffId)
        {
            // to check if StaffID matches the given staffId
            var staff = Staffs.FirstOrDefault(s => s.StaffID == staffId); // return first matching element or null if not
            if (staff != null)
            {
                Staffs.Remove(staff);
            }
        }

        
        // method allowing a member to borrow a book from the library, under certain conditions
        // it updates the book's status to borrowed and records the borrowing in the 'BorrowedBooks' dictionary
        public void BorrowBook(string isbn, string memberId) // using the unique identifiers of the book and the member 
        {
            try
            {
                var book = Books.FirstOrDefault(b => b.ISBN == isbn); // finding the book
                var member = Members.FirstOrDefault(m => m.MemberID.ToLower() == memberId); // finding the member


                // four conditions:
                // 1. ensuring that the book is found
                // 2. ensuring that the book is not currently borrowed
                // 3. ensuring that the memberID exists
                // 4. ensuring that the member's borrowing limit is not exceeded
                if (book != null && !book.IsBorrowed && member != null && BorrowedBooks.Values.Count(v => v == memberId) < int.Parse(member.MaxBooksAllowed))
                {
                    book.IsBorrowed = true; // if conditions are met, Isborrowed is set to true. Indicating that the book is now borrowed
                    BorrowedBooks[isbn] = memberId; // the book's ISBN and member's ID are recorded in the dictionary
                }
            }
            // else, error message is printed to the console
            catch (Exception exception)
            {
                Console.WriteLine($"Error borrowing book: {exception.Message}");
            }
        }
        

        // method to allow a member to return a borrowed book back to the library
        // updates the book's status to not-borrowed and removes the entry from the dictionary
        public void ReturnBook(string isbn, string memberId)
        {
            try
            {
                var book = Books.FirstOrDefault(b => b.ISBN == isbn);

                // condition check:
                // 1. ensures that a book is found
                // 2. ensures that the book is currently borrowed
                // 3. ensures that the book is recorded in the dictionary
                // 4. ensures that the book was borrowed by the member with the given memberId
                if (book != null && book.IsBorrowed && BorrowedBooks.ContainsKey(isbn) && BorrowedBooks[isbn].ToLower() == memberId)
                {
                    book.IsBorrowed = false; // if conditions are met, IsBorrowed property is set to false. Book is no longer borrowed
                    BorrowedBooks.Remove(isbn); // book's ISBN is removed from the dictionary, recording that it is returned
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error returning book: {exception.Message}");
            }
        }

        // to list books
        public void ListBooks()
        {
            DisplayUtils.DisplayBooksHeader();
            foreach (var book in Books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // method to display list of available books
        public void ListAvailableBooks()
        {
            DisplayUtils.DisplayBooksHeader();
            foreach (var book in Books.Where(b => !b.IsBorrowed))
            {
                Console.WriteLine(book.ToString());
            }
        }

        // method to display list of borrowed books
        public void ListBorrowedBooks()
        {
            DisplayUtils.DisplayBorrowedBooksHeader();
            foreach (var book in Books.Where(b => b.IsBorrowed))
            {
                Console.WriteLine(book.ToString());
            }
        }


        // to list members
        public void ListMembers()
        {
            DisplayUtils.DisplayMembersHeader();
            foreach (var member in Members)
            {
                Console.WriteLine(member.ToString());
            }
        }

        // to list staff
        public void ListStaff()
        {
            DisplayUtils.DisplayStaffHeader();
            foreach (var staff in Staffs)
            {
                Console.WriteLine(staff.ToString());
            }
        }
    }
}

