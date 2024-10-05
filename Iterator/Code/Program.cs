using laba6;
using System;
namespace IteratorPattern
{
    class MainApp
    {
        static void Main()
        {
            ConcreteAggregate<string> aggregate = new
            ConcreteAggregate<string>();
            aggregate[0] = "Item A";
            aggregate[1] = null;
            aggregate[2] = "Item C";
            aggregate[3] = "Item D";
            aggregate[4] = null;
            aggregate[5] = "Item F";
            IIterator<string> iterator = aggregate.CreateIterator();
            Console.WriteLine("Forward iterating over collection:");
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }
            iterator.ResetToEnd();
            Console.WriteLine("\nBackward iterating over collection:");
            while (iterator.HasPrevious())
            {
                Console.WriteLine(iterator.Previous());
            }
            Console.ReadKey();
        }
    }
}