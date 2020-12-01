using System;
using System.IO;
using System.Linq;

namespace December02
{
    class Program
    {
        static void Main(string[] args)
        {
            var spreadsheet = File.ReadAllLines("input.txt");
            var matrix = MatrixifySpreadsheet(spreadsheet);

            Console.WriteLine($"Checksum 1: {RepairSpreadsheetCorruption(matrix)}");
            Console.WriteLine($"Checksum 2: {FindEvenDivisibleValues(matrix)}");
        }

        private static int RepairSpreadsheetCorruption(int[][] matrix)
        {
            return matrix
                .Select(row => row
                    .Aggregate(new
                    {
                        MinVal = int.MaxValue,
                        MaxVal = int.MinValue
                    },
                    (acc, o) => new
                    {
                        MinVal = Math.Min(o, acc.MinVal),
                        MaxVal = Math.Max(o, acc.MaxVal)
                    }))
                .Sum(x => Math.Abs(x.MaxVal - x.MinVal));
        }

        private static int FindEvenDivisibleValues(int[][] matrix)
        {
            return matrix
                .Sum(row =>
                   (from numA in row
                    from numB in row
                    where numA % numB == 0 && Math.Max(numA, numB) / Math.Min(numA, numB) != 1
                    select Math.Max(numA, numB) / Math.Min(numA, numB))
                    .Single());
        }

        private static int[][] MatrixifySpreadsheet(string[] spreadsheet)
        {
            return spreadsheet
                .Select(row => row
                    .Split('\t')
                    .Select(x => Convert.ToInt32(x)).ToArray())
                .ToArray();

        }
    }
}
