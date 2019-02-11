using System;

namespace DoubleLinkedListTask.Core
{
    public class DoubleLinkedListNode<T> : IDoubleLinkedListNode<T>
    {
        public T Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDoubleLinkedListNode<T> Next => throw new NotImplementedException();

        public IDoubleLinkedListNode<T> Previous => throw new NotImplementedException();

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
