using System;

namespace AdapterPatternExample
{
    interface PaymentProcessor
    {
        void processPayment(double amount);
    }

    class PaytmGateway
    {
        public void sendWalletAmount(double amount)
        {
            Console.WriteLine("Payment of " + amount + " successful via Paytm Wallet.");
        }
    }

    class GooglePayGateway
    {
        public void transferViaUPI(double amount)
        {
            Console.WriteLine("Payment of " + amount + " successful via Google Pay UPI.");
        }
    }

    class PaytmAdapter : PaymentProcessor
    {
        private PaytmGateway paytm;

        public PaytmAdapter(PaytmGateway paytmInstance)
        {
            this.paytm = paytmInstance;
        }

        public void processPayment(double amount)
        {
            paytm.sendWalletAmount(amount);
        }
    }

    class GooglePayAdapter : PaymentProcessor
    {
        private GooglePayGateway gpay;

        public GooglePayAdapter(GooglePayGateway gpayInstance)
        {
            this.gpay = gpayInstance;
        }

        public void processPayment(double amount)
        {
            gpay.transferViaUPI(amount);
        }
    }

    public class Program
    {
        public static void Main()
        {
            PaytmGateway paytmObj = new PaytmGateway();
            PaymentProcessor firstProcessor = new PaytmAdapter(paytmObj);
            firstProcessor.processPayment(1850.00);

            GooglePayGateway gpayObj = new GooglePayGateway();
            PaymentProcessor secondProcessor = new GooglePayAdapter(gpayObj);
            secondProcessor.processPayment(3200.75);
        }
    }
}