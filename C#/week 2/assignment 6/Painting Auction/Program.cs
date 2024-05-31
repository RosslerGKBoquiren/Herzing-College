using System;
using System.Collections.Generic;
using System.Linq;

namespace PaintingAuction
{
    /// <summary>
    /// Defines the properties and methods for a painting
    /// </summary>
    public class Painting // blueprint for the attributes of my list
    {
        public string Title { get; set; } // be able to read and modify values of private fields
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Rank { get; set; }
        public bool IsSold { get; private set; } = false; // default is 'Not Sold'
        public decimal SoldPrice { get; private set; } // Stores the price at which the painting was sold

        // if sold
        public void MarkAsSold(decimal soldPrice)
        {
            IsSold = true;
            SoldPrice = soldPrice;
        }
    }

    /// <summary>
    /// List of paintings in the auction and provides methods to manipulate the list 
    /// </summary>
    public class PaintingList
    {
        // List<Painting> to store the paintings data
        // encapsulate the list to control and protect how the list is accessed and modified
        private List<Painting> paintings = new List<Painting>();

        /// <summary>
        /// add painting to the list
        /// </summary>
        /// <param name="painting">the item to add</param>
        public void AddPainting(Painting painting)
        {
            paintings.Add(painting);
        }

        /// <summary>
        /// delete painting from the list if not sold
        /// </summary>
        /// <param name="title">title of painting to delete</param>
        public void DeletePainting(string title)
        {
            // built-in method FirstOrDefault searches for the first matching title, else return null
            // using lambda expression for anonymous function 
            var painting = paintings.FirstOrDefault(p => p.Title == title);
            if (painting != null && !painting.IsSold)
            {
                paintings.Remove(painting);
            }
            else
            {
                Console.WriteLine("No records of that Painting.");
            }
        }

        /// <summary>
        /// edit painting price/status if not sold
        /// </summary>
        /// <param name="title">title of the painting to edit</param>
        /// <param name="newPrice">new price of the painting</param>
        public void EditPainting(string title, decimal newPrice)
        {
            var painting = paintings.FirstOrDefault(p => p.Title == title);
            if (painting != null && !painting.IsSold)
            {
                painting.Price = newPrice;
            }
            else
            {
                Console.WriteLine("No records of that Painting.");
            }
        }

        /// <summary>
        /// show all items and details
        /// </summary>
        public void ShowAllPaintings()
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("No.  Artists Name        Picture Title     Rank    Price $     Sold $$");
            Console.WriteLine("==================================================================================");
            int count = 1;
            foreach (var painting in paintings)
            {
                Console.WriteLine($"{count}    {painting.Author}          {painting.Title}       {painting.Rank}       ${painting.Price}     {(painting.IsSold ? "$" + painting.SoldPrice.ToString() : "-Not Sold-")}");
                count++;
            }
            Console.WriteLine("==================================================================================");
        }

        /// <summary>
        /// Show the minimum and maximum price of items not sold
        /// </summary>
        public void ShowMinMaxPricedPaintings()
        {
            var unsoldPaintings = paintings.Where(p => !p.IsSold).ToList();
            if (unsoldPaintings.Any())
            {
                var minPriced = unsoldPaintings.OrderBy(p => p.Price).First();
                var maxPriced = unsoldPaintings.OrderByDescending(p => p.Price).First();
                Console.WriteLine($"Minimum priced painting: {minPriced.Title} by {minPriced.Author}, Price: ${minPriced.Price}");
                Console.WriteLine($"Maximum priced painting: {maxPriced.Title} by {maxPriced.Author}, Price: ${maxPriced.Price}");
            }
            else
            {
                Console.WriteLine("No unsold paintings available.");
            }
        }

        /// <summary>
        /// Find an item by author or title
        /// </summary>
        /// <param name="search">search by author or title</param>
        public void FindPainting(string search)
        {
            var foundPaintings = paintings.Where(p => p.Author == search || p.Title == search).ToList();
            if (foundPaintings.Any())
            {
                foreach (var painting in foundPaintings)
                {
                    Console.WriteLine($"Found: {painting.Title} by {painting.Author}, Price: ${painting.Price}, Sold: {(painting.IsSold ? "Yes" : "No")}");
                }
            }
            else
            {
                Console.WriteLine("No paintings found with the given search criteria.");
            }
        }

