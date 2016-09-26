using NUnit.Framework;

namespace codewars.SmallestIntegerFinder
{
    public class SmallestIntegerFinderTests
    {
        [TestCase(new int[] { 78, 56, 232, 12, 11, 43 }, 11)]
        [TestCase(new int[] { 78, 56, -2, 12, 8, -33 }, -33)]
        public static void FixedTest(int[] args, int expected)
        {
            Assert.AreEqual(expected, SmallestIntegerFinderKata.FindSmallestInt(args));
        }
    }
}