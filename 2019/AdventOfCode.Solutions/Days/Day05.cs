using AdventOfCode.Solutions.Computers;
using System;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day05 : Day
    {

        public override void Part1()
        {
            var intcodeComputer = new IntcodeComputer(new ComputerInput("1"), new ConsoleOutput());
            var program = input[0]
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            Console.WriteLine("Part 1: ");
            intcodeComputer.GetProgramOutput(program);
        }

        public override void Part2()
        {
            var intcodeComputer = new IntcodeComputer(new ComputerInput("5"), new ConsoleOutput());
            var program = input[0]
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            Console.WriteLine("Part 2: ");
            intcodeComputer.GetProgramOutput(program);
        }
    }
}
