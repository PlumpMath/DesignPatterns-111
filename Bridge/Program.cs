using System;

namespace Bridge
{
    public interface IColor
    {
        ConsoleColor ApplyColor();
    }

    public class RedColor : IColor
    {
        public ConsoleColor ApplyColor()
        {
            return ConsoleColor.Red;
        }
    }

    public class GreenColor : IColor
    {
        public ConsoleColor ApplyColor()
        {
            return ConsoleColor.Green;
        }
    }

    public class YellowColor : IColor
    {
        public ConsoleColor ApplyColor()
        {
            return ConsoleColor.Yellow;
        }
    }

    public abstract class Console
    {
        public IColor Color { get; }
        public string Text { get; }

        protected Console(string text, IColor color)
        {
            Color = color;
            Text = text;
        }

        protected abstract void Print();

        public void PrintText()
        {
            System.Console.ResetColor();
            System.Console.ForegroundColor = Color.ApplyColor();
            Print();
        }
    }

    public class LinuxTerminar : Console
    {
        public LinuxTerminar(string text, IColor color) : base(text, color) { }

        protected override void Print()
        {
            System.Console.WriteLine("Linux Terminal Example!");
            System.Console.WriteLine(Text);
        }
    }

    public class WindowsConsole : Console
    {
        public WindowsConsole(string text, IColor color) : base(text, color)
        {
        }

        protected override void Print()
        {
            System.Console.WriteLine("Windows Console Example");
            System.Console.WriteLine(Text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console greenLinuxTerminal = new LinuxTerminar("Hey! Is a linux test!", new GreenColor());
            Console yellowLinuxTerminal = new LinuxTerminar("Hey! Is a linux test!", new YellowColor());
            Console redWindowsConsoles = new WindowsConsole("Hey! Is a Windows test!", new RedColor());

            greenLinuxTerminal.PrintText();
            yellowLinuxTerminal.PrintText();
            redWindowsConsoles.PrintText();
        }
    }
}
