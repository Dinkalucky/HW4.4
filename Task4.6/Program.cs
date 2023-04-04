using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string login, password;
            string patternLogin = @"^\D$";
            string patternPassword  = @"\d*\D+\d+ | \D*\d+\D+";
            var regex = new Regex(patternLogin);

            Console.WriteLine("Введіть логін");
            login = Console.ReadLine();

            if (!regex.IsMatch(login))
            {
                Console.WriteLine("Логін повинен містити лише букви");
            }

            Console.WriteLine("Введіть пароль");
            password = Console.ReadLine();

            if (!regex.IsMatch(password))
            {
                Console.WriteLine("Пароль повинен містити букви і цифри");
            }

            Console.ReadLine();
        }
    }
}
