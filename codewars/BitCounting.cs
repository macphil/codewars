using System;
using NUnit.Framework;

namespace codewars
{
    public class BitCounting
    {
        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(4, ExpectedResult = 1)]
        [TestCase(7, ExpectedResult = 3)]
        [TestCase(9, ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 2)]
        public int CountBits_Tests(int actual)
        {
            return CountBits(actual);
        }

        private static int CountBits(int actual)
        {
            return -1;
        }
    }
}