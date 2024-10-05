using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace laba6
{
    public class ConcreteIterator<T> : IIterator<T>
    {
        private readonly ConcreteAggregate<T> _aggregate;
        private int _current = -1;
        public ConcreteIterator(ConcreteAggregate<T> aggregate)
        {
            _aggregate = aggregate;
        }
        public bool HasNext()
        {
            int nextIndex = _current + 1;
            while (nextIndex < _aggregate.Count && _aggregate[nextIndex] ==
            null)
            {
                nextIndex++;
            }
            return nextIndex < _aggregate.Count;
        }
        public T Next()
        {
            do
            {
                _current++;
            } while (_current < _aggregate.Count && _aggregate[_current] == null);
            return _current < _aggregate.Count ? _aggregate[_current] : default(T);
        }
        public bool HasPrevious()
        {
            int prevIndex = _current - 1;
            while (prevIndex >= 0 && _aggregate[prevIndex] == null)
            {
                prevIndex--;
            }
            return prevIndex >= 0;
        }
        public T Previous()
        {
            do
            {
                _current--;
            } while (_current >= 0 && _aggregate[_current] == null);
            return _current >= 0 ? _aggregate[_current] : default(T);
        }
        public T Current => _current >= 0 && _current < _aggregate.Count ?
        _aggregate[_current] : default(T);
        public void Reset()
        {
            _current = -1;
        }
        public void ResetToEnd()
        {
            _current = _aggregate.Count;
        }
    }
}