using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PontusDacke.AdventOfCode2020.Solutions
{
    public abstract class Day
    {
        protected List<string> inputs;

        public Day()
        {
            inputs = GetInput(int.Parse(GetType().Name.Substring(3)));
        }

        private List<string> GetInput(int day)
        {
            var sessionValue = File.ReadAllText(@"session.txt");
            var client = new RestClient("https://adventofcode.com/2020/day");
            var req = new RestRequest($"{day}/input");
            req.AddCookie("session", sessionValue);
            var resp = client.Execute(req);
            return resp.Content.Split('\n').Where(o => !string.IsNullOrEmpty(o)).ToList();
        }

        public abstract void Part1();
        public abstract void Part2();
    }
}
