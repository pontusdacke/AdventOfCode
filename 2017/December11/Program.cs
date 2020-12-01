using System;
using System.IO;

namespace December11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")[0].Split(',');
            Console.WriteLine(DistanceFromMiddle(input));
            Console.WriteLine(Do2(input));
        }

        private static int DistanceFromMiddle(string[] input)
        {
            HexCoord currentCoord = new HexCoord();

            foreach (var dir in input)
            {
                MoveHexCoord(currentCoord, dir);
            }

            return DistanceFromMiddle(currentCoord);
        }

        private static int Do2(string[] input)
        {
            HexCoord currentCoord = new HexCoord();
            int max = 0;

            foreach (var dir in input)
            {
                MoveHexCoord(currentCoord, dir);
                max = Math.Max(max, DistanceFromMiddle(currentCoord));
            }

            return max;
        }

        private static void MoveHexCoord(HexCoord hexCoord, string dir)
        {
            if (dir == "n")
            {
                hexCoord.Y++;
                hexCoord.Z--;
            }
            if (dir == "nw")
            {
                hexCoord.X--;
                hexCoord.Y++;
            }
            if (dir == "ne")
            {
                hexCoord.Z--;
                hexCoord.X++;
            }
            if (dir == "s")
            {
                hexCoord.Y--;
                hexCoord.Z++;
            }
            if (dir == "se")
            {
                hexCoord.Y--;
                hexCoord.X++;
            }
            if (dir == "sw")
            {
                hexCoord.X--;
                hexCoord.Z++;
            }
        }

        private static int DistanceFromMiddle(HexCoord currentCoord)
        {
            return (Math.Abs(currentCoord.X) + Math.Abs(currentCoord.Y) + Math.Abs(currentCoord.Z)) / 2;
        } 

        public class HexCoord
        {
            public int X;
            public int Y;
            public int Z;
        }
    }
}
