using System;
using AdventOfCode.Solutions.Days;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Solutions.Tests
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public void HasAtLeastOnePair()
        {
            var sut = new Day04();

            Assert.IsTrue(sut.HasAtLeastOnePair(112233));
            Assert.IsTrue(sut.HasAtLeastOnePair(111122));
            Assert.IsFalse(sut.HasAtLeastOnePair(123444));
        }
    }
}
