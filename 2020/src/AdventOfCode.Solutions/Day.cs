using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions
{
    public abstract class Day
    {
        protected List<long> LongInputs { get; private set; }
        protected List<string> Inputs { get; private set; }
        protected string Input { get; private set; }

        protected Day(bool parseLongs = false)
        {
            Input = GetInput(int.Parse(GetType().Name[3..]));
            Inputs = Input.Split('\n').Where(o => !string.IsNullOrEmpty(o)).ToList();
            if (parseLongs)
                LongInputs = Inputs.Select(i => long.Parse(i)).ToList();
        }

        private static string GetInput(int day)
        {
            var sessionValue = File.ReadAllText(@"session.txt");
            var client = new RestClient("https://adventofcode.com/2020/day");
            var req = new RestRequest($"{day}/input");
            req.AddCookie("session", sessionValue);
            var resp = client.Execute(req);
            return resp.Content;
        }

        public void Run()
        {
            var timer = Stopwatch.StartNew();
            var part1Result = Part1();
            Console.WriteLine($"Part 1: {part1Result}. Time elapsed: {timer.ElapsedMilliseconds}ms");
            timer.Restart();
            var part2Result = Part2();
            Console.WriteLine($"Part 2: {part2Result}. Time elapsed: {timer.ElapsedMilliseconds}ms");
            timer.Stop();
        }

        protected abstract long Part1();
        protected abstract long Part2();
    }
}
