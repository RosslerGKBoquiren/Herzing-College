using System;
using System.Collections.Generic;
using System.Linq;

namespace PaintingAuction
{
    /// <summary>
    /// Defines the properties and methods for a painting
    /// </summary>
    public class Painting
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Rank { get; set; }
        public bool IsSold { get; private set; } = false;
        public decimal SoldPrice { get; private set; }

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
        private List<Painting> paintings = new List<Painting>();

        public void AddPainting(Painting painting)
        {
            paintings.Add(painting);
        }

        public void DeletePainting(string title)
        {
            var painting = paintings.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (painting != null && !painting.IsSold)
            {
                paintings.Remove(painting);
                Console.WriteLine($"Painting \"{title}\" has been deleted.");
            }
            else
            {
                Console.WriteLine("No records of that Painting or it is already sold.");
            }
        }

        public void EditPainting(string title, decimal newPrice, decimal soldPrice)
        {
            var painting = paintings.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (painting != null && !painting.IsSold)
            {
                painting.Price = newPrice;
                painting.MarkAsSold(soldPrice); // Mark as sold with the sold price
                Console.WriteLine($"Painting \"{title}\" price updated and marked as sold for {soldPrice:C}.");
            }
            else
            {
                Console.WriteLine("No records of that Painting or it is already sold.");
            }
        }


        public void ShowAllPaintings()
        {
            Console.WriteLine("==================================================================================");
            Console.WriteLine("{0,-4} {1,-18} {2,-20} {3,-8} {4,-16} {5,-16}", "No.", "Artists Name", "Picture Title", "Rank", "Price $", "Sold $$");
            Console.WriteLine("==================================================================================");
            int count = 1;
            foreach (var painting in paintings)
            {
                Console.WriteLine("{0,-4} {1,-18} {2,-20} {3,-8} {4,-16:C} {5,-16}",
                                  count,
                                  painting.Author,
                                  painting.Title,
                                  painting.Rank,
                                  painting.Price,
                                  (painting.IsSold ? painting.SoldPrice.ToString("C") : "-Not Sold-"));
                count++;
            }
            Console.WriteLine("==================================================================================");
        }

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

