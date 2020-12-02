using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solutions.Days
{
    public class Day03 : Day
    {
        public override void Part1()
        {
            var wire1 = input[0].Split(',').ToList();
            var wire2 = input[1].Split(',').ToList();
            var closestIntersectionDistance = MoveWire(wire1)
                .Concat(MoveWire(wire2))
                .GroupBy(x => new { x.x, x.y })
                .Where(x => x.Count() > 1)
                .Select(intersection => Math.Abs(intersection.Key.x) + Math.Abs(intersection.Key.y))
                .OrderBy(x => x)
                .First();

            Console.WriteLine("Part 1: " + closestIntersectionDistance);
        }
        public override void Part2()
        {
            var wire1 = input[0].Split(',').ToList();
            var wire2 = input[1].Split(',').ToList();
            var wire1positions = MoveWire(wire1);
            var wire2positions = MoveWire(wire2);
            var minimumStepsToIntersection = MoveWire(wire1)
                .Concat(MoveWire(wire2))
                .GroupBy(x => new { x.x, x.y })
                .Where(x => x.Count() > 1)
                .Select(i => GetSteps(wire1, i.Key.x, i.Key.y) + GetSteps(wire2, i.Key.x, i.Key.y))
                .OrderBy(x => x)
                .First();

            Console.WriteLine("Part 2: " + minimumStepsToIntersection);
        }

        private int GetSteps(List<string> wire1, int destX, int destY)
        {
            var steps = 0;
            var currentPosition = (x: 0, y: 0);

            for (int i = 0; i < wire1.Count; i++)
            {
                var move = GetMove(wire1[i]);
                for (int y = 0; y < move.count; y++)
                {
                    currentPosition = MovePosition(currentPosition.x, currentPosition.y, move.direction);
                    steps++;
                    if (currentPosition == (destX, destY))
                    {
                        return steps;
                    }
                }
            }

            return 0;
        }

        private List<(int x, int y)> MoveWire(List<string> wire1)
        {
            var positions = new List<(int, int)>();
            var currentPosition = (x: 0, y: 0);

            for (int i = 0; i < wire1.Count; i++)
            {
                var move = GetMove(wire1[i]);
                for (int y = 0; y < move.count; y++)
                {
                    currentPosition = MovePosition(currentPosition.x, currentPosition.y, move.direction);
                    positions.Add(currentPosition);
                }
            }

            return positions.Distinct().ToList();
        }

        private (char direction, int count) GetMove(string instruction)
        {
            var dir = instruction[0];
            var count = int.Parse(instruction.Substring(1));
            return (dir, count);
        }

        private (int x, int y) MovePosition(int x, int y, char direction)
        {
            switch (direction)
            {
                case 'R':
                    x++;
                    break;
                case 'L':
                    x--;
                    break;
                case 'U':
                    y++;
                    break;
                case 'D':
                    y--;
                    break;
            }
            return (x, y);
        }
    }
}
