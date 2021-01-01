using System;
using System.IO;
using System.Linq;

namespace Santa_Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(line => line.Split('x'))
                .Select(arr => new
                {
                    l = Int32.Parse(arr[0]),
                    w = Int32.Parse(arr[1]),
                    h = Int32.Parse(arr[2]),
                }).ToList();

            // Part 1
            int paper = 0;
            // 2*l*w + 2*w*h + 2*h*l
            input.ForEach(a => paper += 2 * a.l * a.w + 2 * a.w * a.h + 2 * a.h * a.l + Math.Min(a.l * a.w, Math.Min(a.w * a.h, a.h * a.l)));
            Console.WriteLine("Paper: {0}", paper);

            // Part 2
            int ribbonlength = 0;
            // 2 * l + 2 * w + l*w*h
            input.ForEach(a => ribbonlength += 2*a.l + 2*a.h + 2*a.w - 2 * Math.Max(a.l, Math.Max(a.w, a.h)) + a.l * a.w * a.h);
            Console.WriteLine("Ribbon: {0}", ribbonlength);
        }
    }
}
