using System;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    class Day01 : Day
    {
        public Day01() { }

        public override void Part1()
        {
            var sum = input.Sum(x => Math.Floor(int.Parse(x) / 3d) - 2);
            Console.WriteLine(sum);
        }

        public override void Part2()
        {
            double totalSum = 0;
            for (int i = 0; i < input.Count; i++)
            {
                var sum = Math.Floor(int.Parse(input[i]) / 3d) - 2;
                totalSum += sum;
                while (Math.Floor(sum / 3d) - 2 > 0)
                {
                    sum = Math.Floor(sum / 3d) - 2;
                    totalSum += sum;
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
