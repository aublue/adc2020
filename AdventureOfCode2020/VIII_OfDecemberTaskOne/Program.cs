using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace VIII_OfDecemberTaskOne
{
    enum Instruction
    {
        nop,
        acc,
        jmp
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var parsedInput = ParseInputData(input);

            int currentIndex = 0;
            var counter = 0;
            while (parsedInput[currentIndex].Item3 == false) //already touched this item? -> stop looping
            {
                parsedInput[currentIndex].Item3 = true;
                
                if (parsedInput[currentIndex].Item1 == Instruction.acc)
                {
                    counter += parsedInput[currentIndex].Item2;
                }
                
                if (parsedInput[currentIndex].Item1 == Instruction.jmp)
                {
                    currentIndex += parsedInput[currentIndex].Item2; //jumpamount
                }
                else currentIndex++;
            }
        }

        private static (Instruction, int, bool)[] ParseInputData(String[] input)
        {
            //Instruction, movementamount, touched <= init with false
            var outputList = new List<(Instruction, int, bool)>();

            foreach (var inputLine in input)
            {
                var lineParts = inputLine.Split(' ');
                int amount = 1; //default movement;
                var command = Enum.Parse<Instruction>(lineParts[0]);
                amount = Int32.Parse(lineParts[1]);
                outputList.Add((command, amount, false));
            }

            return outputList.ToArray();
        }
    }
}