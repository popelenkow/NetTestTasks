using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedListTask.Core
{
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        public IDoubleLinkedListNode<T> First => throw new NotImplementedException();

        public IDoubleLinkedListNode<T> Last => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public void AddFirst(T value)
        {
            throw new NotImplementedException();
        }

        public void AddLast(T value)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Reverse()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Enumerator : IEnumerator<T>
        {
            public T Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
