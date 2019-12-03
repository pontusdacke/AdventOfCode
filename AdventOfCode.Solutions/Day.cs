using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Solutions
{
    abstract class Day
    {
        private readonly int day;

        public Day(int day)
        {
            this.day = day;
        }

        public List<string> GetInput()
        {
            var sessionValue = File.ReadAllText(@"C:\git\AdventOfCode2019\AdventOfCode.Solutions\session.txt");
            var client = new RestClient("https://adventofcode.com/2019/day");
            var req = new RestRequest($"{day}/input");
            req.AddCookie("session",sessionValue);
            var resp = client.Execute(req);
            return resp.Content.Split('\n').Where(o => !string.IsNullOrEmpty(o)).ToList();
        }

        public abstract void Part1();
        public abstract void Part2();
    }
}
