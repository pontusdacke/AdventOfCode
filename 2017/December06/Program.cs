using System;
using System.Collections.Generic;
using System.Linq;

namespace December06
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "0	5	10	0	11	14	13	4	11	8	8	7	1	4	12	11"
                .Split('\t')
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            Console.WriteLine($"{PeanutButter(input)}");
            Console.WriteLine($"{PeanutButterJelly(input)}");
        }

        private static int PeanutButterJelly(int[] data)
        {
            List<List<int>> states = new List<List<int>>
            {
                data.ToList()
            };

            while (true)
            {
                var max = data.Max();
                var ind = Array.IndexOf(data, max);

                data[ind] -= max;

                for (int j = ind + 1; max > 0; j++)
                {
                    j = j % data.Length;

                    var val = Math.Ceiling(max / (double)data.Length);
                    data[j] += (int)val;
                    max -= (int)val;
                }

                states.Add(data.ToList());

                if (states.Count(x => x.SequenceEqual(data)) > 1)
                {
                    return states.Count - 1;
                }
            }
        }

        private static int PeanutButter(int[] data)
        {
            List<List<int>> states = new List<List<int>>
            {
                data.ToList()
            };

            while (true)
            {
                var max = data.Max();
                var ind = Array.IndexOf(data, max);

                data[ind] -= max;

                for (int j = ind + 1; max > 0; j++)
                {
                    j = j % data.Length;

                    var val = Math.Ceiling(max / (double)data.Length);
                    data[j] += (int)val;
                    max -= (int)val;
                }

                states.Add(data.ToList());

                if (states.Count(x => x.SequenceEqual(states[states.Count - 1])) > 1)
                {
                    return states.Count - 1;
                }
            }
        }
    }
}
