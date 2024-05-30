using System;
using System.Collections.Generic; // allows me to create and manage lists 
using System.Linq; // makes it easier to query collections, in this case the list

public class Painting // blueprint for the attributes of my list
{ 
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }
    public int Rank { get; set; }

    // default is 'Not Sold'
    public bool IsSold { get; set; } = false;

    // if sold
    public void MarkedAsSold()
    { 
        IsSold = true;
    }
}

public class PaintingList
{ 
    // encapsulate the list to control and protect how the list is accessed and modified
    private List<Painting> paintings = new List<Painting>();

    // add painting to the list
    public void AddPainting(Painting painting)
    { 
        paintings.Add(painting);
    }


    // delete painting from the list if not sold
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


    // edit painting price/status if not sold
}