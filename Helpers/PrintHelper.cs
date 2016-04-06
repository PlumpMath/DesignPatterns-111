using System;

namespace Helpers
{
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
}
