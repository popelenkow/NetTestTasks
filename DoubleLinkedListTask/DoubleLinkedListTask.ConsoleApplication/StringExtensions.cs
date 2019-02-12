
namespace DoubleLinkedListTask.ConsoleApplication
{
    public static class StringExtensions
    {
        public static string GetFirstWord(this string line)
        {
            line = line.TrimStart();
            var index = IndexOfWhiteSpace(line);
            return index == -1 ? line : line.Substring(0, index);
        }

        public static int IndexOfWhiteSpace(this string str)
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
