// Decorator Pattern - Conceptual Example
// Attach new behaviors to objects by placing them inside special wrapper objects.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;

namespace Decorator
{
    // Component interface
    public abstract class Component
    {
        public abstract string Operation();
    }

    // Concrete Component
    public class ConcreteComponent : Component
    {
        public override string Operation()
        {
            return "ConcreteComponent";
        }
    }

    // Base Decorator
    public abstract class Decorator : Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            _component = component;
        }

        public void SetComponent(Component component)
        {
            _component = component;
        }

        public override string Operation()
        {
            if (_component != null)
            {
                return _component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // Concrete Decorators
    public class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorA({base.Operation()})";
        }
    }

    public class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(Component component) : base(component)
        {
        }

        public override string Operation()
        {
            return $"ConcreteDecoratorB({base.Operation()})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Decorator Pattern Demo ===\n");

            var simple = new ConcreteComponent();
            Console.WriteLine("Client: I get a simple component:");
            ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
            Console.WriteLine("Client: Now I've got a decorated component:");
            ClientCode(decorator2);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ClientCode(Component component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }
}
