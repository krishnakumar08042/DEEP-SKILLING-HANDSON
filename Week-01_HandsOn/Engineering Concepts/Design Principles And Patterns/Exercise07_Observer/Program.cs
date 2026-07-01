using System;
using System.Collections.Generic;

namespace ObserverPatternExample
{
    interface Observer
    {
        void update(double price);
    }

    interface Stock
    {
        void registerObserver(Observer o);
        void deregisterObserver(Observer o);
        void notifyObservers();
    }

    class StockMarket : Stock
    {
        private List<Observer> observers = new List<Observer>();
        private double price;

        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }

        public void deregisterObserver(Observer o)
        {
            observers.Remove(o);
        }

        public void setPrice(double price)
        {
            this.price = price;
            notifyObservers();
        }

        public void notifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.update(price);
            }
        }
    }

    class MobileApp : Observer
    {
        public void update(double price)
        {
            Console.WriteLine("Mobile App price update: " + price);
        }
    }

    class WebApp : Observer
    {
        public void update(double price)
        {
            Console.WriteLine("Web App price update: " + price);
        }
    }

    public class Program
    {
        public static void Main()
        {
            StockMarket market = new StockMarket();
            MobileApp mobile = new MobileApp();
            WebApp web = new WebApp();

            market.registerObserver(mobile);
            market.registerObserver(web);

            market.setPrice(150.25);
            Console.WriteLine();
            market.setPrice(152.80);
        }
    }
}