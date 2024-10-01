using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New_Project
{
    public class MyList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private int _count;

        public MyList()
        {
            _head = null;
            _count = 0;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            newNode.Next = _head;
            _head = newNode;
            _count++;
        }

        public int IndexOf(T data)
        {
            Node<T> current = _head;
            int index = 0;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Data, data))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }

        public int Count
        {
            get { return _count; }
        }

        public T Get(int position)
        {
            if (position < 0 || position >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Invalid position.");
            }

            Node<T> current = _head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public void Remove(T data)
        {
            if (_head == null)
                return;

            if (EqualityComparer<T>.Default.Equals(_head.Data, data))
            {
                _head = _head.Next;
                _count--;
                return;
            }

            Node<T> current = _head;
            while (current.Next != null && !EqualityComparer<T>.Default.Equals(current.Next.Data, data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                _count--;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}