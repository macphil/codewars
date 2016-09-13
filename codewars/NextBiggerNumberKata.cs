using System.Text.RegularExpressions;
using NUnit.Framework;

namespace codewars
{
    public class NextBiggerNumberKata
    {
        [Test]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        public long NextBiggerNumber_Tests(long actual)
        {
            return NextBiggerNumber(actual);
        }

        public static long NextBiggerNumber(long n)
        {
            return n;
        }
    }
}