using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December09
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt")[0];

            Console.WriteLine(Do(input));
            Console.WriteLine(HowMuchGargabe(input));
        }

        [TestCase("{}", ExpectedResult = 1)]
        [TestCase("{{{}}}", ExpectedResult = 6)]
        [TestCase("{{},{}}", ExpectedResult = 5)]
        [TestCase("{{{},{},{{}}}}", ExpectedResult = 16)]
        [TestCase("{<{},{},{{}}>}", ExpectedResult = 1)]
        [TestCase("{<a>,<a>,<a>,<a>}", ExpectedResult = 1)]
        [TestCase("{{<ab>},{<ab>},{<ab>},{<ab>}}", ExpectedResult = 9)]
        [TestCase("{{<!!>},{<!!>},{<!!>},{<!!>}}", ExpectedResult = 9)]
        [TestCase("{{<a!>},{<a!>},{<a!>},{<ab>}}", ExpectedResult = 3)]
        public static int Do(string input)
        {
            int score = 0;
            int openBr = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '!')
                {
                    i++;
                    continue;
                }
                if (input[i] == '<')
                {
                    int j;
                    for (j = i; j < input.Length; j++)
                    {
                        if (input[j] == '!')
                        {
                            j++;
                            continue;
                        }
                        if (input[j] == '>')
                        {
                            break;
                        }
                    }
                    i += j - i;
                    continue;
                }
                if (input[i] == '{')
                {
                    openBr++;
                }

                if (input[i] == '}')
                {
                    score += openBr;
                    openBr--;
                }
            }

            return score;
        }
        [TestCase("<>", ExpectedResult = 0)]
        [TestCase("<random characters>", ExpectedResult = 17)]
        [TestCase("<<<<>", ExpectedResult = 3)]
        [TestCase("<{!>}>", ExpectedResult = 2)]
        [TestCase("<!!>", ExpectedResult = 0)]
        [TestCase("<!!!>>", ExpectedResult = 0)]
        [TestCase("<{o\"i!a,<{i<a>", ExpectedResult = 10)]
        public static int HowMuchGargabe(string input)
        {
            int score = 0;
            int openBr = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '!')
                {
                    i++;
                    continue;
                }
                if (input[i] == '<')
                {
                    int j;
                    for (j = i+1; j < input.Length; j++)
                    {
                        if (input[j] == '!')
                        {
                            j++;
                            continue;
                        }
                        else if (input[j] == '>')
                        {
                            break;
                        }
                        else
                        {
                            score++;
                        }
                    }
                    i += j - i;
                    continue;
                }
                if (input[i] == '{')
                {
                    openBr++;
                }

                if (input[i] == '}')
                {
                    openBr--;
                }
            }

            return score;
        }
    }
}
