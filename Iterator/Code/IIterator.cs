using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace laba6
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
        bool HasPrevious();
        T Previous();
        T Current { get; }
        void Reset();
        void ResetToEnd();
    }
}