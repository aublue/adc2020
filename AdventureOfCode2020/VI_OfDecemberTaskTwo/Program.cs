using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;

namespace VI_OfDecemberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var inputLines = ParseInput(input).ToList();

            var totalCommonChars = inputLines.Sum(x => CommonCharacters(x));
            Console.WriteLine($"Total common chars: {totalCommonChars}");
        }

        /// <summary>
        /// Returns the amount of shared characters in all lines of the input list
        /// </summary>
        /// <param name="inputLines"></param>
        /// <returns>Total common characters of all lines of the input list</returns>
        private static int CommonCharacters(IEnumerable<string> inputLines)
        {
            var currLines = inputLines as string[] ?? inputLines.ToArray();
            
            IEnumerable<char> lastComparer = currLines.First() ?? "";
            
            foreach (var currLine in currLines)
            {
                lastComparer = lastComparer.Intersect(currLine);
            }

            return lastComparer.Count();
        }
        
        /// <summary>
        /// This Method groups all strings separated by a blank line as a separate IEnumerable. 
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private static IEnumerable<IEnumerable<string>> ParseInput(String[] inputStr)
        {
            var passportStrings = new List<String>();
            
            var currStrGroup = new List<string>();
            for (var i = 0; i < inputStr.Length; i++)
            {
                var line = inputStr[i];
                if(!String.IsNullOrWhiteSpace(line))
                    currStrGroup.Add(line);
                
                if (String.IsNullOrWhiteSpace(line) || i == inputStr.Length - 1)
                {
                    var strGroupCpy = currStrGroup;
                    currStrGroup = new List<string>();
                    yield return strGroupCpy;
                }
            }
        }
    }
}