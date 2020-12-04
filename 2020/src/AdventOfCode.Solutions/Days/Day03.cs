using System;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day03 : Day
    {
        public override void Part1()
        {
            var trees = CountTreesInSlope(3, 1);

            Console.WriteLine($"Part 1: {trees}");
        }

        public override void Part2()
        {
            long slopeA = CountTreesInSlope(1, 1);
            long slopeB = CountTreesInSlope(3, 1);
            long slopeC = CountTreesInSlope(5, 1);
            long slopeD = CountTreesInSlope(7, 1);
            long slopeE = CountTreesInSlope(1, 2);

            var sum = slopeA * slopeB * slopeC * slopeD * slopeE;
            Console.WriteLine($"Part 2: {sum}");
        }

        private long CountTreesInSlope(int right, int down)
        {
            var width = inputs[0].Length;
            var height = inputs.Count;

            var trees = 0L;
            var x = 0;
            var y = 0;
            while (y < height)
            {
                if (inputs[y][x] == '#')
                {
                    trees++;
                }
                x = (x + right) % width;
                y += down;
            }

            return trees;
        }
    }
}
