using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTutorial1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("World");

            Console.Read();
        }
    }
}
