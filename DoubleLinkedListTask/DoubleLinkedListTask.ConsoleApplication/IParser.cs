

using System;

namespace DoubleLinkedListTask.ConsoleApplication
{
    public interface IParser
    {
        object Parse(string line);

        string GetTemplate();
    }

    public interface IParser<T> : IParser
    {
        new T Parse(string line);
    }

    public abstract class Parser<T> : IParser<T>
    {
        public abstract T Parse(string line);

        object IParser.Parse(string line)
        {
            return Parse(line);
        }

        public abstract string GetTemplate();
    }

    public class NotParsedException : Exception
    {
        public string Description { get; }
        public NotParsedException(string decription)
        {
            Description = decription;
        }
    }
}
