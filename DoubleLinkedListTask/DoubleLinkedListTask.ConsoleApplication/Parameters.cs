
namespace DoubleLinkedListTask.ConsoleApplication
{
    public class ListNameParameter<T>
    {
        public string ListName { get; set; }
    }

    public class AddElementToListParameter<T> : ListNameParameter<T>
    {
        public T Element { get; set; }
    }
}
