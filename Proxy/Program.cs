// Proxy Pattern - Conceptual Example
// Provides a substitute or placeholder for another object. A proxy controls access to the original object.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;

namespace Proxy
{
    // Subject interface
    public interface ISubject
    {
        void Request();
    }

    // Real Subject
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // Proxy
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public void Request()
        {
            if (CheckAccess())
            {
                _realSubject.Request();
                LogAccess();
            }
        }

        public bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        }

        public void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Proxy Pattern Demo ===\n");

            Console.WriteLine("Client: Executing the client code with a real subject:");
            RealSubject realSubject = new RealSubject();
            ClientCode(realSubject);

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            Proxy proxy = new Proxy(realSubject);
            ClientCode(proxy);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static void ClientCode(ISubject subject)
        {
            subject.Request();
        }
    }
}
