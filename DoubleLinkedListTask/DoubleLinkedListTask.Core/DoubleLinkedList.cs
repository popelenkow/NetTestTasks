using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedListTask.Core
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> _first = null;
        private DoubleLinkedListNode<T> _last = null;
        public IDoubleLinkedListNode<T> First => _first;
        public IDoubleLinkedListNode<T> Last => _last;
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            var node = new DoubleLinkedListNode<T>(value);
            if (_first == null)
            {
                _first = node;
                _last = node;
            }
            else
            {
                node.Next = _first;
                _first.Previous = node;
                _first = node;
            }
            Count++;
        }

        public void AddLast(T value)
        {
            var node = new DoubleLinkedListNode<T>(value);
            if (_last == null)
            {
                _first = node;
                _last = node;
            }
            else
            {
                node.Previous = _last;
                _last.Next = node;
                _last = node;
            }
            Count++;
        }

        public void Reverse()
        {
            var cur = _first;
            while (cur != null)
            {
                var previous = cur.Previous;
                var next = cur.Next;
                cur.Previous = next;
                cur.Next = previous;
                cur = next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class Enumerator : IEnumerator<T>
        {
            private IDoubleLinkedListNode<T> _beforeFirst;
            private IDoubleLinkedListNode<T> _current;
            public T Current => _current.Value;
            object IEnumerator.Current => Current;

            public Enumerator(DoubleLinkedListNode<T> first)
            {
                _beforeFirst = new DoubleLinkedListNode<T>
                {
                    Next = first
                };
                _current = _beforeFirst;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_current.Next != null)
                {
                    _current = _current.Next;
                    return true;
                }
                else return false;
            }

            public void Reset()
            {
                _current = _beforeFirst;
            }
        }
    }
}
