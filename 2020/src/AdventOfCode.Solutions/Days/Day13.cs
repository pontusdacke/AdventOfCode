using System;
using System.Collections.Generic;
using System.Linq;

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

        protected override long Part2()
        {

            var day13Input = Day13Input.FromInput(Input);
            var max = day13Input.BussIds.Max();
            var maxIndex = day13Input.BussIds.IndexOf(max);
            var time = 274468511433194L;

            while (time % max != 0)
            {
                time++;
            }

            while (true)
            {
                if ((time-maxIndex) % day13Input.BussIds[0] == 0
                    && FindDepartingSequence(day13Input, time - maxIndex))
                        return (time - maxIndex);
                
                time += max.Value;
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
                var busses = sequence.Split(',')
                    .Select(x => long.TryParse(x, out var parsed) ? parsed : (long?)null)
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
