
using DoubleLinkedListTask.Core;
using System.Collections.Generic;

namespace DoubleLinkedListTask.ConsoleApplication
{
    class Program
    {
        private static IDictionary<string, IDoubleLinkedList<int>> _lists = new Dictionary<string, IDoubleLinkedList<int>>();

        static void Main(string[] args)
        {
            var host = new ConsoleHost();
            host.RegisterHandler("Create", new ListNameParser<int>(), new CreateListCommand<int>(_lists));
            host.RegisterHandler("Delete", new ListNameParser<int>(), new DeleteListCommand<int>(_lists));
            host.RegisterHandler("AddFirst", new AddElementToListParser<int>(), new AddFirstElementToListCommand<int>(_lists));
            host.RegisterHandler("AddLast", new AddElementToListParser<int>(), new AddLastElementToListCommand<int>(_lists));
            host.RegisterHandler("Print", new ListNameParser<int>(), new PrintListElementsCommand<int>(_lists));
            host.RegisterHandler("Count", new ListNameParser<int>(), new PrintCountListElementsCommand<int>(_lists));
            host.RegisterHandler("All", new EmptyParser(), new PrintAllListNamesCommand<int>(_lists));
            host.RegisterHandler("Reverse", new ListNameParser<int>(), new ReverseListElementsCommand<int>(_lists));
            host.Run();
        }
    }
}
