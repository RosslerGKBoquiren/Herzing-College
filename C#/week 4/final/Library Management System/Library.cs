using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; set; } // to represent all the books in the library
        public List<Member> Members { get; set; } // to represent all the members of the library
        public List<Staff> Staffs { get; set; } // to represent all the staff of the library
        public Dictionary<string, string> BorrowedBooks { get; set; } // key is ISBN of a borrowed book, value is the 'MemberID' who borrowed it

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
        public void RemoveMember(string memberId)
        {
            var member = Members.FirstOrDefault(m => m.MemberID == memberId);
            if (member != null && !BorrowedBooks.Values.Contains(memberId))
            {
                Members.Remove(member);
            }
        }

        public void AddStaff(Staff staff)
        {
            Staffs.Add(staff);
        }

        public void RemoveStaff(string staffId)
        {
            var staff = Staffs.FirstOrDefault(s => s.StaffID == staffId);
            if (staff != null)
            {
                Staffs.Remove(staff);
            }
        }

        // to borrow and return books
        public void BorrowBook(string isbn, string memberId)
        {
            try
            {
                var book = Books.FirstOrDefault(b => b.ISBN == isbn);
                var member = Members.FirstOrDefault(m => m.MemberID == memberId);

                if (book != null && !book.IsBorrowed && member != null && BorrowedBooks.Values.Count(v => v == memberId) < int.Parse(member.MaxBooksAllowed))
                {
                    book.IsBorrowed = true;
                    BorrowedBooks[isbn] = memberId;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error borrowing book: {exception.Message}");
            }
        }

        public void ReturnBook(string isbn, string memberId)
        {
            try
            {
                var book = Books.FirstOrDefault(b => b.ISBN == isbn);
                if (book != null && book.IsBorrowed && BorrowedBooks.ContainsKey(isbn) && BorrowedBooks[isbn] == memberId)
                {
                    book.IsBorrowed = false;
                    BorrowedBooks.Remove(isbn);
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
            foreach (var book in Books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        // to list members
        public void ListMembers()
        {
            foreach (var member in Members)
            {
                Console.WriteLine(member.ToString());
            }
        }

        // to list staff
        public void ListStaff()
        {
            foreach (var staff in Staffs)
            {
                Console.WriteLine(staff.ToString());
            }
        }
    }
}

