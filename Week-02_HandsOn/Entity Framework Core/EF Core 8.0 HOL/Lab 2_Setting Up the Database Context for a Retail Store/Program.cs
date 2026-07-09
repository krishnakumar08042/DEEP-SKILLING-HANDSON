using System;
using Microsoft.EntityFrameworkCore;
using Models;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        if (context.Database.CanConnect())
        {
            Console.WriteLine("Lab 2 setup successful  — Models and DbContext are working.");
        }
        else
        {
            Console.WriteLine("Lab 2 — Cannot connect to the database. Check your connection string.");
        }
    }
}
