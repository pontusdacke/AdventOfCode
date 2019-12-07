using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day02 : Day
    {
        public Day02() { }

        public override void Part1()
        {
            var program = input[0]
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            program[1] = 12;
            program[2] = 2;
            Console.WriteLine("Part 1: " + GetOutput(program));
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
                    var output = GetOutput(tempProgram);
                    if (output == 19690720)
                    {
                        Console.WriteLine($"Part 2: {i:D2}{j:D2}");
                    }
                }
            }
        }

        private int GetOutput(List<int> program)
        {
            for (int i = 0; i < program.Count; i++)
            {
                var current = i * 4;
                var op = program[current];
                var inp1 = program[current + 1];
                var inp2 = program[current + 2];
                var output = program[current + 3];

                switch (op)
                {
                    case 1:
                        program[output] = program[inp1] + program[inp2];
                        break;
                    case 2:
                        program[output] = program[inp1] * program[inp2];
                        break;
                    case 99:
                        return program[0];
                }
            }
            
            return program[0];
        }
    }
}
