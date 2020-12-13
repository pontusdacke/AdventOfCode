namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day03 : Day
    {
        protected override long Part1()
        {
            return CountTreesInSlope(3, 1);
        }

        protected override long Part2()
        {
            long slopeA = CountTreesInSlope(1, 1);
            long slopeB = CountTreesInSlope(3, 1);
            long slopeC = CountTreesInSlope(5, 1);
            long slopeD = CountTreesInSlope(7, 1);
            long slopeE = CountTreesInSlope(1, 2);

            var sum = slopeA * slopeB * slopeC * slopeD * slopeE;
            return sum;
        }

        private long CountTreesInSlope(int right, int down)
        {
            var width = Inputs[0].Length;
            var height = Inputs.Count;

            var trees = 0L;
            var x = 0;
            var y = 0;
            while (y < height)
            {
                if (Inputs[y][x] == '#')
                {
                    trees++;
                }
                x = (x + right) % width;
                y += down;
            }

            return trees;
        }
    }
}
