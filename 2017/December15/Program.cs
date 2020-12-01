using System;
using System.Collections.Generic;
using System.Linq;

namespace December15
{
    class Program
    {
        static void Main(string[] args)
        {
            long startA = 783;
            long startB = 325;

            long factorA = 16807;
            long factorB = 48271;

            Console.WriteLine(JudgeSlamTheHammer(startA, startB, factorA, factorB));
            Console.WriteLine(LoopTroop(startA, startB, factorA, factorB));
        }

        private static int JudgeSlamTheHammer(long startA, long startB, long factorA, long factorB)
        {
            long previousA = startA;
            long previousB = startB;
            int count = 0;
            for (int i = 0; i < 40000000; i++)
            {
                if ((previousA & 0xffff) == (previousB & 0xffff)) count++;

                previousA = (previousA * factorA) % 2147483647L;
                previousB = (previousB * factorB) % 2147483647L;
            }

            return count;
        }

        private static int LoopTroop(long startA, long startB, long factorA, long factorB)
        {
            List<string> a = GetTheMoney(3, startA, factorA);
            List<string> b = GetTheMoney(7, startB, factorB);
            return a.Where((x, i) => x == b[i]).Count();
        }

        private static List<string> GetTheMoney(int m, long start, long factor)
        {
            List<string> money = new List<string>();
            long previous = start;
            for (int i = 0; money.Count < 5000000; i++)
            {
                if ((previous & m) == 0) money.Add(Convert.ToString(previous & 0xffff, 2).PadLeft(16, '0'));
                previous = (previous * factor) % int.MaxValue;
            }
            return money;
        }
    }
}
