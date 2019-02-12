
using System;

namespace DoubleLinkedListTask.ConsoleApplication
{
    public class EmptyParser : IParser
    {
        public object Parse(string line)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                throw new NotParsedException($"Should be empty '{line}'");
            }
            return null;
        }

        public string GetTemplate()
        {
            return "";
        }
    }

    public class ListNameParser<T> : Parser<ListNameParameter<T>>
    {
        public override ListNameParameter<T> Parse(string line)
        {
            line = line.TrimStart();
            var listName = line.GetFirstWord();
            line = line.Substring(listName.Length).TrimStart();
            var rest = line.GetFirstWord();


            if (string.IsNullOrEmpty(listName))
            {
                throw new NotParsedException("Should enter list name");
            }
            if (!string.IsNullOrEmpty(rest))
            {
                throw new NotParsedException("List name should contain one word");
            }

            return new ListNameParameter<T>
            {
                ListName = listName
            };
        }

        public override string GetTemplate()
        {
            return "<ListName>";
        }
    }

    public class AddElementToListParser<T> : Parser<AddElementToListParameter<T>>
    {
        public override AddElementToListParameter<T> Parse(string line)
        {
            line = line.TrimStart();
            var element = line.GetFirstWord();
            line = line.Substring(element.Length).TrimStart();
            var to = line.GetFirstWord();
            line = line.Substring(to.Length).TrimStart();
            var listName = line.GetFirstWord();
            line = line.Substring(listName.Length).TrimStart();
            var rest = line.GetFirstWord();

            if (string.IsNullOrEmpty(element))
            {
                throw new NotParsedException("Should enter element");
            }
            if (to != "to")
            {
                throw new NotParsedException("After element should be 'to'");
            }
            if (string.IsNullOrEmpty(listName))
            {
                throw new NotParsedException("Should enter list name");
            }
            if (!string.IsNullOrEmpty(rest))
            {
                throw new NotParsedException("List name should contain one word");
            }

            return new AddElementToListParameter<T>
            {
                ListName = listName,
                Element = (T)Convert.ChangeType(element, typeof(T))
            };
        }

        public override string GetTemplate()
        {
            return "<Element> to <ListName>";
        }
    }
}
