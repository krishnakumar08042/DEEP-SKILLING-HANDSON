using System;

namespace FactoryMethodPatternExample
{
    interface Document
    {
        void open();
    }

    class WordDocument : Document
    {
        public void open()
        {
            Console.WriteLine("Opening Word document.");
        }
    }

    class PdfDocument : Document
    {
        public void open()
        {
            Console.WriteLine("Opening PDF document.");
        }
    }

    class ExcelDocument : Document
    {
        public void open()
        {
            Console.WriteLine("Opening Excel document.");
        }
    }

    abstract class DocumentFactory
    {
        public abstract Document createDocument();
    }

    class WordFactory : DocumentFactory
    {
        public override Document createDocument()
        {
            return new WordDocument();
        }
    }

    class PdfFactory : DocumentFactory
    {
        public override Document createDocument()
        {
            return new PdfDocument();
        }
    }

    class ExcelFactory : DocumentFactory
    {
        public override Document createDocument()
        {
            return new ExcelDocument();
        }
    }

    public class Program
    {
        public static void Main()
        {
            DocumentFactory factory = new PdfFactory();
            Document doc = factory.createDocument();
            doc.open();
        }
    }
}