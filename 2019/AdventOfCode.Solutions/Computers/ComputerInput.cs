namespace AdventOfCode.Solutions.Computers
{
    public class ComputerInput : IComputerInput
    {
        private readonly string input;

        public ComputerInput(string input)
        {
            this.input = input;
        }

        public string GetInput()
        {
            return input;
        }
    }
}
