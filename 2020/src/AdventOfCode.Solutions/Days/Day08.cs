using System;
using System.Collections.Generic;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day08 : Day
    {
        protected override long Part1()
        {
            var instructions = Inputs
                .Select((value, index) => new Instruction
                {
                    Operation = new string(value.AsSpan()[..3]),
                    Argument = int.Parse(value[3..]),
                }).ToList();

            RunProgram(instructions, out var part1);

            return part1;
        }

        protected override long Part2()
        {
            var instructions = Inputs
                .Select((value, index) => new Instruction
                {
                    Operation = new string(value.AsSpan()[..3]),
                    Argument = int.Parse(value[3..]),
                }).ToList();

            for (int i = 0; i < instructions.Count; i++)
            {
                if (RunProgram(instructions, out var resultA, i))
                {
                    return resultA;
                }
                if (RunProgram(instructions, out var resultB, i))
                {
                    return resultB;
                }
            }

            throw new NoAnswerException();
        }

        private static bool RunProgram(List<Instruction> instructions, out int accumulator, int? switchAtIndex = null)
        {
            var ranInstructions = new List<Instruction>();
            var result = 0;

            for (int i = 0; i < instructions.Count;)
            {
                var instruction = instructions[i];
                if (ranInstructions.Contains(instruction))
                {
                    accumulator = result;
                    return false;
                }

                if (instruction.Operation == "acc")
                {
                    result += instruction.Argument;
                    i++;
                    continue;
                }

                if (switchAtIndex.HasValue && i == switchAtIndex.Value)
                {
                    switch (instruction.Operation)
                    {
                        case "jmp":
                            i++;
                            break;
                        case "nop":
                            i += instruction.Argument;
                            break;
                    }
                }
                else
                {
                    switch (instruction.Operation)
                    {
                        case "nop":
                            i++;
                            break;
                        case "jmp":
                            i += instruction.Argument;
                            break;
                    }
                }
                ranInstructions.Add(instruction);
            }

            accumulator = result;
            return true;
        }

        class Instruction
        {
            public string Operation { get; set; }
            public int Argument { get; set; }
        }
    }
}
