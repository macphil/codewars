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

        private static int CountBits(int n)
        {
            if (n > byte.MaxValue || n < byte.MinValue)
            {
                return -1;
            }
            return Convert.ToString(Convert.ToByte(n), 2).Replace("0", string.Empty).Length;
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
    }
}