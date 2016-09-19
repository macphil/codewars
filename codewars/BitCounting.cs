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
        [TestCase(254, ExpectedResult = 7)]
        [TestCase(255, ExpectedResult = 8)]
        [TestCase(256, ExpectedResult = 1)]
        [TestCase(257, ExpectedResult = 2)]
        [TestCase(77231418, ExpectedResult = 14)]
        public int CountBits_Tests(int actual)
        {
            return CountBits(actual);
        }

        private static int CountBits(int n)
        {
            var count = 0;
            double val = n;
            while (val > 0)
            {
                val -= Math.Pow(2, Convert.ToInt32(Math.Floor(Math.Log(val, 2))));
                count++;
            }
            return count;
        }

        [TestCase(0, ExpectedResult = "0")]
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(2, ExpectedResult = "10")]
        [TestCase(7, ExpectedResult = "111")]
        public string IntToBitstring(int n)
        {
            byte result;
            if (Byte.TryParse(Convert.ToString(n), out result))
            {
                return Convert.ToString(result, 2);
            }
            return "";
        }

        [TestCase(2, ExpectedResult = 1)]
        [TestCase(4, ExpectedResult = 2)]
        [TestCase(8, ExpectedResult = 3)]
        [TestCase(256, ExpectedResult = 8)]
        public int blubb(int x)
        {
            return Convert.ToInt32(Math.Floor(Math.Log(x, 2)));
        }
    }
}