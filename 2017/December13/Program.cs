using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December13
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File
                .ReadAllLines("input.txt")
                .Select(x => new Layer
                {
                    Index = Convert.ToInt32(x.Split(':')[0]),
                    Depth = Convert.ToInt32(x.Split(' ')[1])
                })
                .ToList();


            Console.WriteLine($"caughts: {input.Where(current => current.Index % (current.Depth * 2 - 2) == 0).Sum(x => x.Depth * x.Index)}");

            int i = 0;
            while (true)
            {
                if (input.All(current => (current.Index + i) % (current.Depth * 2 - 2) != 0))
                {
                    Console.WriteLine(i);
                    break;
                }
                i++;
            }
        }

        class Layer
        {
            public int Index;
            public int Depth;
        }
    }
}
