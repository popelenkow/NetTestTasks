using System;

namespace DoubleLinkedListTask.Core
{
    public class DoubleLinkedListNode<T> : IDoubleLinkedListNode<T>
    {
        public T Value { get; set; }

        public IDoubleLinkedListNode<T> Next { get; set; }

        public IDoubleLinkedListNode<T> Previous { get; set; }

        public DoubleLinkedListNode(T value = default(T))
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
