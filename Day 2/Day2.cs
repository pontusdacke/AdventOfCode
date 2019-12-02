﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File
                .ReadAllText("input.txt")
                .Split(',')
                .Select(x => int.Parse(x))
                .ToList();

            Part1(input);
            Part2(input);

            Console.ReadKey();
        }

        private static void Part1(List<int> input)
        {
            var program = input.ToList();
            program[1] = 12;
            program[2] = 2;
            Console.WriteLine("Part 1: " + GetOutput(program));
        }

        private static void Part2(List<int> input)
        {
            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var program = input.ToList();
                    program[1] = i;
                    program[2] = j;
                    var output = GetOutput(program);
                    if (output == 19690720)
                    {
                        Console.WriteLine($"Part 2: {i:D2}{j:D2}");
                    }
                }
            }
        }

        private static int GetOutput(List<int> program)
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
