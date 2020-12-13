using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day13 : Day
    {
        protected override long Part1()
        {
            var day13Input = Day13Input.FromInput(Input);
            var current = day13Input.StartTime;
            long? nextBuss;
            while (true)
            {
                nextBuss = day13Input.BussIds.SingleOrDefault(b => current % b == 0);
                if (nextBuss != default)
                {
                    break;
                }
                current++;
            }

            return (current - day13Input.StartTime) * nextBuss.Value;
        }

        /// <summary>
        /// Too low: 21094670
        /// </summary>
        protected override long Part2()
        {
            var day13Input = Day13Input.FromInput(Input);
            var min = day13Input.BussIds.Min();
            var time = 100000000000000L;

            while (time % min != 0)
            {
                time++;
            }

            while (true)
            {
                if (FindDepartingSequence(day13Input, time))
                    return time;
                time += min.Value;
            }
        }

        private static bool FindDepartingSequence(Day13Input day13Input, long time)
        {
            for (int i = 0; i < day13Input.BussIds.Count; i++)
            {
                var bus = day13Input.BussIds[i];
                if (bus == null)
                {
                    continue;
                }

                var offset = time + i;
                var departs = offset % bus.Value == 0;

                if (!departs)
                {
                    return false;
                }
            }

            return true;
        }

        class Day13Input
        {
            public long StartTime { get; set; }
            public List<long?> BussIds { get; set; }

            public static Day13Input FromInput(string input)
            {
                var stuff = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                var number = int.Parse(stuff[0]);
                var sequence = stuff[1];
                var busses = Regex.Matches(sequence, @"\d+")
                    .Select(x => long.TryParse(x.Value, out var parsed) ? parsed : (long?)null)
                    .ToList();
                return new Day13Input
                {
                    StartTime = number,
                    BussIds = busses,
                };
            }
        }
    }
}
