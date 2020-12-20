using System;
using System.Collections.Generic;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day10 : Day
    {
        public Day10() : base(true)
        {

        }

        protected override long Part1()
        {
            var inputs = LongInputs.OrderBy(x => x).ToList();
            var ones = 0;
            var threes = 1;

            var currentJolt = 0L;
            foreach (var input in inputs)
            {
                var diff = input - currentJolt;
                currentJolt = input;
                if (diff == 1) ones++;
                else if (diff == 3) threes++;
            }
            return ones * threes;
        }

        protected override long Part2()
        {
            return 0;
        }
    }
}
