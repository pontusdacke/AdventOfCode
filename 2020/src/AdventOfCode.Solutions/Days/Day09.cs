using System.Collections.Generic;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day09 : Day
    {
        private static readonly long part1Answer = 138879426L;

        public Day09()
            : base(parseLongs: true)
        { }

        protected override long Part1()
        {
            for (int i = 25; i < LongInputs.Count; i++)
            {
                var preamble = LongInputs.Skip(i - 25).Take(25).ToList();
                var valids = GetValidNumbers(preamble);

                if (!valids.Contains(LongInputs[i]))
                {
                    return LongInputs[i];
                }
            }

            throw new NoAnswerException();
        }

        private static HashSet<long> GetValidNumbers(List<long> preamble)
        {
            var combinations = new HashSet<long>();

            for (int a = 0; a < preamble.Count; a++)
            {
                for (int b = 0; b < preamble.Count; b++)
                {
                    combinations.Add(preamble[a] + preamble[b]);
                }
            }

            return combinations;
        }

        protected override long Part2()
        {
            for (int i = 0; i < LongInputs.Count; i++)
            {
                var set = FindSetFromIndex(i);
                if (set != null)
                {
                    return set.Value;
                }
            }

            throw new NoAnswerException();
        }

        private long? FindSetFromIndex(int i)
        {
            var contiguousSet = new List<long>();
            for (int j = i; j < LongInputs.Count; j++)
            {
                contiguousSet.Add(LongInputs[j]);
                var sum = contiguousSet.Sum();

                if (sum > part1Answer)
                {
                    break;
                }
                
                if (sum == part1Answer)
                {
                    var min = contiguousSet.Min();
                    var max = contiguousSet.Max();
                    return min + max;
                }
            }

            return null;
        }
    }
}
