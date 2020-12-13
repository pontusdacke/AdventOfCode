using System;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    internal sealed class Day01 : Day
    {
        protected override void Part1()
        {
            const int sumToFind = 2020;

            for (int i = 0; i < Inputs.Count; i++)
                for (int j = i + 1; j < Inputs.Count; j++)
                {
                    var x = int.Parse(Inputs[i]);
                    var y = int.Parse(Inputs[j]);
                    if (x + y == sumToFind)
                    {
                        Console.WriteLine("Part 1 answer: " + x * y);
                        return;
                    }
                }
        }

        protected override void Part2()
        {
            const int sumToFind = 2020;

            for (int i = 0; i < Inputs.Count; i++)
                for (int j = i + 1; j < Inputs.Count; j++)
                    for (int k = j + 1; k < Inputs.Count; k++)
                    {
                        var x = int.Parse(Inputs[i]);
                        var y = int.Parse(Inputs[j]);
                        var z = int.Parse(Inputs[k]);
                        if (x + y + z == sumToFind)
                        {
                            Console.WriteLine("Part 2 answer: " + x * y * z);
                            return;
                        }
                    }
        }
    }
}
