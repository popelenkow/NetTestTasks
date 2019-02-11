using System.Collections.Generic;

namespace DoubleLinkedListTask.Core
{
    public interface IDoubleLinkedListNode<T>
    {
        T Value { get; set; }
        IDoubleLinkedListNode<T> Next { get; }
        IDoubleLinkedListNode<T> Previous { get; }
    }
}
