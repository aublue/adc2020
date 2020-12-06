using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VI_OfDecemberTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var inputLists = ParseInput(input);

            var totalCount = inputLists.Sum(x => x.Replace(" ", "").Distinct().Count());
            
            Console.WriteLine($"Total answer count: {totalCount}");
        }
        
        /// <summary>
        /// This Method groups all strings separated by a blank line. 
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private static IEnumerable<string> ParseInput(String[] inputStr)
        {
            var passportStrings = new List<String>();
            
            var currStrGroup = "";
            for (var i = 0; i < inputStr.Length; i++)
            {
                var line = inputStr[i];
                currStrGroup += " " + line;
                
                if (String.IsNullOrWhiteSpace(line) || i == inputStr.Length - 1)
                {
                    var strCpy = currStrGroup;
                    currStrGroup = "";
                    yield return strCpy;
                }
            }
        }
    }
}