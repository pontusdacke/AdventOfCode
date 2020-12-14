using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PontusDacke.AdventOfCode2020.Solutions.Days
{
    class Day14 : Day
    {
        protected override long Part1()
        {
            var registry = new Dictionary<int, long>();

            for (int i = 0; i < Inputs.Count; i++)
            {
                var possibleMask = Inputs[i];
                if (possibleMask.StartsWith("mask"))
                {
                    var mems = i+1;
                    var memInput = Inputs[mems];
                    while (!memInput.StartsWith("mask"))
                    {
                        var data = memInput.Split("=");
                        var address = int.Parse(Regex.Match(data[0], @"\d+").Value);
                        var value = int.Parse(data[1].Trim());
                        var maskedValueBinary = MergeBinary(possibleMask[7..], Binaryfy(value));
                        var maskedValue = Convert.ToInt64(maskedValueBinary, 2);

                        if (!registry.ContainsKey(address))
                            registry.Add(address, maskedValue);
                        else
                            registry[address] = maskedValue;
                        
                        mems++;
                        if (mems == Inputs.Count) break;
                        memInput = Inputs[mems];
                    }
                }
            }

            return registry.Sum(x => x.Value);
        }

        protected override long Part2()
        {
            return 0L;
        }

        private static string MergeBinary(string mask, string number)
        {
            var result = Enumerable.Range(0, 36).Select((val, i) => mask[i] != 'X' ? mask[i] : number[i]);
            return new string(result.ToArray());
        }

        private static string Binaryfy(int number, int length = 36)
        {
            return Convert.ToString(number, 2).PadLeft(length, '0');
        }
    }
}
