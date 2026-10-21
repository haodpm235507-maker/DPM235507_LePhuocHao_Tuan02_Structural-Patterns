// Facade Pattern - Conceptual Example
// Provides a simplified interface to a library, a framework, or any other complex set of classes.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;

namespace Facade
{
    // Subsystem classes
    public class Subsystem1
    {
        public string Operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string OperationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    public class Subsystem2
    {
        public string Operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string OperationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }

    // Facade
    public class Facade
    {
        protected Subsystem1 _subsystem1;
        protected Subsystem2 _subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            _subsystem1 = subsystem1;
            _subsystem2 = subsystem2;
        }

        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += _subsystem1.Operation1();
            result += _subsystem2.Operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += _subsystem1.OperationN();
            result += _subsystem2.OperationZ();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Facade Pattern Demo ===\n");

            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            ClientCode(facade);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }
}
