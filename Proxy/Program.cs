using System;
using System.Collections.Generic;

namespace Proxy
{
    public interface IWebPageAccess
    {
        bool Login(string user, string password);
    }

    public class WebPageAccess : IWebPageAccess
    {
        private readonly IDictionary<string, string> _allowedUsers = new Dictionary<string, string>
        {
            {"user1", "1234"},
            {"user2", "12345"},
            {"user3", "123456"}
        };

        public bool Login(string user, string password)
        {
            if (!_allowedUsers.ContainsKey(user))
                return false;

            return _allowedUsers[user] == password;
        }
    }

    public class WebPageAccessProxy : IWebPageAccess
    {
        private IWebPageAccess _realObject;
        private readonly IList<string> _blacklist = new List<string> { "user4", "user5", "user6" };

        public bool Login(string user, string password)
        {
            if (_blacklist.Contains(user))
                return false;

            _realObject = new WebPageAccess();
            return _realObject.Login(user, password);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWebPageAccess webpage = new WebPageAccessProxy();
            Console.WriteLine("User: user44, pwd: 1234");
            Console.WriteLine($"Is a valid user: {webpage.Login("user44", "1234")}");

            Console.WriteLine("User: user1, pwd: 1234");
            Console.WriteLine($"Is a valid user: {webpage.Login("user1", "1234")}");

            Console.WriteLine("User: user3, pwd: 123456");
            Console.WriteLine($"Is a valid user: {webpage.Login("user3", "123456")}");

            Console.WriteLine("User: user6, pwd: 1234");
            Console.WriteLine($"Is a valid user: {webpage.Login("user6", "1234")}");
        }
    }
}
