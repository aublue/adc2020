using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VII_OfDecemberTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            var rawBags = InputParser.ParseInput(input);
            var startBags = rawBags.Where(x => x.ContainingBags.Contains("shiny gold"));
            
            int bagCount = TraceBags(rawBags, startBags.Select(x => x.BagColor));

            Console.WriteLine($"Total bag count: {bagCount}");
        }

        static int TraceBags(IEnumerable<Bag> rawBags, IEnumerable<string> startBags)
        {
            var currentBags = startBags.ToList();

            var startCount = currentBags.Count;
            foreach (var bag in rawBags)
            {
                if (!currentBags.Contains(bag.BagColor) && bag.ContainingBags.Any(x => currentBags.Contains(x)))
                {
                    currentBags.Add(bag.BagColor);
                }
            }

            if (startCount < currentBags.Count)
            {
                return TraceBags(rawBags, currentBags);
            }
            else return currentBags.Count();
        }
    }
}