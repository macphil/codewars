using NUnit.Framework;

namespace codewars.Descending_Order
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(1, 1)]
        [TestCase(12, 21)]
        [TestCase(42, 42)]
        [TestCase(123045, 543210)]
        public void Test0(int i, int expected)
        {
            Assert.AreEqual(expected, Kata.DescendingOrder(i));
        }
    }
}