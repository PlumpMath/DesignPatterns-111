using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AbstractFactory
{
    public interface IHamburger
    {
        int Price { get; }
        int Calories { get; }
        int Sodium { get; }
        int Cholesterol { get; }
    }

    public abstract class Hamburger : IHamburger
    {
        public int Price { get; }
        public int Calories { get; }
        public int Sodium { get; }
        public int Cholesterol { get; }

        protected Hamburger(int price, int cal, int sodium, int cholesterol)
        {
            Price = price;
            Calories = cal;
            Sodium = sodium;
            Cholesterol = cholesterol;
        }
    }

    public class McBurger : Hamburger
    {
        public McBurger(int price, int cal, int sodium, int cholesterol)
            : base(price, cal, sodium, cholesterol)
        {
        }
    }

    public class Whopper : Hamburger
    {
        public Whopper(int price, int cal, int sodium, int cholesterol)
            : base(price, cal, sodium, cholesterol)
        {
        }
    }

    public interface IFries
    {
        int Price { get; }
        string Size { get; }
    }

    public abstract class Fries : IFries
    {
        public int Price { get; }
        public string Size { get; }

        protected Fries(int price, string size)
        {
            Price = price;
            Size = size;
        }
    }

    public class McPotato : Fries
    {
        public McPotato(int price, string size)
            : base(price, size)
        {
        }
    }

    public class BkFries : Fries
    {
        public BkFries(int price, string size)
            : base(price, size)
        {
        }
    }

    public interface IFastFoodFactory
    {
        IFries CreateFries(int price, string size);
        IHamburger CreateHamburger(int price, int cal, int sodium, int cholesterol);
    }

    public class McdonaldsFactory : IFastFoodFactory
    {
        public IFries CreateFries(int price, string size)
        {
            return new McPotato(price, size);
        }

        public IHamburger CreateHamburger(int price, int cal, int sodium, int cholesterol)
        {
            return new McBurger(price, cal, sodium, cholesterol);
        }
    }

    public class BurgerKingFactory : IFastFoodFactory
    {
        public IFries CreateFries(int price, string size)
        {
            return new BkFries(price, size);
        }

        public IHamburger CreateHamburger(int price, int cal, int sodium, int cholesterol)
        {
            return new Whopper(price, cal, sodium, cholesterol);
        }
    }

    public static class PrintHelper
    {
        public static void Print(this object o)
        {
            var objectMeta = o.GetType();

            Console.WriteLine($"Class Name: {objectMeta.Name}");
            Console.WriteLine("Properties:");

            foreach (var prop in objectMeta.GetProperties())
            {
                Console.WriteLine($"Name: {prop.Name}");
                Console.WriteLine($"Value: {prop.GetValue(o)}");
                Console.WriteLine("--- --- --- --- --- --- ---");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFastFoodFactory factory = new McdonaldsFactory();
            var hamburger = factory.CreateHamburger(100, 400, 10, 8);
            var fries = factory.CreateFries(10, "small");

            hamburger.Print();
            Console.WriteLine();
            fries.Print();

            factory = new BurgerKingFactory();
            hamburger = factory.CreateHamburger(180, 440, 7, 5);
            fries = factory.CreateFries(30, "medium");

            hamburger.Print();
            Console.WriteLine();
            fries.Print();
        }
    }
}
