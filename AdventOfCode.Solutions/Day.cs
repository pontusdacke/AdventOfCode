using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Solutions
{
    abstract class Day
    {
        // Shamelessly stolen from johgro
        protected List<string> input;

        public Day()
        {
            input = GetInput(int.Parse(GetType().Name.Substring(3)));
        }

        private List<string> GetInput(int day)
        {
            var sessionValue = File.ReadAllText(@"C:\git\AdventOfCode2019\AdventOfCode.Solutions\session.txt");
            var client = new RestClient("https://adventofcode.com/2019/day");
            var req = new RestRequest($"{day}/input");
            req.AddCookie("session", sessionValue);
            var resp = client.Execute(req);
            return resp.Content.Split('\n').Where(o => !string.IsNullOrEmpty(o)).ToList();
        }

        public abstract void Part1();
        public abstract void Part2();
    }
}
