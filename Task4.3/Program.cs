using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string pattern = @"В |За | за | на | під ";
            string path = @"text.txt";
            string path2 = @"textReplace.txt";
            string responseText;

            using (StreamReader reader = new StreamReader(path))
            {
                responseText = reader.ReadToEnd();
            }

            Regex regex = new Regex(pattern);

            using (StreamWriter writer = new StreamWriter(path2))
            {
                writer.WriteLine(Regex.Replace(responseText, pattern, " ГАВ! "));
            }

            Console.WriteLine(Regex.Replace(responseText, pattern," ГАВ! "));

            Console.ReadKey();
        }
    }
}
