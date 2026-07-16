using System;

class Task
{
    public int TaskId;
    public string TaskName;
    public string Status;
    public Task Next;

    public Task(int id, string name, string status)
    {
        TaskId = id;
        TaskName = name;
        Status = status;
        Next = null;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Task ID   : " + TaskId);
        Console.WriteLine("Task Name : " + TaskName);
        Console.WriteLine("Status    : " + Status);
    }
}

class Program
{
    static Task head = null;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== TASK MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Search Task");
            Console.WriteLine("3. Display Tasks");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;

                case 2:
                    SearchTask();
                    break;

                case 3:
                    DisplayTasks();
                    break;

                case 4:
                    DeleteTask();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter Task ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Task Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Status: ");
        string status = Console.ReadLine();

        Task newTask = new Task(id, name, status);

        if (head == null)
        {
            head = newTask;
        }
        else
        {
            Task temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newTask;
        }

        Console.WriteLine("Task Added Successfully!");
    }

    static void SearchTask()
    {
        Console.Write("Enter Task ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Task temp = head;

        while (temp != null)
        {
            if (temp.TaskId == id)
            {
                Console.WriteLine("\nTask Found");
                temp.Display();
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Task Not Found!");
    }

    static void DisplayTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No Tasks Available!");
            return;
        }

        Task temp = head;

        while (temp != null)
        {
            temp.Display();
            temp = temp.Next;
        }
    }

    static void DeleteTask()
    {
        Console.Write("Enter Task ID to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (head == null)
        {
            Console.WriteLine("No Tasks Available!");
            return;
        }

        if (head.TaskId == id)
        {
            head = head.Next;
            Console.WriteLine("Task Deleted Successfully!");
            return;
        }

        Task current = head;

        while (current.Next != null && current.Next.TaskId != id)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            Console.WriteLine("Task Not Found!");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Task Deleted Successfully!");
        }
    }
}
