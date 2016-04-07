using System;

namespace Strategy
{
    public interface IPrintable
    {
        void Print(string text);
    }

    //Strategy: Print text letter by letter each 250ms
    public class PrintByLetter : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"\nStrategy Name {GetType().Name}");
            foreach (var letter in text)
            {
                Console.Write(letter);
                System.Threading.Thread.Sleep(50);
            }
        }
    }

    //Strategy: Print text word by word each 250ms
    public class PrintByWord : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"\nStrategy Name {GetType().Name}");
            foreach (var word in text.Split(' '))
            {
                Console.Write($"{word} ");
                System.Threading.Thread.Sleep(50);
            }
        }
    }

    //Strategy: Print text word by word with different colors
    public class PrintByWordColor : IPrintable
    {
        public void Print(string text)
        {
            Console.WriteLine($"\nStrategy Name {GetType().Name}");
            var random = new Random(DateTime.Now.Millisecond);

            foreach (var word in text.Split(' '))
            {
                Console.ForegroundColor = (ConsoleColor) random.Next(1, 15);
                System.Threading.Thread.Sleep(50);
                Console.Write($"{word} ");
            }

            Console.ResetColor();
        }
    }


    public class ConsoleClient
    {
        public IPrintable PrintStrategy { get; set; }
        public string Text { get; }

        public ConsoleClient(IPrintable printStrategy, string text)
        {
            PrintStrategy = printStrategy;
            Text = text;
        }

        public void Print()
        {
            PrintStrategy.Print(Text);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const string text =
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in " +
                "voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var console = new ConsoleClient(new PrintByLetter(), text);
            console.Print();

            console.PrintStrategy = new PrintByWord();
            console.Print();

            console.PrintStrategy = new PrintByWordColor();
            console.Print();

        }
    }
}
