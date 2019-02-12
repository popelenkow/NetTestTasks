using DoubleLinkedListTask.Core;
using System;
using System.Collections.Generic;

namespace DoubleLinkedListTask.ConsoleApplication
{
    public class HelpCommand : ICommand
    {
        private readonly Func<IReadOnlyCollection<string>> _allHandlerDescriptions;

        public HelpCommand(Func<IReadOnlyCollection<string>> allHandlerDescriptions)
        {
            _allHandlerDescriptions = allHandlerDescriptions;
        }

        public void Execute(object parameter)
        {
            foreach (var d in _allHandlerDescriptions.Invoke())
            {
                Console.WriteLine(d);
            }
        }

        public string GetDescription()
        {
            return "help all commands";
        }
    }

    public class QuitCommand : ICommand
    {
        private readonly Action _exit;
        public QuitCommand(Action exit)
        {
            _exit = exit;
        }

        public void Execute(object parameter)
        {
            if (_exit != null)
            {
                _exit.Invoke();
            }
            else Environment.Exit(0);
        }

        public string GetDescription()
        {
            return "exit application";
        }
    }

    public class CreateListCommand<T> : Command<ListNameParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public CreateListCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(ListNameParameter<T> parameter)
        {
            if (_lists.ContainsKey(parameter.ListName))
            {
                Console.WriteLine("List already exists");
            }
            else
            {
                _lists.Add(parameter.ListName, new DoubleLinkedList<T>());
                Console.WriteLine("List created");
            }
        }

        public override string GetDescription()
        {
            return "creates double linked list";
        }
    }


    public class DeleteListCommand<T> : Command<ListNameParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public DeleteListCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(ListNameParameter<T> parameter)
        {
            if (!_lists.ContainsKey(parameter.ListName))
            {
                Console.WriteLine("List not found");
            }
            else
            {
                _lists.Remove(parameter.ListName);
                Console.WriteLine("List deleted");
            }
        }

        public override string GetDescription()
        {
            return "deletes double linked list";
        }
    }

    public class AddFirstElementToListCommand<T> : Command<AddElementToListParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public AddFirstElementToListCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(AddElementToListParameter<T> parameter)
        {
            if (_lists.TryGetValue(parameter.ListName, out var list))
            {
                list.AddFirst(parameter.Element);
                Console.WriteLine("List added");
            }
            else
            {
                Console.WriteLine("List not found");
            }
        }

        public override string GetDescription()
        {
            return "add first element to double linked list";
        }
    }

    public class AddLastElementToListCommand<T> : Command<AddElementToListParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public AddLastElementToListCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(AddElementToListParameter<T> parameter)
        {
            if (_lists.TryGetValue(parameter.ListName, out var list))
            {
                list.AddLast(parameter.Element);
                Console.WriteLine("List added");
            }
            else
            {
                Console.WriteLine("List not found");
            }
        }

        public override string GetDescription()
        {
            return "add last element to double linked list";
        }
    }

    public class PrintListElementsCommand<T> : Command<ListNameParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public PrintListElementsCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(ListNameParameter<T> parameter)
        {
            if (_lists.TryGetValue(parameter.ListName, out var list))
            {
                foreach (var elem in list)
                {
                    Console.WriteLine(elem.ToString());
                }
            }
            else
            {
                Console.WriteLine("List not found");
            }
        }

        public override string GetDescription()
        {
            return "prints all list elements";
        }
    }

    public class PrintCountListElementsCommand<T> : Command<ListNameParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public PrintCountListElementsCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(ListNameParameter<T> parameter)
        {
            if (_lists.TryGetValue(parameter.ListName, out var list))
            {
                Console.WriteLine(list.Count);
            }
            else
            {
                Console.WriteLine("List not found");
            }
        }

        public override string GetDescription()
        {
            return "prints count of list elements";
        }
    }

    public class PrintAllListNamesCommand<T> : ICommand
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public PrintAllListNamesCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public void Execute(object parameter)
        {
            foreach (var list in _lists)
            {
                Console.WriteLine(list.Key);
            }
        }

        public string GetDescription()
        {
            return "prints all list names";
        }
    }

    public class ReverseListElementsCommand<T> : Command<ListNameParameter<T>>
    {
        private readonly IDictionary<string, IDoubleLinkedList<T>> _lists;

        public ReverseListElementsCommand(IDictionary<string, IDoubleLinkedList<T>> lists)
        {
            _lists = lists;
        }

        public override void Execute(ListNameParameter<T> parameter)
        {
            if (_lists.TryGetValue(parameter.ListName, out var list))
            {
                list.Reverse();
                Console.WriteLine("Elements are reversed");
            }
            else
            {
                Console.WriteLine("List not found");
            }
        }

        public override string GetDescription()
        {
            return "reverse list elements";
        }
    }
}
