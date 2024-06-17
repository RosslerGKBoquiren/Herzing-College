using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }
        public List<Staff> Staffs { get; set; }
        public Dictionary<string, string> BorrowedBooks { get; set; }

        public Library()
        { 
            Books = new List<Book>();
            Members = new List<Member> { };
            Staffs = new List<Staff>();
            BorrowedBooks = new Dictionary<string, string>();
        }

        private static int uniqueId = 1;

        // to generate unique IDs
        public static int IdGenerator()
        { 
            return uniqueId++;
        }

        // to add and remove books, members, and staff
        public void Addbook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(string isbn)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null && !book.IsBorrowed)
            {
                Books.Remove(book);
            }
        }

        public void RemoveMember(string memberId)
        {
            Members.Add(member);
        }

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

                if (book != null && !book.IsBorrowed && member != null && BorrowedBooks.Values.Count(v => v == memberId) < member.MaxBooksAllowed)
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
    }
}
