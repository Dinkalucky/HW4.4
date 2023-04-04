using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace Task4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            string emailPattern = @"[0-9A-Za-z_.-]+@[0-9a-zA-Z-]+\.[a-zA-Z]{2,4}";
            string phoneNumberPattern = @"[+]\d{2}.\d{4}.\d{7}";
            string urlPattern = @"[w]+[w]+[A-Za-z]+[.]+[a-zA-Z]+[.]+[a-zA-Z]{2,4}";
            string path = @"newFile.txt";
            var url = "https://www.verbformen.ru/";

            WebRequest request = WebRequest.Create(url);

            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());

            string responseText = reader.ReadToEnd();

            Regex regex = new Regex(emailPattern);

            MatchCollection collection = regex.Matches(responseText);
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Всі E-Mails:");
                foreach (Match element in collection)
                {
                
                    writer.WriteLine(element.Value);
                }
            }

            regex = new Regex(phoneNumberPattern);

            collection = regex.Matches(responseText);

            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine("\nВсі Номери телефонів:");
                foreach (Match element in collection)
                {

                    writer.WriteLine(element.Value);
                }
            }

            regex = new Regex(urlPattern);

            collection = regex.Matches(responseText);

            using (StreamWriter writer = new StreamWriter(path,true))
            {
                writer.WriteLine("\nВсі веб-сайти:");
                foreach (Match element in collection)
                {

                    writer.WriteLine(element.Value);
                }
            }

            Console.WriteLine("File is ready...");
            Console.ReadKey();
        }
    }
}
