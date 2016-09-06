using System;
using NUnit.Framework;

namespace codewars.playing_with_digits
{
    public class playing_with_digits
    {
        [Test]
        [TestCase(89, 1, ExpectedResult = 1)]
        [TestCase(92, 1, ExpectedResult = -1)]
        [TestCase(695, 2, ExpectedResult = 2)]
        [TestCase(46288, 3, ExpectedResult = 51)]
        public int DigPow_Test(int n, int k)
        {
            return DigPow(n, k);
        }

        private static int DigPow(int n, int k)
        {
            return k;
        }
    }
}