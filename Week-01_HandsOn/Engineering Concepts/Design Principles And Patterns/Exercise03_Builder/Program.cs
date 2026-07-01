using System;

namespace BuilderPatternExample
{
    class Computer
    {
        public string CPU { get; private set; }
        public string RAM { get; private set; }
        public string Storage { get; private set; }

        private Computer(Builder builder)
        {
            this.CPU = builder.CPU;
            this.RAM = builder.RAM;
            this.Storage = builder.Storage;
        }

        public class Builder
        {
            public string CPU { get; private set; } = "Default CPU";
            public string RAM { get; private set; } = "Default RAM";
            public string Storage { get; private set; } = "Default Storage";

            public Builder setCPU(string cpu)
            {
                this.CPU = cpu;
                return this;
            }

            public Builder setRAM(string ram)
            {
                this.RAM = ram;
                return this;
            }

            public Builder setStorage(string storage)
            {
                this.Storage = storage;
                return this;
            }

            public Computer build()
            {
                return new Computer(this);
            }
        }

        public void display()
        {
            Console.WriteLine("Computer Configuration:");
            Console.WriteLine("CPU: " + CPU);
            Console.WriteLine("RAM: " + RAM);
            Console.WriteLine("Storage: " + Storage);
        }
    }

    public class Program
    {
        public static void Main()
        {
            Computer myComputer = new Computer.Builder()
                .setCPU("Intel i7")
                .setRAM("16GB")
                .setStorage("1TB SSD")
                .build();

            myComputer.display();
        }
    }
}