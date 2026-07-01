using System;

namespace StrategyPatternExample
{
    interface PaymentStrategy
    {
        void pay(double amount);
    }

    class CreditCardPayment : PaymentStrategy
    {
        public void pay(double amount)
        {
            Console.WriteLine("Paid " + amount + " using Credit Card.");
        }
    }

    class PayPalPayment : PaymentStrategy
    {
        public void pay(double amount)
        {
            Console.WriteLine("Paid " + amount + " using Google Pay UPI.");
        }
    }

    class PaymentContext
    {
        private PaymentStrategy strategy;

        public PaymentContext(PaymentStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void executePayment(double amount)
        {
            strategy.pay(amount);
        }
    }

    public class Program
    {
        public static void Main()
        {
            PaymentContext context1 = new PaymentContext(new CreditCardPayment());
            context1.executePayment(750.50);

            Console.WriteLine();

            PaymentContext context2 = new PaymentContext(new PayPalPayment());
            context2.executePayment(1400.00);
        }
    }
}