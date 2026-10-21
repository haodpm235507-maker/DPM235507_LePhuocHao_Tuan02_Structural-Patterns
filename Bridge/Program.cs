// Bridge Pattern - Conceptual Example
// Tách abstraction khỏi implementation để cả hai có thể phát triển độc lập.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;

namespace Bridge
{
    // Implementation hierarchy
    public interface IImplementation
    {
        string OperationImplementation();
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationA: Here's the result on the platform A.";
        }
    }

    public class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "ConcreteImplementationB: Here's the result on the platform B.";
        }
    }

    // Abstraction hierarchy
    public class Abstraction
    {
        protected IImplementation _implementation;

        public Abstraction(IImplementation implementation)
        {
            _implementation = implementation;
        }

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" +
                   _implementation.OperationImplementation();
        }
    }

    public class ExtendedAbstraction : Abstraction
    {
        public ExtendedAbstraction(IImplementation implementation) : base(implementation)
        {
        }

        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" +
                   _implementation.OperationImplementation();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Bridge Pattern Demo ===\n");

            ClientCode(new Abstraction(new ConcreteImplementationA()));
            Console.WriteLine();

            ClientCode(new ExtendedAbstraction(new ConcreteImplementationB()));

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ClientCode(Abstraction abstraction)
        {
            Console.WriteLine(abstraction.Operation());
        }
    }
}
