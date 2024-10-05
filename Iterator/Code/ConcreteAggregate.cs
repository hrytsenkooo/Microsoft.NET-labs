using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba6
{
    using System.Collections;
    public class ConcreteAggregate<T> : IAggregate<T>
    {
        private List<T> _items = new List<T>();
        public IIterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(this);
        }
        public int Count => _items.Count;
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _items.Count)
                {
                    return _items[index];
                }
                return default(T);
            }
            set
            {
                if (index >= _items.Count)
                {
                    _items.Add(value);
                }
                else
                {
                    _items[index] = value;
                }
            }
        }
    }
}