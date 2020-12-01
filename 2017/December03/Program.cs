using NUnit.Framework;
using System;

namespace December03
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = 325489;
            Console.WriteLine($"Distance input: {ManhattanDistanceInCirclularMatrix(input)}");
        }

        [TestCase(3, ExpectedResult = 2)]
        [TestCase(5, ExpectedResult = 2)]
        [TestCase(12, ExpectedResult = 3)]
        [TestCase(21, ExpectedResult = 4)]
        [TestCase(22, ExpectedResult = 3)]
        [TestCase(23, ExpectedResult = 2)]
        [TestCase(24, ExpectedResult = 3)]
        [TestCase(31, ExpectedResult = 6)]
        [TestCase(37, ExpectedResult = 6)]
        [TestCase(43, ExpectedResult = 6)]
        [TestCase(44, ExpectedResult = 5)]
        [TestCase(45, ExpectedResult = 4)]
        [TestCase(46, ExpectedResult = 3)]
        [TestCase(47, ExpectedResult = 4)]
        [TestCase(48, ExpectedResult = 5)]
        [TestCase(1024, ExpectedResult = 31)]
        public static int ManhattanDistanceInCirclularMatrix(int input)
        {
            var sqrt = (int)Math.Sqrt(input);
            sqrt = sqrt % 2 == 0 ? sqrt - 1 : sqrt;
            var overflow = input - (sqrt * sqrt);
            var sideOfNextSquare = sqrt + 2;
            var simpleOverflow = overflow % (sideOfNextSquare - 1);
            var halfSide = (sideOfNextSquare - 1) / 2;

            return halfSide + Math.Abs(simpleOverflow - halfSide);
        }

        // Part two: https://oeis.org/A141481/b141481.txt
    }
}
/*
37  36  35  34  33  32  31
38  17  16  15  14  13  30
39  18   5   4   3  12  29
40  19   6   1   2  11  28
41  20   7   8   9  10  27
42  21  22  23  24  25  26
43  44  45  46  47  48  49
*/
