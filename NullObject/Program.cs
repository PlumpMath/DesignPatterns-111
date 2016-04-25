using System;
using System.Collections.Generic;

namespace NullObject
{
    public interface ICellPhone
    {
        void PrintInfo();
    }

    public class Nokia : ICellPhone
    {
        public void PrintInfo()
        {
            Console.WriteLine("Nokia!");
        }
    }

    public class Samsung : ICellPhone
    {
        public void PrintInfo()
        {
            Console.WriteLine("Samsung!");
        }
    }

    public class Iphone : ICellPhone
    {
        public void PrintInfo()
        {
            Console.WriteLine("IPhone!");
        }
    }

    public class NullPhone : ICellPhone
    {
        public void PrintInfo()
        {
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IList<ICellPhone> cellPhoneList = new List<ICellPhone>();
            cellPhoneList.Add(new Iphone());
            cellPhoneList.Add(new Samsung());
            cellPhoneList.Add(new NullPhone());
            cellPhoneList.Add(new Samsung());
            cellPhoneList.Add(new Nokia());
            cellPhoneList.Add(new Iphone());

            foreach (var cell in cellPhoneList)
            {
                cell.PrintInfo();
            }
        }
    }
}
