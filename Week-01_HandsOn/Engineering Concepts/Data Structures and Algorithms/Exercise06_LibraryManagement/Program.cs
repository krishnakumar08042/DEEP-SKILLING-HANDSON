using System;

class Book
{
    public int BookId;
    public string Title;
    public string Author;

    public Book(int id, string title, string author)
    {
        BookId = id;
        Title = title;
        Author = author;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Book ID : " + BookId);
        Console.WriteLine("Title   : " + Title);
        Console.WriteLine("Author  : " + Author);
    }
}

class Program
{
    static Book[] books =
    {
        new Book(101, "C Programming", "Dennis Ritchie"),
        new Book(102, "Data Structures", "Mark Allen"),
        new Book(103, "Java Programming", "James Gosling"),
        new Book(104, "Python Basics", "Guido van Rossum"),
        new Book(105, "Web Development", "David Flanagan")
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Display Books");
            Console.WriteLine("2. Linear Search by Title");
            Console.WriteLine("3. Binary Search by Title");
            Console.WriteLine("4. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayBooks();
                    break;

                case 2:
                    Console.Write("Enter Book Title: ");
                    string title1 = Console.ReadLine();
                    LinearSearch(title1);
                    break;

                case 3:
                    Console.Write("Enter Book Title: ");
                    string title2 = Console.ReadLine();
                    BinarySearch(title2);
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void DisplayBooks()
    {
        foreach (Book book in books)
        {
            book.Display();
        }
    }

    static void LinearSearch(string title)
    {
        foreach (Book book in books)
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("\nBook Found");
                book.Display();
                return;
            }
        }

        Console.WriteLine("Book Not Found!");
    }

    static void BinarySearch(string title)
    {
        int low = 0;
        int high = books.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            int result = string.Compare(books[mid].Title, title, true);

            if (result == 0)
            {
                Console.WriteLine("\nBook Found");
                books[mid].Display();
                return;
            }
            else if (result < 0)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        Console.WriteLine("Book Not Found!");
    }
}
