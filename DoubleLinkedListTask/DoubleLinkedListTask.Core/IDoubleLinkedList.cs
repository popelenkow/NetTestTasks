using System.Collections.Generic;

namespace DoubleLinkedListTask.Core
{
    public interface IDoubleLinkedList<T> : IReadOnlyCollection<T>
    {
        IDoubleLinkedListNode<T> First { get; }
        IDoubleLinkedListNode<T> Last { get; }
        void Reverse();
        /// <summary>
        /// Insert new IDoubleLinkedListNode with given value at the start of the list
        /// </summary>
        void AddFirst(T value);
        /// <summary>
        /// Insert new IDoubleLinkedListNode with given value at the end of the list
        /// </summary>
        void AddLast(T value);
    }
}
