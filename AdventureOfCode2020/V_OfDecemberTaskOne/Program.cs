using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace V_OfDecemberTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = File.ReadAllLines("input.txt");

            var positions = inputText.Select(
                s => (
                    ParseInputStrIsInt(s.Substring(0, 7), 'F'),
                    ParseInputStrIsInt(s.Substring(s.Length - 3), 'L')
                    ));
            var result = positions.Max(x => x.Item1 * 8 + x.Item2);
            
            Console.WriteLine($"The maximum boarding pass id is: {result}");
        }

        /// <summary>
        /// This method converts a string to an integer. The string has to represent an bit encoded integer.
        /// All other characters than the 0 char are handled as a 1.
        /// </summary>
        /// <param name="input">A bit array representing input string</param>
        /// <param name="zero">The character which should be handled as a 0</param>
        /// <returns></returns>
        private static int ParseInputStrIsInt(String input, char zero)
        {
            var arr = new BitArray(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                arr[arr.Length - i - 1] = !input[i].Equals(zero);
            }

            var outArr = new int[1];
            arr.CopyTo(outArr, 0);
            return outArr[0];
        }
    }
}