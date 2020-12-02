using System;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day01 : Day
    {
        public override void Part1()
        {
            var sum = inputs.Sum(x => Math.Floor(int.Parse(x) / 3d) - 2);
            Console.WriteLine(sum);
        }

        public override void Part2()
        {
            double totalSum = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                var sum = Math.Floor(int.Parse(inputs[i]) / 3d) - 2;
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
