using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        private static Logger? instance = null;
        private static readonly object lockObject = new object();
        private Logger() { }
        public static Logger getInstance()
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void log(string message)
        {
            Console.WriteLine("Log message: " + message);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Logger logger1 = Logger.getInstance();
            Logger logger2 = Logger.getInstance();

            logger1.log("Application started");

            Console.WriteLine("Are both instances same? " + (logger1 == logger2));
        }
    }
}