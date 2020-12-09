using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var timer = Stopwatch.StartNew();
            List<Bag> allBags = ParseBags();

            var goldBag = allBags.Single(bag => bag.Color == "shiny gold");
            var total = CountBags(allBags, goldBag);

            timer.Stop();
            var totalWithoutShinyBag = total - 1;
            Console.WriteLine($"Part 2: {totalWithoutShinyBag}, in {timer.ElapsedMilliseconds} ms");
        }

        private List<Bag> ParseBags()
        {
            var allBags = new List<Bag>();
            foreach (var test in Inputs)
            {
                allBags.Add(Bag.FromInput(test));
            }

            return allBags;
        }

        private static int CountBags(List<Bag> allBags, Bag current)
        {
            var actualCurrentBag = allBags.Single(b => b.Color == current.Color);

            if (!actualCurrentBag.Bags.Any())
            {
                return 1;
            }

            return  1 + actualCurrentBag.Bags.Sum(b => b.Count * CountBags(allBags, b));
        }

        class Bag
        {
            public int Count { get; set; }
            public string Color { get; set; }
            public List<Bag> Bags { get; set; }
            public bool EmptyBag { get; set; }

            public static Bag FromInput(string input)
            {
                var rule = input.Split("contain");
                var bagColor = rule[0].Replace(" bags", string.Empty).Trim();
                var bagContents = rule[1].Trim('.').Trim();
                var bagsWithNumber = bagContents.Split(", ");
                var bags = new List<Bag>();

                foreach (var bagWithNumber in bagsWithNumber)
                {
                    if (bagWithNumber.Trim('.') == "no other bags")
                    {
                        break;
                    }
                    int number = bagWithNumber[0] - '0';
                    var color = bagWithNumber.Substring(2).Replace(" bags", string.Empty).Replace(" bag", string.Empty);
                    bags.Add(new Bag
                    {
                        Count = number,
                        Color = color,
                        Bags = new List<Bag>()
                    });
                }

                return new Bag
                {
                    Color = bagColor,
                    Bags = bags
                };
            }
        }
    }
}
