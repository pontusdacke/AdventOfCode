using AdventOfCode.Solutions.Computers;

namespace AdventOfCode.Solutions.Tests
{
    class FakeOutput : IComputerOutput
    {
        public string StoredOutput { get; set; }

        public void Output(string toOutput)
        {
            StoredOutput = toOutput;
        }
    }
}
