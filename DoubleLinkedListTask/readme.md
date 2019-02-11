# DoubleLinkedListTask

### Original text
Реализовать двусвязный список и написать функцию изменяющую порядок элементов на обратный.

```csharp
public interface DoubleLinkedListNode<T>
{
    T Value { get; set; }
    DoubleLinkedNode<T> Next { get; set; }
    DoubleLinkedNode<T> Prev { get; set; }
}
```

```csharp
public interface DoubleLinkedList<T>
{
    DoubleLinkedNode<T> First { get; set; }
    DoubleLinkedNode<T> Last { get; set; }
    void Reverse();
    //insert new DoubleLinkedListNode with given value at the start of the list
    void AddFirst(T value);
    //insert new DoubleLinkedListNode with given value at the end of the list
    void AddLast(T value);
}
```

### Requirement

Должно быть сопровождено юнит-тестом.
