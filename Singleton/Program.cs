using System;
using System.Net.NetworkInformation;
using Singleton;

namespace Singleton
{
    public class BaseClass
    {
        public string TestProperty { get; set; } = "Empty";

        public override string ToString()
        {
            return $"Class Name: {GetType().Name}\nTest Property Value:{TestProperty}\n";
        }
    }

    //Singleton simple
    public class SimpleSingleton : BaseClass
    {
        private static SimpleSingleton _instance;

        private SimpleSingleton() { }

        public static SimpleSingleton Instance => _instance ?? (_instance = new SimpleSingleton());
    }

    //singleton thread safe with single check
    public class ThreadSafeSingleton : BaseClass
    {
        private static ThreadSafeSingleton _instance;
        private static readonly object padlock = new object();

        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    return _instance ?? (_instance = new ThreadSafeSingleton());
                }
            }
        }
    }

    //Singleton thread safe with double ckeck
    public class ThreadSafeDoubleCheckSingleton : BaseClass
    {
        private static ThreadSafeDoubleCheckSingleton _instance;
        private static readonly object padlock = new object();

        public static ThreadSafeDoubleCheckSingleton Instance
        {
            get
            {
                if (_instance != null) return _instance;

                lock (padlock)
                {
                    return _instance ?? (_instance = new ThreadSafeDoubleCheckSingleton());
                }
            }
        }
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        var simpleSingleton = SimpleSingleton.Instance;
        Console.WriteLine(simpleSingleton);
  
        simpleSingleton.TestProperty = "new value";

        var simpleSingletonUpdated = SimpleSingleton.Instance;
        Console.WriteLine(simpleSingletonUpdated);
        

        var threadSafeSingleton = ThreadSafeSingleton.Instance;
        Console.WriteLine(threadSafeSingleton);

        threadSafeSingleton.TestProperty = "new value Single Thread Safe Singleton";

        var threadSafeSingletonUpdated = ThreadSafeSingleton.Instance;
        Console.WriteLine(threadSafeSingletonUpdated);


        var threadSafeDoubleCheckSigleton = ThreadSafeDoubleCheckSingleton.Instance;
        Console.WriteLine(threadSafeDoubleCheckSigleton);

        threadSafeDoubleCheckSigleton.TestProperty = "new value Thread Safe Double Check Sigleton";

        var threadSafeDoubleCheckSigletonUpdated = ThreadSafeSingleton.Instance;
        Console.WriteLine(threadSafeDoubleCheckSigletonUpdated);

    }
}
