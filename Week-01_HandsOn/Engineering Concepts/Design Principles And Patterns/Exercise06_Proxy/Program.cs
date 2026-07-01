using System;

namespace ProxyPatternExample
{
    interface Image
    {
        void display();
    }

    class RealImage : Image
    {
        private string filename;

        public RealImage(string filename)
        {
            this.filename = filename;
            loadImageFromServer();
        }

        private void loadImageFromServer()
        {
            Console.WriteLine("Loading image from server: " + filename);
        }

        public void display()
        {
            Console.WriteLine("Displaying image: " + filename);
        }
    }

    class ProxyImage : Image
    {
        private RealImage? realImage = null;
        private string filename;

        public ProxyImage(string filename)
        {
            this.filename = filename;
        }

        public void display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(filename);
            }
            realImage.display();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Image img = new ProxyImage("photo.jpg");

            img.display();
            Console.WriteLine();
            img.display();
        }
    }
}