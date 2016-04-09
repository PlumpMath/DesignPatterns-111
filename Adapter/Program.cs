using System;

namespace LegacyLib
{
    public interface IMessage
    {
        string[] GetBody();
        void Print();
    }

    public class MultipleLineMessage : IMessage
    {
        public string[] GetBody()
        {
            return new []{ "Multiple" , "Line", "Message" };
        }

        public void Print()
        {
            foreach (var text in GetBody())
            {
                Console.WriteLine(text);
            }
        }
    }
}

namespace Adapter
{
    public interface IMessage
    {
        string GetBody();
        void Print();
    }

    public class OneLineMessage : IMessage
    {
        public LegacyLib.IMessage LegacyMessage { get; }

        public OneLineMessage(LegacyLib.IMessage message)
        {
            LegacyMessage = message;
        }

        public string GetBody()
        {
            return string.Join(" ", LegacyMessage.GetBody());
        }

        public void Print()
        {
            Console.WriteLine(GetBody());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Legacy Message");
            LegacyLib.IMessage legacyMessage = new LegacyLib.MultipleLineMessage();
            legacyMessage.Print();

            Console.WriteLine("\nMessage with addapter");
            IMessage message = new OneLineMessage(legacyMessage);
            message.Print();
            
        }
    }
}
