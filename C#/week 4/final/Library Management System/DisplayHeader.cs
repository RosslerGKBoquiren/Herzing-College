using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DisplayUtils
{
    public static void DisplayBooksHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("List of all Books: \n");
        Console.WriteLine($"{"Title",-40} {"Author",-25} {"ISBN",-20} {"Is Borrowed",-10}");
        Console.WriteLine(new string('-', 100));
        Console.ResetColor();
    }

    public static void DisplayMembersHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("List of all Members: \n");
        Console.WriteLine($"{"Name",-20} {"ID",-5} {"Contact",-15} {"MemberID",-10} {"Membership Type",-18} {"Max Books Allowed",-5}");
        Console.WriteLine(new string('-', 90));
        Console.ResetColor();
    }

    public static void DisplayStaffHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("List of all Staff: \n");
        Console.WriteLine($"{"Name",-20} {"ID",-5} {"Contact",-15} {"StaffID",-10} {"Job Title",-20}");
        Console.WriteLine(new string('-', 75));
        Console.ResetColor();
    }

    public static void DisplayBorrowedBooksHeader()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("List of all Borrowed Books: \n");
        Console.WriteLine($"{"Title",-40} {"Author",-25} {"ISBN",-20} {"Is Borrowed",-10}");
        Console.WriteLine(new string('-', 100));
        Console.ResetColor();
    }


}

