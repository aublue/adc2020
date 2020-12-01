using System;
using System.IO;
using System.Linq;

namespace FirstOfDecember
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("input.txt").Select(x => int.Parse(x));

            //Yeah it's a little bit ugly, but I've promised someone to do this in one line ;)
            var solution = input.Select(x => input.FirstOrDefault(y => y + x == 2020) * x).First(x => x != 0);
            
            Console.WriteLine($"The result for the first day of AdventOfCode is: {solution}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}