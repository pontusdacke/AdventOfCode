using System;
using System.Linq;

namespace Santa_Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            // Part 1 in one line
            int floor = input.Count(x => x == '(') - input.Count(x => x == ')');
            Console.WriteLine("Floor: {0}", floor);

            // Part 2
            int currentFloor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') currentFloor++;
                else if (input[i] == ')') currentFloor--;
                if (currentFloor == -1)
                {
                    Console.WriteLine(i + 1);
                    break;
                }
            }
        }
    }
}
