using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Product(int id, string name, int quantity, double price)
        {
            ProductId = id;
            ProductName = name;
            Quantity = quantity;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Product ID   : " + ProductId);
            Console.WriteLine("Product Name : " + ProductName);
            Console.WriteLine("Quantity     : " + Quantity);
            Console.WriteLine("Price        : " + Price);
        }
    }

    class Program
    {
        static Dictionary<int, Product> inventory = new Dictionary<int, Product>();

        static void Main(string[] args)
        {
            while (true)
            {
               
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Display All Products");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;

                    case 2:
                        UpdateProduct();
                        break;

                    case 3:
                        DeleteProduct();
                        break;

                    case 4:
                        DisplayProducts();
                        break;

                    case 5:
                        SearchProduct();
                        break;


                    case 6:
                        Console.WriteLine("Thank You!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (inventory.ContainsKey(id))
            {
                Console.WriteLine("Product ID already exists!");
                return;
            }

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            inventory[id] = new Product(id, name, qty, price);

            Console.WriteLine("Product Added Successfully!");
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (inventory.ContainsKey(id))
            {
                Console.Write("Enter New Name: ");
                inventory[id].ProductName = Console.ReadLine();

                Console.Write("Enter New Quantity: ");
                inventory[id].Quantity = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Price: ");
                inventory[id].Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Product Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Product Not Found!");
            }
        }

        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (inventory.Remove(id))
                Console.WriteLine("Product Deleted Successfully!");
            else
                Console.WriteLine("Product Not Found!");
        }

        static void DisplayProducts()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("Inventory is Empty!");
                return;
            }

            foreach (var item in inventory.Values)
            {
                item.Display();
            }
        }

        static void SearchProduct()
        {
            Console.Write("Enter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (inventory.ContainsKey(id))
                inventory[id].Display();
            else
                Console.WriteLine("Product Not Found!");
        }

        
    }
}