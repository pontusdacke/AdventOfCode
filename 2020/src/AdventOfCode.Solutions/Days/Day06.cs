using System;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day06 : Day
    {
        protected override long Part1()
        {
            return Input
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Sum(group => MergeParticipants(group)
                    .Distinct()
                    .Count());
        }

        protected override long Part2()
        {
            return Input
                .Split("\n\n", StringSplitOptions.RemoveEmptyEntries)
                .Sum(group => MergeParticipants(group)
                    .GroupBy(c => c)
                    .Where(c => c.Count() == GetAmountOfParticipants(group))
                    .Distinct()
                    .Count());
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
