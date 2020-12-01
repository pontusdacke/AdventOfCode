using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December12
{
    class Program
    {
        static List<int> skips2 = new List<int>();

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var rows = Parse(input);
            Console.WriteLine(Do(rows, 0).Count());
            Console.WriteLine(CountGroups(rows));
        }

        private static int CountGroups(List<Row> rows)
        {
            int count = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                var group = Do2(rows, i);
                if (group.Count > 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static List<Row> Parse(string[] input)
        {
            var ret = new List<Row>();
            for (int i = 0; i < input.Length; i++)
            {
                var p = Convert.ToInt32(input[i].Split(' ')[0]);
                var c = input[i]
                    .Split('>')[1]
                    .Replace(" ", string.Empty)
                    .Split(',')
                    .Select(x => Convert.ToInt32(x)).ToList();
                ret.Add(new Row { Program = p, Conns = c });
            }
            return ret;
        }

        private static List<int> Do(List<Row> rows, int group)
        {
            HashSet<int> connected = new HashSet<int>();
            List<int> skips = new List<int>();
            for (int i = 0; i < rows.Count; i++)
            {
                if (skips.Contains(i)) continue;

                var program = rows[i].Program;
                if (program == group)
                {
                    connected.Add(program);
                    connected.UnionWith(rows[i].Conns);
                    skips.Add(i);
                }
                else if (connected.Contains(program))
                {
                    connected.UnionWith(rows[i].Conns);
                    skips.Add(i);
                    i = 0;
                }
            }
            return connected.ToList();
        }

        private static List<int> Do2(List<Row> rows, int group)
        {
            HashSet<int> connected = new HashSet<int>();
            for (int i = 0; i < rows.Count; i++)
            {
                if (skips2.Contains(i)) continue;

                var program = rows[i].Program;
                if (program == group)
                {
                    connected.Add(program);
                    connected.UnionWith(rows[i].Conns);
                    skips2.Add(i);
                }
                else if (connected.Contains(program))
                {
                    connected.UnionWith(rows[i].Conns);
                    skips2.Add(i);
                    i = 0;
                }
            }
            return connected.ToList();
        }

        private struct Row
        {
            public int Program;
            public List<int> Conns;
        }
    }
}
