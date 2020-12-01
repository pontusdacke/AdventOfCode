using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December08
{
    class Program
    {
        private static int top = int.MinValue;

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input2.txt");

            Console.WriteLine(DoWork(input));
            Console.WriteLine(top);
        }

        private static int DoWork(string[] input)
        {
            Dictionary<string, int> results = Load(input);

            for (int i = 0; i < input.Length; i++)
            {
                var parsedRow = input[i].Split(' ');
                var variable = parsedRow[0];
                var operation = parsedRow[1];
                var value = Convert.ToInt32(parsedRow[2]);
                var comparisonVariable = parsedRow[4];
                var comparisonOperator = parsedRow[5];
                var comparisonValue = Convert.ToInt32(parsedRow[6]);

                var exists = results.TryGetValue(comparisonVariable, out int actualValue);
                switch (operation)
                {
                    case "inc":
                        if (CheckComparison(comparisonValue, actualValue, comparisonOperator))
                        {
                            results[variable] += value;
                        }
                        break;
                    case "dec":
                        if (CheckComparison(comparisonValue, actualValue, comparisonOperator))
                        {
                            results[variable] -= value;
                        }
                        break;
                    default: break;
                }

                var currentMax = results.Max(x => x.Value);
                if (top < currentMax) top = currentMax;
            }

            return results.Max(x => x.Value);
        }

        private static Dictionary<string, int> Load(string[] input)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var parsedRow = input[i].Split(' ');
                var variable = parsedRow[0];

                var exists = dict.TryGetValue(variable, out int ignore);
                if (!exists)
                {
                    dict.Add(variable, 0);
                }
            }
            return dict;
        }

        private static bool CheckComparison(int compareValue, int actualValue, string @operator)
        {
            switch (@operator)
            {
                case ">": return actualValue > compareValue;
                case "<": return actualValue < compareValue;
                case ">=": return actualValue >= compareValue;
                case "<=": return actualValue <= compareValue;
                case "==": return actualValue == compareValue;
                case "!=": return actualValue != compareValue;
                default: return false;
            }
        }
    }
}
