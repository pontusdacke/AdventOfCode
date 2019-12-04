using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    class Day04 : Day
    {
        public Day04() { }

        public override void Part1()
        {
            List<int> numbers = new List<int>();
            for (int i = 307237; i < 769058; i++)
            {
                if (IsIncreasing(i) && HasAdjacent(i))
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine("Part 1: " + numbers.Count);
        }

        public override void Part2()
        {
            List<int> numbers = new List<int>();
            for (int i = 307237; i < 769058; i++)
            {
                if (IsIncreasing(i) && HasOnlyOneAdjacent(i))
                {
                    numbers.Add(i);
                }
            }
            Console.WriteLine("Part 2: " + numbers.Count);
        }

        private bool IsIncreasing(int number)
        {
            var digits = number.ToString();
            var lastDigit = digits.First();
            for (int i = 1; i < digits.Length; i++)
            {
                if (digits[i] < lastDigit)
                {
                    return false;
                }
                lastDigit = digits[i];
            }
            return true;
        }

        private bool HasAdjacent(int number)
        {
            var digits = number.ToString();
            for (int i = 0; i < digits.Length - 1; i++)
            {
                if (digits[i] == digits[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasOnlyOneAdjacent(int number)
        {
            var digits = number.ToString();
            var hasTwo = false;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                var currentCount = 1;
                var next = i+1;
                
                while (next < digits.Length && digits[i] == digits[next])
                {
                    currentCount++;
                    next++;
                }

                if (currentCount == 2)
                {
                    hasTwo = true;
                }
            }

            return hasTwo;
        }
    }
}
