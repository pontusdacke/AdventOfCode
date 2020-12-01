using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace December23
{
    class Program
    {
        static Dictionary<char, int> registers = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            InitializeRegisters();
            Console.WriteLine(CountMulInstructions(input));

            InitializeRegistersAgain();
            Console.WriteLine(registers['h']);
        }

        static int CountMulInstructions(string[] input)
        {
            int mulCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var row = input[i];
                var instruction = input[i].Substring(0, 3);

                switch (instruction)
                {
                    case "set":
                        registers[row[4]] = GetValue(row.Substring(6));
                        break;
                    case "sub":
                        registers[row[4]] -= GetValue(row.Substring(6));
                        break;
                    case "mul":
                        registers[row[4]] *= GetValue(row.Substring(6));
                        mulCount++;
                        break;
                    case "jnz":
                        if (GetValue(row[4].ToString()) != 0)
                            i += GetValue(row.Substring(6)) - 1;
                        break;
                }
            }

            return mulCount;
        }

        static int GetValue(string input)
        {
            if (!int.TryParse(input, out int integer))
            {
                integer = registers[input[0]];
            }
            return integer;
        }

        static void InitializeRegisters()
        {
            foreach (var item in Enumerable.Range('a', 8))
            {
                registers.Add((char)item, 0);
            }
        }

        static void InitializeRegistersAgain()
        {
            foreach (var key in registers.Keys.ToList())
            {
                registers[key] = 0;
            }

            registers['a']++;
        }
    }
}
