using NUnit.Framework;

namespace Yuc.Algorithm.Tests
{
    public class StringComputerTests
    {
        [TestCase("1 1 +", 2)]
        [TestCase("1 1 1 - +", 1)]
        [TestCase("1 1 1 10 * + -", 10)]
        [TestCase("1 1 1 10 2 / * - +", 5)]
        [TestCase("1 5 9 9 + - +", 6)]
        [TestCase("0 1 0 9 5 + + / *", 14)]
        [TestCase("5 2 0 8 3 2 / * - + *", 3)]
        [TestCase("15 20 13 -1 -1 1 / * - + +", -49)]
        [TestCase("30 -2 /", -15)]
        public void Should_Compute_Result(string value, int expected)
        {
            var result = StringComputer.Compute(value);
            Assert.AreEqual(expected, result);
        }
    }
}