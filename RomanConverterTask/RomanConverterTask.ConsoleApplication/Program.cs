
using System.IO;
using System.Linq;

namespace RomanConverterTask.ConsoleApplications
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = File.ReadAllLines(@"C:\Users\v.popelenkov\source\repos\tests\NetTestTasks\RomanConverterTask\RomanConverterTask.ConsoleApplication\ff.txt");
            var g = r.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            g = new string[] { "", "M", "MM", "MMM" }.Select(x => g.Select(y => x + y).Append("t")).Aggregate((x, y) => x.Concat(y)).ToArray();
            for (int i = 0; i < g.Length; i++)
            {
                g[i] = "{ " + '"' + g[i] + '"' + ", " + (i + 1).ToString() + " },";
            }
           
            File.WriteAllLines(@"C:\Users\v.popelenkov\source\repos\tests\NetTestTasks\RomanConverterTask\RomanConverterTask.ConsoleApplication\gg.txt", g);
        }
    }
}
