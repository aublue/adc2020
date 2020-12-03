using System;
using System.IO;

namespace ThirdOfDecemberTaskOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = File.ReadAllLines("input.txt");
            var inputArr = TaskParser.Parse(inputText);

            int treePosition = 0, treeCount = 0;

            for(int line = 1; line < inputArr.GetLength(0); line++)
            {
                //Utilizing the mod function to return to stretch the input array infinitely on the x axis
                treePosition = (treePosition + 3) % inputArr.GetLength(1);
                treeCount += inputArr[line, treePosition]; //1 = tree, 0 = freespace, so it's a simple addition.
            }
            
            Console.WriteLine($"The TreeCount on your way to the bottom is: {treeCount}");
        }
        
        
        
    }
}