        /// <summary>
        /// Find a painting by its title.
        /// </summary>
        /// <param name="title">Title of the painting.</param>
        /// <returns>Returns the painting if found, otherwise null.</returns>
        public Painting FindPaintingByTitle(string title)
        {
            return paintings.FirstOrDefault(p => p.Title == title);
        }
    }

    public class Program
    {
        // keeping the password from being used outside of this class or modified directly
        private static string password = "user123456";

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Painting Auction Menu");

            bool isAuthenticated = false;
            while (!isAuthenticated)
            {
                Console.WriteLine("Please enter your password: ");
                string passwordInput = Console.ReadLine();

                if (passwordInput == password)
                {
                    isAuthenticated = true;
                    Console.WriteLine("Access granted");
                }
                else
                {
                    Console.WriteLine("Incorrect Password. Try again or type 'exit' to quit.");
                    if (passwordInput.ToLower() == "exit")
                    {
                        Console.WriteLine("Exiting program");
                        return;
                    }
                }
            }

            PaintingList paintingList = new PaintingList();
            InitializePaintings(paintingList);
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("================================================================================================");
                Console.WriteLine("                           Painting Auction Menu");
                Console.WriteLine("================================================================================================");
                Console.WriteLine("1. Add items");
                Console.WriteLine("2. Delete items");
                Console.WriteLine("3. Edit item");
                Console.WriteLine("4. Show all items");
                Console.WriteLine("5. Show min and max items by price");
                Console.WriteLine("6. Find an item");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine().ToLower();

                switch (option)
                {
                    case "1":
                    case "add":
                        AddItem(paintingList);
                        break;
                    case "2":
                    case "delete":
                        DeleteItem(paintingList);
                        break;
                    case "3":
                    case "edit":
                        EditItem(paintingList);
                        break;
                    case "4":
                    case "all items":
                        paintingList.ShowAllPaintings();
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                    case "min max":
                    case "by price":
                        paintingList.ShowMinMaxPricedPaintings();
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "6":
                    case "find":
                        FindItem(paintingList);
                        break;
                    case "7":
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void InitializePaintings(PaintingList paintingList)
        {
            Painting painting1 = new Painting { Title = "Mon Li", Author = "Michael Angel", Price = 50000m, Rank = 1 };
            paintingList.AddPainting(painting1);

            Painting painting2 = new Painting { Title = "The flower", Author = "James Hire", Price = 1000m, Rank = 5 };
            painting2.MarkAsSold(200m); // Mark as sold
            paintingList.AddPainting(painting2);

            Painting painting3 = new Painting { Title = "Masterpiece", Author = "Alysha Lowery", Price = 50000m, Rank = 10 };
            paintingList.AddPainting(painting3);

            Painting painting4 = new Painting { Title = "The Rainbow", Author = "Taylor Bird", Price = 45000m, Rank = 7 };
            paintingList.AddPainting(painting4);

            Painting painting5 = new Painting { Title = "Scribble", Author = "Robert Hockey", Price = 100m, Rank = 2 };
            paintingList.AddPainting(painting5);
        }

        /// <summary>
        /// add new painting to the list
        /// </summary>
        /// <param name="paintingList"></param>
        private static void AddItem(PaintingList paintingList)
        {
            Console.Write("Enter the title of the painting: ");
            string title = Console.ReadLine();
            Console.Write("Enter the author of the painting: ");
            string author = Console.ReadLine();
            Console.Write("Enter the price of the painting: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.Write("Enter the rank of the painting: ");
                if (int.TryParse(Console.ReadLine(), out int rank))
                {
                    Painting painting = new Painting { Title = title, Author = author, Price = price, Rank = rank };
                    paintingList.AddPainting(painting);
                    Console.WriteLine("Painting added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid rank.");
                }
            }
            else
            {
                Console.WriteLine("Invalid price.");
            }
        }

        /// <summary>
        /// delete a painting from the list
        /// </summary>
        /// <param name="paintingList">list of paintings</param>
        private static void DeleteItem(PaintingList paintingList)
        {
            Console.Write("Enter the title of the painting to delete: ");
            string title = Console.ReadLine();
            var painting = paintingList.FindPaintingByTitle(title);
            if (painting != null)
            {
                Console.Write($"Are you sure you want to delete \"{title}\"? (yes/no): ");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "yes")
                {
                    paintingList.DeletePainting(title);
                    Console.WriteLine($"Painting \"{title}\" has been deleted.");
                }
                else
                {
                    Console.WriteLine("Deletion canceled.");
                }
            }
            else
            {
                Console.WriteLine("No records of that Painting.");
            }
        }

        /// <summary>
        /// edit price of painting
        /// </summary>
        /// <param name="paintingList">the list of paintings</param>
        private static void EditItem(PaintingList paintingList)
        {
            Console.Write("Enter the title of the painting to edit: ");
            string title = Console.ReadLine();
            Console.Write("Enter the new price of the painting: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
            {
                paintingList.EditPainting(title, newPrice);
            }
            else
            {
                Console.WriteLine("Invalid price.");
            }
        }

        /// <summary>
        ///  find painting by author or title
        /// </summary>
        /// <param name="paintingList">the list of paintings</param>
        private static void FindItem(PaintingList paintingList)
        {
            Console.Write("Enter the author or title to search: ");
            string search = Console.ReadLine();
            paintingList.FindPainting(search);
        }
    }
}


