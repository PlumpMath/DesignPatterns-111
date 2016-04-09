using System;

namespace Decorator
{
    //Beverage interface used to create base beverages or decorative elements
    public interface IBeverage
    {
        string GetDescription();
        int Cost();
    }

    //Base beverage
    public class Decaf : IBeverage
    {
        public string GetDescription()
        {
            return "Decaf base";
        }

        public int Cost()
        {
            return 250;
        }
    }

    //Base beverage
    public class Espresso : IBeverage
    {
        public string GetDescription()
        {
            return "Espresso Base";
        }

        public int Cost()
        {
            return 280;
        }
    }

    public abstract class CondimentDecorator : IBeverage
    {
        public abstract string GetDescription();
        public abstract int Cost();
        protected IBeverage Beverage { get; private set; }

        protected CondimentDecorator(IBeverage beverage)
        {
            Beverage = beverage;
        }
    }

    public  class Milk : CondimentDecorator
    {
        public Milk(IBeverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + " Milk";
        }

        public override int Cost()
        {
            return  Beverage.Cost() + 100;
        }
    }

    public class Soy : CondimentDecorator
    {
        public Soy(IBeverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + " Soy Milk";
        }

        public override int Cost()
        {
            return Beverage.Cost() + 150;
        }
    }

    public class Mocha : CondimentDecorator
    {
        public Mocha(IBeverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + " Mocha";
        }

        public override int Cost()
        {
            return  Beverage.Cost() + 110;
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(IBeverage beverage) : base(beverage)
        {
        }

        public override string GetDescription()
        {
            return Beverage.GetDescription() + " Whip";
        }

        public override int Cost()
        {
            return Beverage.Cost() + 30;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBeverage cappuccino = new Whip(new Milk(new Espresso()));
            Console.WriteLine(cappuccino.GetDescription());
            Console.WriteLine(cappuccino.Cost());

            IBeverage cappuccinoWDoubleMocha = new Whip(new Milk(new Mocha(new Mocha(new Espresso()))));
            Console.WriteLine(cappuccinoWDoubleMocha.GetDescription());
            Console.WriteLine(cappuccinoWDoubleMocha.Cost());
        }
    }
}
