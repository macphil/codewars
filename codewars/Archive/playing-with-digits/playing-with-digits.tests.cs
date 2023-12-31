﻿using System;
using NUnit.Framework;

namespace codewars.playing_with_digits
{
    public class playing_with_digits
    {
        [Test]
        [TestCase(10383, 6, ExpectedResult = 12933)]
        [TestCase(114, 3, ExpectedResult = 9)]
        [TestCase(1306, 1, ExpectedResult = 1)]
        [TestCase(132921, 3, ExpectedResult = 4)]
        [TestCase(135, 1, ExpectedResult = 1)]
        [TestCase(1377, 1, ExpectedResult = 2)]
        [TestCase(1385, 3, ExpectedResult = 35)]
        [TestCase(1676, 1, ExpectedResult = 1)]
        [TestCase(175, 1, ExpectedResult = 1)]
        [TestCase(1878, 2, ExpectedResult = 19)]
        [TestCase(198, 1, ExpectedResult = 3)]
        [TestCase(2427, 1, ExpectedResult = 1)]
        [TestCase(249, 1, ExpectedResult = 3)]
        [TestCase(261, 3, ExpectedResult = 5)]
        [TestCase(2646798, 1, ExpectedResult = 1)]
        [TestCase(2697, 3, ExpectedResult = 66)]
        [TestCase(46288, 3, ExpectedResult = 51)]
        [TestCase(46288, 5, ExpectedResult = -1)]
        [TestCase(47016, 2, ExpectedResult = 1)]
        [TestCase(518, 1, ExpectedResult = 1)]
        [TestCase(542186, 2, ExpectedResult = 1)]
        [TestCase(598, 1, ExpectedResult = 1)]
        [TestCase(6376, 3, ExpectedResult = 10)]
        [TestCase(63760, 3, ExpectedResult = 1)]
        [TestCase(63761, 3, ExpectedResult = 1)]
        [TestCase(6714, 3, ExpectedResult = 1)]
        [TestCase(695, 2, ExpectedResult = 2)]
        [TestCase(7388, 2, ExpectedResult = 5)]
        [TestCase(89, 1, ExpectedResult = 1)]
        [TestCase(92, 1, ExpectedResult = -1)]
        [TestCase(3456789, 1, ExpectedResult = -1)]
        [TestCase(3456789, 5, ExpectedResult = -1)]
        public int DigPow_Test(int n, int k)
        {
            return DigPow(n, k);
        }

        /// <summary>
        /// Digs the pow.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="p">The p.</param>
        /// <returns>Is there an integer k such as : (a ^ p + b ^ (p+1) + c ^(p+2) + d ^ (p+3) + ...) = a * k</returns>
        /// <autogeneratedoc />
        private static int DigPow(int a, int p)
        {
            if (a < 1 || p < 1)
            {
                return -1;
            }

            double sum = 0;
            foreach (char c in a.ToString())
            {
                sum += Math.Pow(char.GetNumericValue(c), p++);
            }

            return sum % a == 0 ? Convert.ToInt32(sum) / a : -1;
        }
    }
}