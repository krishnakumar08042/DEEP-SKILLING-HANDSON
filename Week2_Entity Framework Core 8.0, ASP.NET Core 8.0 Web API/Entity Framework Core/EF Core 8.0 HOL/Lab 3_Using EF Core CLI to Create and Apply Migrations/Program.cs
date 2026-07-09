using Models;
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Run migrations using the following commands:");
        Console.WriteLine("dotnet ef migrations add InitialCreate");
        Console.WriteLine("dotnet ef database update");
    }
}
