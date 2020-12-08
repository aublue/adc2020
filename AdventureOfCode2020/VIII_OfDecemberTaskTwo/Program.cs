using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VIII_OfDecemberTaskTwo
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

            var result = BruteForceLoop(parsedInput);
            
            Console.WriteLine($"The accumulator of the terminating application is {result}");
        }

        private static int BruteForceLoop((Instruction, int, bool)[] inputData)
        {
            for (var i = 0; i < inputData.Length; i++)
            {
                var tmpArr = inputData.ToArray();
                var currCommand = tmpArr[i];
                
                if (currCommand.Item1 == Instruction.jmp) currCommand.Item1 = Instruction.nop;
                else if (currCommand.Item1 == Instruction.nop) currCommand.Item1 = Instruction.jmp;

                tmpArr[i] = currCommand;
                
                var loopRes = CreatesLoop(tmpArr);
                if(loopRes != -1) return loopRes;
            }

            return -1;
        }


        private static int CreatesLoop((Instruction, int, bool)[] inputData)
        {
            int currentIndex = 0;
            var counter = 0;
            while (inputData[currentIndex].Item3 == false && currentIndex + 1 != inputData.Length) //already touched this item? -> stop looping
            {
                inputData[currentIndex].Item3 = true;
                
                if (inputData[currentIndex].Item1 == Instruction.acc)
                {
                    counter += inputData[currentIndex].Item2;
                }
                
                if (inputData[currentIndex].Item1 == Instruction.jmp)
                {
                    currentIndex += inputData[currentIndex].Item2; //jumpamount
                }
                else currentIndex++;
            }

            if (inputData[currentIndex].Item3 == false)
            {
                return counter;
            }
            else return -1;
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