using AdventOfCode.Solutions.Computers;
using System;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day02 : Day
    {
        private readonly IntcodeComputer intcodeComputer = new IntcodeComputer(new ComputerInput("0"), new ConsoleOutput());

        public override void Part1()
        {
            var program = input[0]
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            program[1] = 12;
            program[2] = 2;
            Console.WriteLine("Part 1: " + intcodeComputer.GetProgramOutput(program));
        }

        public override void Part2()
        {
            var program = input[0]
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var tempProgram = program.ToList();
                    tempProgram[1] = i;
                    tempProgram[2] = j;
                    var output = intcodeComputer.GetProgramOutput(tempProgram);
                    if (output == 19690720)
                    {
                        Console.WriteLine($"Part 2: {i:D2}{j:D2}");
                    }
                }
            }
        }
    }
}
