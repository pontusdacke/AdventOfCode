using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day13 : Day
    {
        protected override long Part1()
        {
            var day13Input = Day13Input.FromInput(Input);
            var current = day13Input.StartTime;
            long nextBuss;
            while (true)
            {
                nextBuss = day13Input.BussIds.SingleOrDefault(b => current % b == 0);
                if (nextBuss != default)
                {
                    break;
                }
                current++;
            }

            return (current - day13Input.StartTime) * nextBuss;
        }

        protected override long Part2()
        {
            var day13Input = Day13Input.FromInput(Input);

            return default;
        }

        class Day13Input
        {
            public long StartTime { get; private set; }
            public List<long> BussIds { get; private set; }

            public static Day13Input FromInput(string input)
            {
                var stuff = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var number = int.Parse(stuff[0]);
                var sequence = stuff[1];
                var busses = Regex.Matches(sequence, @"\d+").Select(x => long.Parse(x.Value)).ToList();
                return new Day13Input
                {
                    StartTime = number,
                    BussIds = busses.OrderBy(x => x).ToList(),
                };
            }
        }
    }
}
