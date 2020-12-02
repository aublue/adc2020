using System;
using System.IO;
using System.Linq;

namespace SecondOfDecemberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var passwordOptions = input.Select(x => new PasswordOption(x));
            var validOptions = passwordOptions.Count(x => x.PasswordValid);
            
            Console.WriteLine($"Valid option count for the advent of code challenge on 2nd December of 2020 Task #1 is: {validOptions}");
        }
    }
}