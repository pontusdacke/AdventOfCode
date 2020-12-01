using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December05
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(x => Convert.ToInt32(x)).ToArray();

            Console.WriteLine(Do(input));
        }

        private static int Do(int[] input)
        {
            int counter = 0;
            for (int i = 0; i < input.Length;)
            {
                int oldi = i;
                int offset = input[i];
                i += offset;
                counter++;

                if (i >= input.Length || i < 0)
                {
                    return counter;
                }

                if (offset >= 3)
                {
                    input[oldi] -= 1;
                }
                else
                {
                input[oldi]++;

                }

            }

            return 1337;
        }
    }
}
