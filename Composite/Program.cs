using System;
using System.Collections.Generic;

namespace Composite
{
    public interface IProduct
    {
        void Add(IProduct product);
        IList<IProduct> GetProducts();
    }

    public class Apple : IProduct
    {
        public void Add(IProduct product)
        {

        }

        public IList<IProduct> GetProducts()
        {
            return new IProduct[0];
        }
    }

    public class Bread : IProduct
    {
        public void Add(IProduct product)
        {
        }

        public IList<IProduct> GetProducts()
        {
            return new IProduct[0];
        }
    }

    public class Tuna : IProduct
    {
        public void Add(IProduct product)
        {
        }

        public IList<IProduct> GetProducts()
        {
            return new IProduct[0];
        }
    }



    public class ProductBag : IProduct
    {
        private readonly IList<IProduct> _products;

        public ProductBag()
        {
            _products = new List<IProduct>();
        }

        public void Add(IProduct product)
        {
            _products.Add(product);
        }

        public IList<IProduct> GetProducts()
        {
            return _products;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IProduct appleBag = new ProductBag();
            appleBag.Add(new Apple());
            appleBag.Add(new Apple());
            appleBag.Add(new Apple());

            IProduct breadBag = new ProductBag();
            breadBag.Add(new Apple());
            breadBag.Add(new Apple());

            IProduct marketBag = new ProductBag();
            marketBag.Add(appleBag);
            marketBag.Add(breadBag);
            marketBag.Add(new Tuna());

            Print(marketBag);
        }

        public static void Print(IProduct product)
        {
            Console.WriteLine(product.GetType().Name);

            if (product.GetProducts().Count == 0) return;

            foreach (var prod in product.GetProducts())
            {
                Print(prod);
            }
        }
    }
}
