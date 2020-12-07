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
            var previous = -1;

            while (previous != bags.Count)
            {
                previous = bags.Count;
                foreach (var ruleInput in Inputs)
                {
                    var rule = ruleInput.Split("contain");
                    var bag = rule[0].Replace(" bags", string.Empty);
                    var contains = rule[1];

                    if (contains.Contains("shiny gold")
                        || bags.Any(b => contains.Contains(b)))
                    {
                        bags.Add(bag);
                    }
                }
            }

            timer.Stop();
            Console.WriteLine($"Part 1: {bags.Count}, in {timer.ElapsedMilliseconds} ms");
        }

        public override void Part2()
        {
        }
    }
}
