using System;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    internal sealed class Day01 : Day
    {
        public override void Part1()
        {
            const int sumToFind = 2020;

            for (int i = 0; i < inputs.Count; i++)
                for (int j = i + 1; j < inputs.Count; j++)
                {
                    var x = int.Parse(inputs[i]);
                    var y = int.Parse(inputs[j]);
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

            for (int i = 0; i < inputs.Count; i++)
                for (int j = i + 1; j < inputs.Count; j++)
                    for (int k = j + 1; k < inputs.Count; k++)
                    {
                        var x = int.Parse(inputs[i]);
                        var y = int.Parse(inputs[j]);
                        var z = int.Parse(inputs[k]);
                        if (x + y + z == sumToFind)
                        {
                            Console.WriteLine("Part 2 answer: " + x * y * z);
                            return;
                        }
                    }
        }
    }
}
