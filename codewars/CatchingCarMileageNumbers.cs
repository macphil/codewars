using NUnit.Framework;

namespace codewars
{
    public class CatchingCarMileageNumbers
    {
        [Test]
        [TestCase("", "")]
        public void CatchingCarMileageNumbers_AreEqual(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("", ExpectedResult = "")]
        public string CatchingCarMileageNumbers_Tests(string actual)
        {
            return actual;
        }
    }
}