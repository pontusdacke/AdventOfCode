using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day07 : Day
    {
        public override void Part1()
        {
            var timer = Stopwatch.StartNew();
            var bags = new HashSet<string>();
            var previous = 0;
            do
            {
                previous = bags.Count;
                foreach (var ruleInput in Inputs)
                {
                    var rule = ruleInput.Split("contain");
                    var bagColor = rule[0].Replace(" bags", string.Empty);
                    var canHaveColors = rule[1];

                    if (canHaveColors.Contains("shiny gold")
                        || bags.Any(b => canHaveColors.Contains(b)))
                    {
                        bags.Add(bagColor);
                    }
                }
            } while (previous != bags.Count);

            timer.Stop();
            Console.WriteLine($"Part 1: {bags.Count}, in {timer.ElapsedMilliseconds} ms");
        }

        public override void Part2()
        {
        }
    }
}