        public List<Painting> FindPainting(string search)
        {
            return paintings.Where(p => p.Author.Equals(search, StringComparison.OrdinalIgnoreCase) || p.Title.Equals(search, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Painting FindPaintingByTitle(string title)
        {
            return paintings.FirstOrDefault(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public void MarkPaintingAsSold(string title, decimal soldPrice)
        {
            var painting = FindPaintingByTitle(title);
            if (painting != null && !painting.IsSold)
            {
                painting.MarkAsSold(soldPrice);
                Console.WriteLine($"Painting \"{title}\" marked as sold for {soldPrice:C}.");
            }
            else
            {
                Console.WriteLine("No records of that Painting or it is already sold.");
            }
        }
    }

    public class Program
    {
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
                    case "show all items":
                        paintingList.ShowAllPaintings();
                        Console.WriteLine("Press any key to return to the menu...");
                        Console.ReadKey();
                        break;
                    case "5":
                    case "show min max items":
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
            Painting painting1 = new Painting { Title = "Marie Therese", Author = "Pablo Picaso", Price = 103410000m, Rank = 1 };
            paintingList.AddPainting(painting1);

            Painting painting2 = new Painting { Title = "In This Case", Author = "JM Basquiat", Price = 93105000m, Rank = 2 };
            paintingList.AddPainting(painting2);

            Painting painting3 = new Painting { Title = "Portrait", Author = "Sandro Botticelli", Price = 92184000m, Rank = 3 };
            paintingList.AddPainting(painting3);

            Painting painting4 = new Painting { Title = "No.7", Author = "Mark Rothko", Price = 82468500m, Rank = 4 };
            paintingList.AddPainting(painting4);

            Painting painting5 = new Painting { Title = "Le Nez", Author = "Albert Giacometti", Price = 78396000m, Rank = 5 };
            paintingList.AddPainting(painting5);

            Painting painting6 = new Painting { Title = "Le Bassin Nympheas", Author = "Claude Monet", Price = 40900000m, Rank = 7 };
            painting6.MarkAsSold(70353000m); // sold 
            paintingList.AddPainting(painting6);

            Painting painting7 = new Painting { Title = "The First 5000 Days", Author = "Beeple, Everydays", Price = 69346250m, Rank = 8 };
            paintingList.AddPainting(painting7);

            Painting painting8 = new Painting { Title = "Number 17", Author = "Jackson Pollock", Price = 58400000m, Rank = 9 };
            painting8.MarkAsSold(61161000m); // sold
            paintingList.AddPainting(painting8);

            Painting painting9 = new Painting { Title = "Untitled", Author = "Cy Twombly", Price = 58863000m, Rank = 10 };
            painting9.MarkAsSold(70000000m); // sold
            paintingList.AddPainting(painting9);
        }

        /// <summary>
        /// Adds a new painting to the list with input validation.
        /// </summary>
        /// <param name="paintingList">The list of paintings.</param>
        private static void AddItem(PaintingList paintingList)
        {
            string title;
            string author;
            decimal price;
            int rank;

            do
            {
                Console.Write("Enter the title of the painting: ");
                title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Title cannot be empty.");
                }
            } while (string.IsNullOrWhiteSpace(title));

            do
            {
                Console.Write("Enter the author of the painting: ");
                author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Author cannot be empty.");
                }
            } while (string.IsNullOrWhiteSpace(author));

            do
            {
                Console.Write("Enter the price of the painting: ");
                if (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
                {
                    Console.WriteLine("Invalid price. Please enter a positive number.");
                }
            } while (price <= 0);

            do
            {
                Console.Write("Enter the rank of the painting: ");
                if (!int.TryParse(Console.ReadLine(), out rank) || rank <= 0)
                {
                    Console.WriteLine("Invalid rank. Please enter a positive integer.");
                }
            } while (rank <= 0);

            Painting painting = new Painting
            {
                Title = title,
                Author = author,
                Price = price,
                Rank = rank
            };

            paintingList.AddPainting(painting);
            Console.WriteLine("Painting added successfully!");
        }

        /// <summary>
        /// Deletes a painting from the list.
        /// </summary>
        /// <param name="paintingList">The list of paintings.</param>
        private static void DeleteItem(PaintingList paintingList)
        {
            while (true)
            {
                Console.Write("Enter the title of the painting to delete: ");
                string title = Console.ReadLine();

                var painting = paintingList.FindPaintingByTitle(title);
                if (painting == null || painting.IsSold)
                {
                    Console.WriteLine("The title does not exist or the painting is already sold. Please try again.");
                    Console.WriteLine("Press any key to continue or type 'exit' to return to the menu...");
                    string input = Console.ReadLine().ToLower();
                    if (input == "exit")
                    {
                        return;
                    }
                }
                else
                {
                    Console.Write($"Are you sure you want to delete \"{title}\"? (yes/no): ");
                    string confirmation = Console.ReadLine().ToLower();
                    if (confirmation == "yes")
                    {
                        paintingList.DeletePainting(title);
                    }
                    else
                    {
                        Console.WriteLine("Deletion canceled.");
                    }

                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
                }
            }
        }

        /// <summary>
        /// Edits the price of a painting and marks it as sold.
        /// </summary>
        /// <param name="paintingList">The list of paintings.</param>
        private static void EditItem(PaintingList paintingList)
        {
            Console.Write("Enter the title of the painting to edit: ");
            string title = Console.ReadLine();

            var painting = paintingList.FindPaintingByTitle(title);
            if (painting == null || painting.IsSold)
            {
                Console.WriteLine("The title does not exist or the painting is already sold.");
                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
                return;
            }

            while (true)
            {
                Console.Write("Enter the new price of the painting: ");
                string priceInput = Console.ReadLine();

                if (!decimal.TryParse(priceInput, out decimal newPrice) || newPrice <= 0)
                {
                    Console.WriteLine("Invalid price. Please enter a valid positive number.");
                }
                else
                {
                    paintingList.EditPainting(title, painting.Price, newPrice);
                    break;
                }
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Find a painting by author or title.
        /// </summary>
        /// <param name="paintingList">The list of paintings.</param>
        private static void FindItem(PaintingList paintingList)
        {
            while (true)
            {
                Console.Write("Enter the author or title to search: ");
                string search = Console.ReadLine();

                var foundPaintings = paintingList.FindPainting(search);
                if (!foundPaintings.Any())
                {
                    Console.WriteLine("No paintings found with the given search criteria. Please try again.");
                    Console.WriteLine("Press any key to continue or type 'exit' to return to the menu...");
                    string input = Console.ReadLine().ToLower();
                    if (input == "exit")
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Found the following paintings:");
                    foreach (var painting in foundPaintings)
                    {
                        Console.WriteLine($"Title: {painting.Title}, Author: {painting.Author}, Price: ${painting.Price}, Sold: {(painting.IsSold ? "Yes" : "No")}");
                    }

                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}

