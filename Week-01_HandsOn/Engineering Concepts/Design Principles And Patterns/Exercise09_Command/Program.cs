using System;

namespace CommandPatternExample
{
    interface Command
    {
        void execute();
    }

    class Light
    {
        public void turnOn()
        {
            Console.WriteLine("The light is now ON.");
        }

        public void turnOff()
        {
            Console.WriteLine("The light is now OFF.");
        }
    }

    class LightOnCommand : Command
    {
        private Light light;

        public LightOnCommand(Light light)
        {
            this.light = light;
        }

        public void execute()
        {
            light.turnOn();
        }
    }

    class LightOffCommand : Command
    {
        private Light light;

        public LightOffCommand(Light light)
        {
            this.light = light;
        }

        public void execute()
        {
            light.turnOff();
        }
    }

    class RemoteControl
    {
        private Command? currentCommand;

        public void setCommand(Command cmd)
        {
            this.currentCommand = cmd;
        }

        public void pressButton()
        {
            currentCommand?.execute();
        }
    }

    public class Program
    {
        public static void Main()
        {
            Light livingRoomLight = new Light();
            RemoteControl remote = new RemoteControl();

            LightOnCommand lightOn = new LightOnCommand(livingRoomLight);
            remote.setCommand(lightOn);
            remote.pressButton();

            LightOffCommand lightOff = new LightOffCommand(livingRoomLight);
            remote.setCommand(lightOff);
            remote.pressButton();
        }
    }
}