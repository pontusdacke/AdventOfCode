using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2019
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var wire1 = input[0].Split(',').ToList();
            var wire2 = input[1].Split(',').ToList();

            Part1(wire1, wire2);
            Part2(wire1, wire2);

            Console.ReadKey();
        }

        private static void Part1(List<string> wire1, List<string> wire2)
        {
            var positions = new List<(int, int)>();
            var currentX = 0;
            var currentY = 0;

            MoveWire(wire1, positions, ref currentX, ref currentY);
            currentX = 0;
            currentY = 0;
            MoveWire(wire2, positions, ref currentX, ref currentY);

            var intersections = positions
                .GroupBy(x => new { x.Item1, x.Item2 })
                .Where(x => x.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            var distances = new List<int>();
            foreach (var intersection in intersections)
            {
                distances.Add(Math.Abs(intersection.Item1) + Math.Abs(intersection.Item2));
            }

            Console.WriteLine("Part 1: " + distances.OrderBy(x => x).First());
        }

        private static void MoveWire(List<string> wire1, List<(int, int)> positions, ref int currentX, ref int currentY)
        {
            for (int i = 0; i < wire1.Count; i++)
            {
                var move = GetMove(wire1[i]);
                for (int y = 0; y < move.count; y++)
                {
                    switch (move.direction)
                    {
                        case 'R':
                            currentX++;
                            break;
                        case 'L':
                            currentX--;
                            break;
                        case 'U':
                            currentY++;
                            break;
                        case 'D':
                            currentY--;
                            break;
                    }
                    positions.Add((currentX, currentY));
                }
            }
        }

        private static void Part2(List<string> wire1, List<string> wire2)
        {
        }

        private static (char direction, int count) GetMove(string instruction)
        {
            var dir = instruction[0];
            var count = int.Parse(instruction.Substring(1));
            return (dir, count);
        }
    }
}
