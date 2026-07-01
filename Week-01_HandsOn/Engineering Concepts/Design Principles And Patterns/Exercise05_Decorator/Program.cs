using System;

namespace DecoratorPatternExample
{
    interface Notifier
    {
        void send(string message);
    }

    class EmailNotifier : Notifier
    {
        public void send(string message)
        {
            Console.WriteLine("Sending Email: " + message);
        }
    }

    abstract class NotifierDecorator : Notifier
    {
        protected Notifier wrappedNotifier;

        public NotifierDecorator(Notifier notifier)
        {
            this.wrappedNotifier = notifier;
        }

        public virtual void send(string message)
        {
            wrappedNotifier.send(message);
        }
    }

    class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(Notifier notifier) : base(notifier) { }

        public override void send(string message)
        {
            base.send(message);
            Console.WriteLine("Sending SMS: " + message);
        }
    }

    class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(Notifier notifier) : base(notifier) { }

        public override void send(string message)
        {
            base.send(message);
            Console.WriteLine("Sending Slack message: " + message);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Notifier notifier = new EmailNotifier();
            notifier = new SMSNotifierDecorator(notifier);
            notifier = new SlackNotifierDecorator(notifier);

            notifier.send("Alert: System update complete!");
        }
    }
}