// Adapter Pattern - Conceptual Example
// Cho phép các đối tượng có interface không tương thích làm việc với nhau.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;

namespace Adapter
{
    // Target interface - cái mà Client mong đợi
    public interface ITarget
    {
        string GetRequest();
    }

    // Adaptee - class có sẵn nhưng interface không tương thích
    public class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request from Adaptee.";
        }
    }

    // Adapter - chuyển đổi interface của Adaptee thành ITarget
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptee.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Adapter Pattern Demo ===\n");

            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call its method.\n");

            Console.WriteLine(target.GetRequest());
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
