using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace December22
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var startInfected = StartInfectedCount(input);
        }

        static int StartInfectedCount(string[] input)
        {
            return input.Sum(x => x.Count(y => y == '#'));
        }
    }
}
