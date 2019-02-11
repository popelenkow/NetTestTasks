using System;
using System.Collections.Generic;
using System.Linq;

namespace DoubleLinkedListTask.ConsoleApplication
{
    public class ConsoleHost
    {
        private readonly IDictionary<string, (IParser parser, ICommand command)> _handlers;
        private bool _isExit;

        public ConsoleHost()
        {
            _isExit = false;
            _handlers = new Dictionary<string, (IParser parser, ICommand command)>();
            RegisterHelp();
            RegisterQuit();
        }

        public void Run()
        {
            Console.WriteLine("Host started. Enter command.");
            while (!_isExit)
            {
                Console.WriteLine();
                try
                {
                    var consoleLine = Console.ReadLine();
                    var (commandName, line) = SplitConsoleLine(consoleLine);
                    if (_handlers.TryGetValue(commandName, out var handler))
                    {
                        var (parser, command) = handler;
                        var parameter = parser.Parse(line);
                        command.Execute(parameter);
                    }
                    else
                    {
                        Console.WriteLine("Unknown command. Enter 'help'.");
                    }
                }
                catch (NotParsedException exception)
                {
                    Console.WriteLine(exception.Description);
                }
            }
        }

        public void RegisterHandler<T>(string commandName, IParser<T> parser, ICommand<T> command)
        {
            if (IndexOfWhiteSpace(commandName) > -1)
                throw new Exception("Command name should be without spaces");
            _handlers.Add(commandName, (parser, command));
        }

        public void RegisterHandler(string commandName, IParser parser, ICommand command)
        {
            if (IndexOfWhiteSpace(commandName) > -1)
                throw new Exception("Command name should be without spaces");
            _handlers.Add(commandName, (parser, command));
        }

        private void RegisterQuit()
        {
            RegisterHandler("Quit", new EmptyParser(), new QuitCommand(() =>
            {
                _isExit = true;
            }));
        }

        private void RegisterHelp()
        {
            RegisterHandler("Help", new EmptyParser(), new HelpCommand(() =>
            {
                return _handlers
                    .Select(x =>
                    {
                        var commandTemplate = $"{x.Key} {x.Value.parser.GetTemplate()}".TrimEnd();
                        return $"'{commandTemplate}' - {x.Value.command.GetDescription()}";
                    })
                    .ToArray();
            }));
        }

        private (string commandName, string line) SplitConsoleLine(string consoleLine)
        {
            consoleLine = consoleLine.TrimStart();
            var index = IndexOfWhiteSpace(consoleLine);
            var commandName = index == -1 ? consoleLine : consoleLine.Substring(0, index);
            var line = index == -1 ? "" : consoleLine.Substring(index).TrimStart();
            return (commandName, line);
        }

        private int IndexOfWhiteSpace(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsWhiteSpace(str[i]))
                    return i;
            }
            return -1;
        }
    }
}
