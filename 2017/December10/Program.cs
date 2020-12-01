using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "83,0,193,1,254,237,187,40,88,27,2,255,149,29,42,100";
            var inputAsInts = input.Split(',').Select(x => Convert.ToInt32(x)).ToList();
            var badKnotHash = LetsKnot(inputAsInts, 256, 1);
            Console.WriteLine(badKnotHash[0] * badKnotHash[1]);

            var extra = "17,31,73,47,23";
            var inputAsBytes = input.Select(x => (int)x).Concat(extra.Split(',').Select(x => Convert.ToInt32(x))).ToList();
            var sparseHash = LetsKnot(inputAsBytes, 256, 64);
            var denseHash = ComputeDenseHash(sparseHash);
            Console.WriteLine(Hashify(denseHash));
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
            return string.Join(string.Empty, bytes.Select(x => x.ToString("x")));
        }
    }
}
