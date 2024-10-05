using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba1
{
    public class ConsolePrint
    {
        public void Print<TValue>(string message, IEnumerable<TValue> singleCollectionQuery)
        {
            Console.Clear();
            Console.WriteLine($"Ви обрали {message}\n");
            foreach (TValue element in singleCollectionQuery)
            {
                Console.WriteLine(element);
            }
        }
        public void Print<TKey, TValue>(string message, IEnumerable<IGrouping<TKey, TValue>> multyCollectionQuery)
        {
            Console.Clear();
            Console.WriteLine($"Ви обрали {message}\n");
            foreach (IGrouping<TKey, TValue> group in multyCollectionQuery)
            {
                foreach (TValue element in group)
                {
                    Console.WriteLine(element);
                }
                Console.WriteLine();
            }
        }
        public void Print<TKey, TValue>(string message, IEnumerable<IGrouping<TKey, IEnumerable<TValue>>> multyCollectionquery)
        {
            foreach (var group in multyCollectionquery)
            {
                Console.WriteLine(group.Key);
                foreach (var element in group)
                Console.WriteLine(element);
            }
        }
    }
}
