using AdventOfCode.Solutions.Computers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AdventOfCode.Solutions.Tests
{
    [TestClass]
    public class IntcodeComputerTests
    {
        [TestMethod]
        public void GetProgramOutput_outputsInputWithProgram()
        {
            const string value = "1337";
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput(value), output);
            var program = new List<int> { 3, 0, 4, 0, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual(value, output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_HandlesImmediateMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("0"), output);
            var program = new List<int> { 1002, 4, 3, 4, 33 };

            sut.GetProgramOutput(program);

            Assert.AreEqual(99, program[4]);
        }

        [TestMethod]
        public void GetProgramOutput_HandlesNegativeNumbers()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("0"), output);
            var program = new List<int> { 1101, 100, -1, 4, 0 };

            sut.GetProgramOutput(program);

            Assert.AreEqual(99, program[4]);
        }

        [TestMethod]
        public void GetProgramOutput_8EqualsTo8_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("8"), output);
            var program = new List<int> { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_8DoesNotEqualTo6_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("6"), output);
            var program = new List<int> { 3, 9, 8, 9, 10, 9, 4, 9, 99, -1, 8 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("0", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_5IsLessThan8_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("5"), output);
            var program = new List<int> { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_10IsNotLessThan8_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("10"), output);
            var program = new List<int> { 3, 9, 7, 9, 10, 9, 4, 9, 99, -1, 8 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("0", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_8EqualsTo8_ImmediateMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("8"), output);
            var program = new List<int> { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_8DoesNotEqualsTo3_ImmediateMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("3"), output);
            var program = new List<int> { 3, 3, 1108, -1, 8, 3, 4, 3, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("0", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_5IsLessThan8_ImmediateMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("5"), output);
            var program = new List<int> { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_11IsNotLessThan8_ImmediateMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("11"), output);
            var program = new List<int> { 3, 3, 1107, -1, 8, 3, 4, 3, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("0", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_JumpShouldReturnZeroWhenInputIsZero_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("0"), output);
            var program = new List<int> { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("0", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_JumpShouldReturn1WhenInputIsNonZero_PositionMode()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("32"), output);
            var program = new List<int> { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_Outputs999AsInputIsBelow8()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("5"), output);
            var program = new List<int> { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("999", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_Outputs1000AsInputIsEqualTo8()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("8"), output);
            var program = new List<int> { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1000", output.StoredOutput);
        }

        [TestMethod]
        public void GetProgramOutput_Outputs1001AsInputIsGreaterThan8()
        {
            var output = new FakeOutput();
            var sut = new IntcodeComputer(new ComputerInput("500"), output);
            var program = new List<int> { 3, 21, 1008, 21, 8, 20, 1005, 20, 22, 107, 8, 21, 20, 1006, 20, 31, 1106, 0, 36, 98, 0, 0, 1002, 21, 125, 20, 4, 20, 1105, 1, 46, 104, 999, 1105, 1, 46, 1101, 1000, 1, 20, 4, 20, 1105, 1, 46, 98, 99 };

            sut.GetProgramOutput(program);

            Assert.AreEqual("1001", output.StoredOutput);
        }
    }
}
