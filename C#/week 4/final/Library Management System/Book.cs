using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System
{
    public class Book // publicly accessible
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsBorrowed { get; set; }

        // constructor takes three parameters to assign to corresponding properties
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsBorrowed = false; // boolean property to help track the availability of the book in the library
        }

        public override string ToString()
        {
            return $"{Title,-40} {Author,-25} {ISBN,-20} {IsBorrowed,-10}";
        }
    }
}
