using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December04
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");

            Console.WriteLine(Do(input));
            Console.WriteLine(Do2(input));
        }

        private static int Do2(string[] input)
        {
            int sum = 0;
            for (int k = 0; k < input.Length; k++)
            {
                var phrases = input[k].Split(' ');
                int temp = 0;
                for (int i = 0; i < phrases.Length; i++)
                {
                    for (int j = 0; j < phrases.Length; j++)
                    {
                        if (phrases[i] == phrases[j] && i != j)
                        {
                            temp++;
                        }
                        else if (phrases[i].Length == phrases[j].Length && i != j)
                        {
                            var phraseA = string.Concat(phrases[i].OrderBy(x => x));
                            var phraseB = string.Concat(phrases[j].OrderBy(x => x));

                            if (phraseA == phraseB)
                            {
                                temp++;
                            }
                        }
                    }
                }
                if (temp < 2)
                {
                    sum++;
                }
            }

            return sum;
        }

        private static int Do(string[] input)
        {
            int sum = 0;
            for (int k = 0; k < input.Length; k++)
            {
                var phrases = input[k].Split(' ');
                int temp = 0;
                for (int i = 0; i < phrases.Length; i++)
                {
                    for (int j = 0; j < phrases.Length; j++)
                    {
                        if (phrases[i] == phrases[j] && i != j)
                        {
                            temp++;
                        }
                    }
                }
                if (temp < 2)
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
