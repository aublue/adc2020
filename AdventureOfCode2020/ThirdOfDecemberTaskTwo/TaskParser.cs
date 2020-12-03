using System;

namespace ThirdOfDecemberTaskTwo
{
    public static class TaskParser
    {
        /// <summary>
        /// Converts the toboggan forest to an int array. 0 = free space, 1 = tree
        /// </summary>
        /// <param name="input">Input Text representing a binary array while char '.' represents a 0</param>
        /// <returns>Returns a two dimensional int array containing 0 and 1.</returns>
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