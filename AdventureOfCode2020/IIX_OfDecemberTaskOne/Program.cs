using System;
using System.IO;
using System.Linq;

namespace IIX_OfDecemberTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(x => long.Parse(x)).ToArray();

            long firstError = -1;
            
            for (int i = 0; i < input.Length; i++)
            {
                if (!PrvNumbersContainCurrNo(i, input, 25))
                {
                    firstError = input[i];
                } 
            }
            
            Console.WriteLine($"The first invalid number is: {firstError}");
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