// Composite Pattern - Conceptual Example
// Compose objects into tree structures and work with them as if they were individual objects.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;
using System.Collections.Generic;

namespace Composite
{
    // Component base class
    public abstract class Component
    {
        public abstract string Operation();

        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual bool IsComposite()
        {
            return true;
        }
    }

    // Leaf
    public class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    // Composite
    public class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (Component component in _children)
            {
                result += component.Operation();
                if (i != _children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Composite Pattern Demo ===\n");

            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            ClientCode(leaf);
            Console.WriteLine();

            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            ClientCode(tree);
            Console.WriteLine();

            Console.WriteLine("Client: I don't need to check the components classes even when managing the tree:");
            ClientCode2(tree, leaf);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }

        static void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            Console.WriteLine($"RESULT: {component1.Operation()}");
        }
    }
}
