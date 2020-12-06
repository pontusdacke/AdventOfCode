using System;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day06 : Day
    {
        public override void Part1()
        {
            var result = Input
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Sum(group => MergeParticipants(group)
                    .Distinct()
                    .Count());

            Console.WriteLine($"Part 1: {result}");
        }

        public override void Part2()
        {
            var result = Input
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Sum(group => MergeParticipants(group)
                    .GroupBy(c => c)
                    .Where(c => c.Count() == GetAmountOfParticipants(group))
                    .Distinct()
                    .Count());

            Console.WriteLine($"Part 2: {result}");
        }

        private static int GetAmountOfParticipants(string group)
        {
            return group.TrimEnd('\n').Count(c => c == '\n') + 1;
        }

        private static string MergeParticipants(string group)
        {
            return string.Join(null, group)
                .Replace("\n", string.Empty);
        }
    }
}
