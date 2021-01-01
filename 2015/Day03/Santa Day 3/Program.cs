using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Houses visited: (<X, Y>, Counter)
            Dictionary<Tuple<int,int>, int> housesVisited = new Dictionary<Tuple<int, int>, int>();
            string input = File.ReadAllText("input.txt");
            //int x = 0, y = 0;
            housesVisited.Add(new Tuple<int, int>(0, 0), 1); // First house at X:0, Y:0

            // Part 1
            //foreach (char c in input)
            //{
            //    if      (c == '<') x--;
            //    else if (c == '>') x++;
            //    else if (c == '^') y++;
            //    else if (c == 'v') y--;

            //    Tuple<int, int> t = new Tuple<int, int>(x, y);
            //    if (!housesVisited.ContainsKey(t))
            //        housesVisited.Add(t, 1);
            //}

            // Part 2
            int counter = 0;
            foreach (char c in input)
            {
                if (c == '<') x--;
                else if (c == '>') x++;
                else if (c == '^') y++;
                else if (c == 'v') y--;

                Tuple<int, int> t = new Tuple<int, int>(x, y);
                if (!housesVisited.ContainsKey(t))
                    housesVisited.Add(t, 1);
            }

            Console.WriteLine("Houses visited: {0}", housesVisited.Count);
        }
    }
}
