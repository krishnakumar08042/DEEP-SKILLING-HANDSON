Console.WriteLine("Hello, World!");
using System;

class Program
{
    static void Main()
    {
        

        Console.Write("Enter Present Value: ");
        double presentValue = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Growth Rate (%): ");
        double growthRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Number of Years: ");
        int years = Convert.ToInt32(Console.ReadLine());

        double futureValue = CalculateFutureValue(presentValue, growthRate, years);

        Console.WriteLine("\nFuture Value after " + years + " years = " + futureValue);
    }

    static double CalculateFutureValue(double value, double rate, int years)
    {
        if (years == 0)
            return value;

        return CalculateFutureValue(value * (1 + rate / 100), rate, years - 1);
    }
}