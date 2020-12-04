using System;
using System.IO;
using System.Linq;

namespace IV_OfDecemberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            
            var validPassportCount = PassportParser.ParseInput(input).Count(x => x.IsValid);

            Console.WriteLine($"In total {validPassportCount} valid Passwords exists in input File");
        }
    }
}