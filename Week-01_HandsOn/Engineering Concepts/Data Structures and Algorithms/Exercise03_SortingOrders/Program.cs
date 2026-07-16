using System;

class Order
{
    public int OrderId;
    public string CustomerName;
    public double TotalPrice;

    public Order(int id, string name, double price)
    {
        OrderId = id;
        CustomerName = name;
        TotalPrice = price;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Order ID      : " + OrderId);
        Console.WriteLine("Customer Name : " + CustomerName);
        Console.WriteLine("Total Price   : " + TotalPrice);
    }
}

class Program
{
    static Order[] orders =
    {
        new Order(101, "Rahul", 2500),
        new Order(102, "Priya", 1800),
        new Order(103, "Amit", 4200),
        new Order(104, "Neha", 3200),
        new Order(105, "Rohan", 1500)
    };

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== SORT CUSTOMER ORDERS =====");
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Bubble Sort");
            Console.WriteLine("3. Quick Sort");
            Console.WriteLine("4. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DisplayOrders();
                    break;

                case 2:
                    BubbleSort();
                    Console.WriteLine("\nOrders Sorted Using Bubble Sort.");
                    DisplayOrders();
                    break;

                case 3:
                    QuickSort(0, orders.Length - 1);
                    Console.WriteLine("\nOrders Sorted Using Quick Sort.");
                    DisplayOrders();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void DisplayOrders()
    {
        foreach (Order order in orders)
        {
            order.Display();
        }
    }

    static void BubbleSort()
    {
        int n = orders.Length;

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                {
                    Order temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
        }
    }

    static void QuickSort(int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(low, high);

            QuickSort(low, pi - 1);
            QuickSort(pi + 1, high);
        }
    }

    static int Partition(int low, int high)
    {
        double pivot = orders[high].TotalPrice;
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (orders[j].TotalPrice < pivot)
            {
                i++;

                Order temp = orders[i];
                orders[i] = orders[j];
                orders[j] = temp;
            }
        }

        Order temp1 = orders[i + 1];
        orders[i + 1] = orders[high];
        orders[high] = temp1;

        return i + 1;
    }
}