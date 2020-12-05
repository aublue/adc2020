using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace V_OfDecemberTaskTwo
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
            var boardingIds  = positions.Select(x => x.Item1 * 8 + x.Item2);

            var ownSeat = GetOwnSeatId(boardingIds);
            
            Console.WriteLine($"Your own boarding pass id is: {ownSeat}");
        }

        /// <summary>
        /// This Method calcs the current and the next two boarding pass ids. The constrain is that the current and the seat next over are populated. 
        /// </summary>
        /// <param name="boardingIds">All known boarding pass Ids</param>
        /// <returns>Your own Seat id</returns>
        private static int GetOwnSeatId(IEnumerable<int> boardingIds)
        {
            var enumerable = boardingIds as int[] ?? boardingIds.ToArray(); //prevent the IEnumerable to evaluate multiple times
            for (var r = 0; r < 128; r++)
            {
                for (var c = 0; c < 8; c++)
                {
                    var currentBoardingId = r * 8 + c;
                    var nextBoardingId = ((r + 1) % 127) * 8 + ((c + 1) % 7);
                    var overNextBoardingId = ((r + 2) % 127) * 8 + ((c + 2) % 7);

                    if (enumerable.Contains(currentBoardingId) && !enumerable.Contains(nextBoardingId) &&
                        enumerable.Contains(overNextBoardingId))
                    {
                        return nextBoardingId;
                    }
                }
            }

            return -1;
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