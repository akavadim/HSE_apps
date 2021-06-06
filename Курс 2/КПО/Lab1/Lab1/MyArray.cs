using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class MyArray<T> : IEnumerable<T>
    {
        private Stack<T> _date;

        public MyArray()=> _date = new Stack<T>();

        public MyArray(IEnumerable<T> collection) => _date = new Stack<T>(collection);

        public void Add(T item)
        {
            _date.Push(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_date).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_date).GetEnumerator();
        }
    }
}
