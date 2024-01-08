using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazel.movePazleMatrix
{
    class PriorityQueue<T>
    {
        private readonly List<Tuple<T, int>> elements = new List<Tuple<T, int>>();

        public int Count
        {
            get { return elements.Count; }
        }

        public void Enqueue(T item, int priority)
        {
            elements.Add(Tuple.Create(item, priority));
            elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
        }

        public T Dequeue()
        {
            elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            T item = elements[0].Item1;
            elements.RemoveAt(0);
            return item;
        }
    }
}
