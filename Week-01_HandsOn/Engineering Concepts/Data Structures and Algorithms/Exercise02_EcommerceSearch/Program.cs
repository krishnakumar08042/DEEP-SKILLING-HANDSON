using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Product ID   : " + ProductId);
        Console.WriteLine("Product Name : " + ProductName);
        Console.WriteLine("Category     : " + Category);
    }
}

class Program
{
    static Product[] products =
    {
        new Product(101,"Laptop","Electronics"),
        new Product(102,"Mouse","Electronics"),
        new Product(103,"Keyboard","Electronics"),
        new Product(104,"Shoes","Fashion"),
        new Product(105,"Watch","Accessories")
    };

    static void Main()
    {
        while (true)
        {
           
            Console.WriteLine("1. Display Products");
            Console.WriteLine("2. Linear Search");
            Console.WriteLine("3. Binary Search");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayProducts();
                    break;

                case 2:
                    Console.Write("Enter Product ID: ");
                    int id1 = Convert.ToInt32(Console.ReadLine());
                    LinearSearch(id1);
                    break;

                case 3:
                    Console.Write("Enter Product ID: ");
                    int id2 = Convert.ToInt32(Console.ReadLine());
                    BinarySearch(id2);
                    break;


                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void DisplayProducts()
    {
        foreach (Product p in products)
        {
            p.Display();
        }
    }

    static void LinearSearch(int id)
    {
        bool found = false;

        foreach (Product p in products)
        {
            if (p.ProductId == id)
            {
                Console.WriteLine("\nProduct Found using Linear Search");
                p.Display();
                found = true;
                break;
            }
        }

        if (!found)
            Console.WriteLine("Product Not Found!");
    }

    static void BinarySearch(int id)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (products[mid].ProductId == id)
            {
                Console.WriteLine("\nProduct Found using Binary Search");
                products[mid].Display();
                return;
            }
            else if (products[mid].ProductId < id)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        Console.WriteLine("Product Not Found!");
    }

   
}