using System;
using System.IO;

namespace ThirdOfDecemberTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = File.ReadAllLines("input.txt");
            var inputArr = TaskParser.Parse(inputText);

            //Calculating the total treeCount by multiple slopes.
            var totalCount = GetTreeCountBySlope(inputArr, 1, 1)
                             * GetTreeCountBySlope(inputArr, 3, 1)
                             * GetTreeCountBySlope(inputArr, 5, 1)
                             * GetTreeCountBySlope(inputArr, 7, 1)
                             * GetTreeCountBySlope(inputArr, 1, 2);

            Console.WriteLine($"The totalCount TreeCount on your way to the bottom is: {totalCount}");
        }

        /// <summary>
        /// This function returns the tree count by a given input and a specific right/down slope.
        /// </summary>
        /// <param name="inputArr"></param>
        /// <param name="right"></param>
        /// <param name="down"></param>
        /// <returns>Returns the amount of trees in the input array as an unsigned long.</returns>
        private static ulong GetTreeCountBySlope(int[,] inputArr, int right, int down)
        {
            int treePosition = 0;
            ulong treeCount = 0;

            for (int line = down; line < inputArr.GetLength(0); line = line + down)
            {
                //Utilizing the mod function to return to stretch the input array infinitely on the x axis
                treePosition = (treePosition + right) % inputArr.GetLength(1);
                treeCount += (ulong) inputArr[line, treePosition]; //1 = tree, 0 = freespace, so it's a simple addition.
            }

            return treeCount;
        }
    }
}