using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var map = FindUsedSquares(input);
            Console.WriteLine(map.Sum(x => x.Count(y => y == '1')));
            Console.WriteLine(FindRegions(map));
        }

        private static int FindRegions(List<string> map)
        {
            return 1337;
        }

        private static List<string> FindUsedSquares(string input)
        {
            List<string> hashes = new List<string>();
            var extra = "17,31,73,47,23";

            for (int i = 0; i < 128; i++)
            {
                var hashSource = (input + "-" + i).Select(x => (int)x).Concat(extra.Split(',').Select(x => Convert.ToInt32(x))).ToList();
                var sparseHash = LetsKnot(hashSource, 256, 64);
                var denseHash = ComputeDenseHash(sparseHash);
                var hexHash = Hashify(denseHash);
                var bits = hexHash.Select(x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0'));
                hashes.Add(string.Join(string.Empty, bits));
            }

            return hashes;
        }

        private static List<int> LetsKnot(List<int> input, int count, int rounds)
        {
            var listOfNumbers = Enumerable.Range(0, count).ToList();
            var skipSize = 0;
            var currentPosition = 0;
            for (int x = 0; x < rounds; x++)
            {
                foreach (var length in input)
                {
                    if (length >= listOfNumbers.Count)
                    {
                        continue;
                    }

                    for (int i = currentPosition, j = currentPosition + length - 1; i < j; i++, j--)
                    {
                        int temp = listOfNumbers[j % listOfNumbers.Count];
                        listOfNumbers[j % listOfNumbers.Count] = listOfNumbers[i % listOfNumbers.Count];
                        listOfNumbers[i % listOfNumbers.Count] = temp;
                    }

                    currentPosition += length + skipSize;
                    currentPosition = currentPosition % listOfNumbers.Count;
                    skipSize++;
                }
            }

            return listOfNumbers;
        }

        private static List<int> ComputeDenseHash(List<int> sparseHash)
        {
            var denseHash = new List<int>();

            for (int i = 0; i < sparseHash.Count; i += 16)
            {
                int reduce = sparseHash[i];
                for (int j = 1; j < 16; j++)
                {
                    reduce = reduce ^ sparseHash[i + j];
                }
                denseHash.Add(reduce);
            }

            return denseHash;
        }

        private static string Hashify(List<int> bytes)
        {
            return string.Join(string.Empty, bytes.Select(x => x.ToString("x").PadLeft(2, '0')));//.PadLeft(32, '0');
        }
    }
}
