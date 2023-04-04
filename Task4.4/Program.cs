using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string path = @"check.txt";
            string pathLoc = @"checkLoc.txt";
            string pathUS = @"checkUS.txt";
            string responseText;
            string pattern = @"\d{2}.\d{2}.\d{4}";
            var american = new CultureInfo("en-US");
            DateTime date;

            using (StreamReader reader = new StreamReader(path))
            {
                responseText = reader.ReadToEnd();
            }

            Regex regex = new Regex(pattern);

            MatchCollection collection = regex.Matches(responseText);
            
            foreach (Match element in collection)
            {
                DateTime.TryParse(element.Value, out date);
                using (StreamWriter writer = new StreamWriter(pathUS))
                {
                    writer.WriteLine(Regex.Replace(responseText, pattern, date.ToString("d", american)));
                }
            }

            foreach (Match element in collection)
            {
                DateTime.TryParse(element.Value, out date);
                using (StreamWriter writer = new StreamWriter(pathLoc))
                {
                    writer.WriteLine(Regex.Replace(responseText, pattern, date.ToString("d", CultureInfo.CurrentCulture)));
                }
            }

            using (StreamReader reader = new StreamReader(pathUS))
            {
                responseText = reader.ReadToEnd();
            }

            Console.WriteLine("en-US:");
            Console.WriteLine(responseText);

            using (StreamReader reader = new StreamReader(pathLoc))
            {
                responseText = reader.ReadToEnd();
            }

            Console.WriteLine("\nLocal:");
            Console.WriteLine(responseText);
            Console.ReadKey();
        }
    }
}
