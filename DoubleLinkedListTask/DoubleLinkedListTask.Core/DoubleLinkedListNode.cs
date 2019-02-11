using System;

namespace DoubleLinkedListTask.Core
{
    public class DoubleLinkedListNode<T> : IDoubleLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Previous { get; set; }
        IDoubleLinkedListNode<T> IDoubleLinkedListNode<T>.Next => Next;
        IDoubleLinkedListNode<T> IDoubleLinkedListNode<T>.Previous => Previous;

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
