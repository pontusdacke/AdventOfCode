using System;
using System.Collections.Generic;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day05 : Day
    {
        protected override long Part1()
        {
            return GetTakenSeatIds().Max();
        }

        protected override long Part2()
        {
            var seats = GetTakenSeatIds().OrderBy(x => x).ToList();
            return GetMySeatId(seats);
        }

        private static int GetMySeatId(List<int> seats)
        {
            for (int i = 0; i < seats.Count; i++)
            {
                var nextSeatId = seats[i] + 1;
                if (seats[i + 1] != nextSeatId)
                {
                    return nextSeatId;
                }
            }

            throw new NoAnswerException();
        }

        private IEnumerable<int> GetTakenSeatIds()
        {
            foreach (var input in Inputs)
            {
                yield return GetSeatID(input);
            }
        }

        private static int GetSeatID(string input)
        {
            var row = ReplaceAndConvertBinary(input[..7], 'B', 'F');
            var seat = ReplaceAndConvertBinary(input[7..], 'R', 'L');
            return row * 8 + seat;
        }

        private static int ReplaceAndConvertBinary(string input, char one, char zero)
        {
            var binary = input.Replace(one, '1').Replace(zero, '0');
            return Convert.ToInt32(binary, 2);
        }
    }
}
