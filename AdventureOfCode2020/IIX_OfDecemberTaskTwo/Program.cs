using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IIX_OfDecemberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(x => long.Parse(x)).ToArray();

            //getting the wrong number
            long firstError = -1;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (!PrvNumbersContainCurrNo(i, input, 25))
                {
                    firstError = input[i];
                } 
            }

            int firstIndex = 0, range = 0;
            //getting the range which contains the amount of the error
            for (int i = 0; i < input.Length; i++)
            {
                firstIndex = i;
                range = GetRange(i, input, firstError);

                if (range != -1)
                {
                    break;
                }
            }
            
            //getting the min/max value in this range
            var Numbers = input.Skip(firstIndex).Take(range);

            var min = Numbers.Min();
            var max = Numbers.Max();

            var total = min + max;

            Console.WriteLine($"The sum of the min and max value is: {total}");
        }

        private static int GetRange(int currentIndex, long[] input, long targetNo)
        {
            long totalCount = 0;
            int floatingIndex = currentIndex;
            
            while (floatingIndex != input.Length - 1 && totalCount < targetNo)
            {
                totalCount += input[floatingIndex];
                floatingIndex++;
            }

            if (totalCount == targetNo)
            {
                return floatingIndex - currentIndex;
            }
            else return -1;
        }

        private static bool PrvNumbersContainCurrNo(int currentIndex, long[] input, int range)
        {
            if (currentIndex - range < 0) return true; //first X items

            for (int i = currentIndex - range; i < currentIndex; i++)
            {
                for (int j = currentIndex - range; j < currentIndex; j++)
                {
                    if (input[i] + input[j] == input[currentIndex]) return true;
                }
            }

            return false;
        }
    }
}