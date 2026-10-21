// Flyweight Pattern - Conceptual Example
// Lets you fit more objects into the available amount of RAM by sharing common parts of state.
// Nguồn: Refactoring.Guru - Structural Design Patterns

using System;
using System.Collections.Generic;
using System.Linq;

namespace Flyweight
{
    // Flyweight stores shared state (intrinsic)
    public class Flyweight
    {
        private Car _sharedState;

        public Flyweight(Car car)
        {
            _sharedState = car;
        }

        public void Operation(Car uniqueState)
        {
            string s = System.Text.Json.JsonSerializer.Serialize(_sharedState);
            string u = System.Text.Json.JsonSerializer.Serialize(uniqueState);
            Console.WriteLine($"Flyweight: Displaying shared {s} and unique {u} state.");
        }
    }

    // Factory creates and manages flyweights
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> _flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (var elem in args)
            {
                _flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), GetKey(elem)));
            }
        }

        public string GetKey(Car key)
        {
            List<string> elements = new List<string>();
            elements.Add(key.Model);
            elements.Add(key.Color);
            elements.Add(key.Company);

            if (key.Owner != null && key.Number != null)
            {
                elements.Add(key.Number);
                elements.Add(key.Owner);
            }

            elements.Sort();
            return string.Join("_", elements);
        }

        public Flyweight GetFlyweight(Car sharedState)
        {
            string key = GetKey(sharedState);

            if (_flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: Can't find a flyweight, creating new one.");
                _flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else
            {
                Console.WriteLine("FlyweightFactory: Reusing existing flyweight.");
            }
            return _flyweights.Where(t => t.Item2 == key).First().Item1;
        }

        public void ListFlyweights()
        {
            var count = _flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: I have {count} flyweights:");
            foreach (var flyweight in _flyweights)
            {
                Console.WriteLine(flyweight.Item2);
            }
        }
    }

    public class Car
    {
        public string? Owner { get; set; }
        public string? Number { get; set; }
        public string Company { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Flyweight Pattern Demo ===\n");

            var factory = new FlyweightFactory(
                new Car { Company = "Chevrolet", Model = "Camaro2018", Color = "pink" },
                new Car { Company = "Mercedes Benz", Model = "C300", Color = "black" },
                new Car { Company = "Mercedes Benz", Model = "C500", Color = "red" },
                new Car { Company = "BMW", Model = "M5", Color = "red" },
                new Car { Company = "BMW", Model = "X6", Color = "white" }
            );
            factory.ListFlyweights();

            AddCarToPoliceDatabase(factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "M5",
                Color = "red"
            });

            AddCarToPoliceDatabase(factory, new Car
            {
                Number = "CL234IR",
                Owner = "James Doe",
                Company = "BMW",
                Model = "X1",
                Color = "red"
            });

            factory.ListFlyweights();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        public static void AddCarToPoliceDatabase(FlyweightFactory factory, Car car)
        {
            Console.WriteLine("\nClient: Adding a car to database.");

            var flyweight = factory.GetFlyweight(new Car
            {
                Color = car.Color,
                Model = car.Model,
                Company = car.Company
            });

            flyweight.Operation(car);
        }
    }
}
