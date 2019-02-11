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
}
