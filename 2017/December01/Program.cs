using System;
using System.Linq;

namespace December01
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "".Select(x => x - '0').ToArray();

            Console.WriteLine($"Answer 1: {GenerateInhumanCaptchaResponse(input, 1)}");
            Console.WriteLine($"Answer 2: {GenerateInhumanCaptchaResponse(input, input.Length / 2)}");
        }

        private static int GenerateInhumanCaptchaResponse(int[] input, int compareStepLength)
        {
            return input
                .Where((num, i) => input[(i + compareStepLength) % input.Length] == num)
                .Sum();
        }
    }
}
