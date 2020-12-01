﻿using System;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    internal sealed class Day01 : Day
    {
        public override void Part1()
        {
            const int sumToFind = 2020;

            for (int i = 0; i < input.Count; i++)
                for (int j = i + 1; j < input.Count; j++)
                {
                    var x = int.Parse(input[i]);
                    var y = int.Parse(input[j]);
                    if (x + y == sumToFind)
                    {
                        Console.WriteLine("Part 1 answer: " + x * y);
                        return;
                    }
                }
        }

        public override void Part2()
        {
            const int sumToFind = 2020;

            for (int i = 0; i < input.Count; i++)
                for (int j = i + 1; j < input.Count; j++)
                    for (int k = j + 1; k < input.Count; k++)
                    {
                        var x = int.Parse(input[i]);
                        var y = int.Parse(input[j]);
                        var z = int.Parse(input[k]);
                        if (x + y + z == sumToFind)
                        {
                            Console.WriteLine("Part 2 answer: " + x * y * z);
                            return;
                        }
                    }
        }
    }
}
