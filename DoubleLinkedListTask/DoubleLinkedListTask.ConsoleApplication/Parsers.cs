
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
}
