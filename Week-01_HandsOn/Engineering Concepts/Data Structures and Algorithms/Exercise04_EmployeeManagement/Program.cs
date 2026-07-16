using System;

class Employee
{
    public int EmployeeId;
    public string Name;
    public string Position;
    public double Salary;

    public Employee(int id, string name, string position, double salary)
    {
        EmployeeId = id;
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void Display()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Employee ID : " + EmployeeId);
        Console.WriteLine("Name        : " + Name);
        Console.WriteLine("Position    : " + Position);
        Console.WriteLine("Salary      : " + Salary);
    }
}

class Program
{
    static Employee[] employees = new Employee[10];
    static int count = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== EMPLOYEE MANAGEMENT SYSTEM =====");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. Display Employees");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddEmployee();
                    break;

                case 2:
                    SearchEmployee();
                    break;

                case 3:
                    DisplayEmployees();
                    break;

                case 4:
                    DeleteEmployee();
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }
    }

    static void AddEmployee()
    {
        if (count == employees.Length)
        {
            Console.WriteLine("Employee Array is Full!");
            return;
        }

        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Position: ");
        string position = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        employees[count] = new Employee(id, name, position, salary);
        count++;

        Console.WriteLine("Employee Added Successfully!");
    }

    static void SearchEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                Console.WriteLine("\nEmployee Found");
                employees[i].Display();
                return;
            }
        }

        Console.WriteLine("Employee Not Found!");
    }

    static void DisplayEmployees()
    {
        if (count == 0)
        {
            Console.WriteLine("No Employees Available!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            employees[i].Display();
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to Delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            if (employees[i].EmployeeId == id)
            {
                for (int j = i; j < count - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }

                employees[count - 1] = null;
                count--;

                Console.WriteLine("Employee Deleted Successfully!");
                return;
            }
        }

        Console.WriteLine("Employee Not Found!");
    }
}