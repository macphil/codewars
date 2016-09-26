using NUnit.Framework;

namespace codewars.Descending_Order
{
    [TestFixture]
    public class DescendingOrderTests
    {
        [Test]
        [TestCase(-1, -1)]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(9, 9)]
        [TestCase(10, 10)]
        [TestCase(12, 21)]
        [TestCase(42, 42)]
        [TestCase(123045, 543210)]
        public void DescendingOrderTest(int i, int expected)
        {
            Assert.AreEqual(expected, DescendingOrderKata.DescendingOrder(i));
        }
    }
}