using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FirstOfDecemberTaskTwo
{
    class Program
    {
        static void Main()
        {
            var input = File.ReadAllLines("input.txt").Select(x => int.Parse(x));

            //Yeah it's a little bit ugly, but I've promised someone to do this in one line - even If it gets even more messy ;)
            var solution = 
                input.Select(x =>
                    input.Select(y => 
                        input.FirstOrDefault(z => x + y + z == 2020) * y)
                    .FirstOrDefault(x => x != 0) * x
                ).FirstOrDefault(x => x != 0);

            
            Console.WriteLine($"The result for the first day (task 2) of AdventOfCode is: {solution}");
 //           Console.WriteLine("Press any key to continue...");
 //           Console.ReadKey();
        }
    }
}