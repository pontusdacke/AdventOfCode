using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December18
{
    class Program
    {
        static Dictionary<char, long> registers = new Dictionary<char, long>();

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            InitializeRegisters();
            Console.WriteLine(DoInstructions(input));
        }

        static long DoInstructions(string[] input)
        {
            long lastPlayed = 0;
            for (long i = 0; i < input.Length; i++)
            {
                var row = input[i];
                var instruction = input[i].Substring(0, 3);

                switch (instruction)
                {
                    case "snd":
                        lastPlayed = GetValue(row.Substring(4));
                        break;
                    case "mod":
                        registers[row[4]] %= GetValue(row.Substring(6));
                        break;
                    case "rcv":
                        if (GetValue(row[4].ToString()) != 0)
                            return lastPlayed;
                            break;
                    case "set":
                        registers[row[4]] = GetValue(row.Substring(6));
                        break;
                    case "sub":
                        registers[row[4]] -= GetValue(row.Substring(6));
                        break;
                    case "add":
                        registers[row[4]] += GetValue(row.Substring(6));
                        break;
                    case "mul":
                        registers[row[4]] *= GetValue(row.Substring(6));
                        break;
                    case "jgz":
                        if (GetValue(row[4].ToString()) != 0)
                            i += GetValue(row.Substring(6)) - 1;
                        break;
                }
            }

            return lastPlayed;
        }

        static long GetValue(string input)
        {
            if (!long.TryParse(input, out long integer))
            {
                integer = registers[input[0]];
            }
            return integer;
        }

        static void InitializeRegisters()
        {
            foreach (var item in Enumerable.Range('a', 25))
            {
                registers.Add((char)item, 0);
            }
        }
    }
}
