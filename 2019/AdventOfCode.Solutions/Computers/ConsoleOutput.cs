using System;

namespace AdventOfCode.Solutions.Computers
{
    class ConsoleOutput : IComputerOutput
    {
        public void Output(string toOutput)
        {
            Console.WriteLine(toOutput);
        }
    }
}
