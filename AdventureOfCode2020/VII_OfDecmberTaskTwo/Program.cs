using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VII_OfDecemberTaskTwo;

namespace VII_OfDecmberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var rawBags = InputParser.ParseInput(input);
            var startBag = rawBags.First(x => x.BagColor == "shiny gold");
            
            int bagCount = TraceBags(rawBags, startBag);

            Console.WriteLine($"Total bag count: {bagCount}");
        }

        static int TraceBags(IEnumerable<Bag> rawBags, Bag currStartPoint)
        {
            var sum = 0;

            foreach (var nestedBag in currStartPoint.ContainingBags)
            {
                sum += nestedBag.Value + nestedBag.Value * TraceBags(rawBags, rawBags.First(x => x.BagColor == nestedBag.Key));
            }

            return sum;
        }
    }
}