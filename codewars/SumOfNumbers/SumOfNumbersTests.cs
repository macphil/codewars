using NUnit.Framework;

namespace codewars.SumOfNumbers
{
    public class SumOfNumbersTests
    {
        [Test]
        [TestCase(1, 0, 1)]   // 1 + 0 = 1
        [TestCase(1, 2, 3)]   // 1 + 2 = 3
        [TestCase(0, 1, 1)]   // 0 + 1 = 1
        [TestCase(1, 1, 1)]   // 1 Since both are same
        [TestCase(-1, 0, -1)] // -1 + 0 = -1
        [TestCase(-1, 2, 2)]  // -1 + 0 + 1 + 2 = 2
        public void SumOfNumbersTest_AreEqual(int i, int j, int expected)
        {
            Assert.AreEqual(expected, SumOfNumbersKata.GetSum(i, j));
        }
    }
}