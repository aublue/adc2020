using System;
using System.Collections;

namespace ThirdOfDecemberTaskOne
{
    public static class TaskParser
    {
        /*
         * Converts the toboggan forest to an int array. 0 = free space, 1 = tree
         */

        public static int[,] Parse(String[] input)
        {
            var outputArr = new int[input.Length, input[0].Length];
            
            for (int l = 0; l < input.Length; l++)
            {
                var line = input[l];
                for (int c = 0; c < line.Length; c++)
                {
                    outputArr[l, c] = line[c] == '.' ? 0 : 1;
                }
            }

            return outputArr;
        }
    }
}