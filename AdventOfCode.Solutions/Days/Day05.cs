using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day05 : Day
    {
        public Day05() { }

        public override void Part1()
        {
           
            Console.WriteLine("Part 1: ");
        }

        public override void Part2()
        {
            Console.WriteLine("Part 2: ");
        }


        private int GetProgramOutput(List<int> program)
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
                    case 3:
                        program[inp1] = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.Write(program[inp1]);
                        break;
                    case 99:
                        return program[0];
                }
            }

            return program[0];
        }
    }
}
