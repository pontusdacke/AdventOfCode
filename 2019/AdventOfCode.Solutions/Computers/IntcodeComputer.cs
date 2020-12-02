using System.Collections.Generic;

namespace AdventOfCode.Solutions.Computers
{
    public class IntcodeComputer
    {
        private readonly IComputerInput computerInput;
        private readonly IComputerOutput computerOutput;

        public IntcodeComputer(IComputerInput computerInput, IComputerOutput computerOutput)
        {
            this.computerInput = computerInput;
            this.computerOutput = computerOutput;
        }

        public int GetProgramOutput(List<int> program)
        {
            for (int i = 0; i < program.Count; i++)
            {
                var op = program[i];
                var immediateInstructions = "00";

                var opString = op.ToString();
                if (opString.Length > 2)
                {
                    op = int.Parse(opString.Substring(opString.Length - 2));
                    immediateInstructions = opString.Substring(0, opString.Length - 2);
                }

                switch (op)
                {
                    case 1:
                        Add(program, i, immediateInstructions);
                        i += 3;
                        break;
                    case 2:
                        Multiply(program, i, immediateInstructions);
                        i += 3;
                        break;
                    case 3:
                        Read(program, i, immediateInstructions);
                        i++;
                        break;
                    case 4:
                        Write(program, i, immediateInstructions);
                        i++;
                        break;
                    case 5:
                        if (!JumpIfTrue(program, ref i, immediateInstructions))
                        {
                            i += 2;
                        }
                        break;
                    case 6:
                        if (!JumpIfFalse(program, ref i, immediateInstructions))
                        {
                            i += 2;
                        }
                        break;
                    case 7:
                        LessThan(program, i, immediateInstructions);
                        i += 3;
                        break;
                    case 8:
                        Equals(program, i, immediateInstructions);
                        i += 3;
                        break;
                    case 99:
                        return program[0];
                }
            }

            return program[0];
        }

        private bool JumpIfTrue(List<int> program, ref int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            if ((immediateInstructions[1] == '1' ? parameter1 : program[parameter1]) != 0)
            {
                current = immediateInstructions[0] == '1' ? parameter2 : program[parameter2];
                current--;
                return true;
            }
            return false;
        }

        private bool JumpIfFalse(List<int> program, ref int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            if ((immediateInstructions[1] == '1' ? parameter1 : program[parameter1]) == 0)
            {
                current = immediateInstructions[0] == '1' ? parameter2 : program[parameter2];
                current--;
                return true;
            }
            return false;
        }

        private void LessThan(List<int> program, int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];
            var writePosition = program[current + 3];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            var immediateParameter1 = immediateInstructions[1] == '1' ? parameter1 : program[parameter1];
            var immediateParameter2 = immediateInstructions[0] == '1' ? parameter2 : program[parameter2];

            program[writePosition] = immediateParameter1 < immediateParameter2 ? 1 : 0;
        }

        private void Equals(List<int> program, int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];
            var writePosition = program[current + 3];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            var immediateParameter1 = immediateInstructions[1] == '1' ? parameter1 : program[parameter1];
            var immediateParameter2 = immediateInstructions[0] == '1' ? parameter2 : program[parameter2];

            program[writePosition] = immediateParameter1 == immediateParameter2 ? 1 : 0;
        }

        private void Write(List<int> program, int i, string immediateInstructions)
        {
            var parameter = program[i + 1];
            var immediateParameter = immediateInstructions[0] == '1' ? parameter : program[parameter];
            computerOutput.Output(immediateParameter.ToString());
        }

        private void Read(List<int> program, int i, string immediateInstructions)
        {
            var parameter = program[i + 1];
            program[parameter] = int.Parse(computerInput.GetInput());
        }

        private void Add(List<int> program, int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];
            var output = program[current + 3];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            program[output] =
                (immediateInstructions[1] == '1' ? parameter1 : program[parameter1])
                +
                (immediateInstructions[0] == '1' ? parameter2 : program[parameter2]);
        }

        private void Multiply(List<int> program, int current, string immediateInstructions)
        {
            var parameter1 = program[current + 1];
            var parameter2 = program[current + 2];
            var output = program[current + 3];

            if (immediateInstructions.Length == 1)
            {
                immediateInstructions = "0" + immediateInstructions;
            }

            program[output] =
                (immediateInstructions[1] == '1' ? parameter1 : program[parameter1])
                *
                (immediateInstructions[0] == '1' ? parameter2 : program[parameter2]);
        }
    }
}
