using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    public class NextBiggerNumberKata
    {
        [Test]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1211111, ExpectedResult = 2111111)]
        [TestCase(1234567890, ExpectedResult = 1234567908)]
        [TestCase(890, ExpectedResult = 908)]
        [TestCase(9, ExpectedResult = -1)]
        [TestCase(531, ExpectedResult = -1)]
        [TestCase(59884848459853, ExpectedResult = 59884848483559)]
        public long NextBiggerNumber_Tests(long actual)
        {
            return NextBiggerNumber(actual);
        }

        /*
         *      7 - 8 - 9 - 0
         * =>   7 - 9 - 0 - 8
         * ???????????????????????
         *
         *  0>9N0>8N0>7N9>8J-- 7980 --> 8>0J-- 7908
         *
         */

        public static long NextBiggerNumber(long n)
        {
            var numbers = n.ToString().ToCharArray();
            for (int i = numbers.Length - 1; i > 0; i--)
            {
                if (Char.GetNumericValue(numbers[i]) > Char.GetNumericValue(numbers[i - 1]))
                {
                    var charToSwap = numbers[i];
                    numbers[i] = numbers[i - 1];
                    numbers[i - 1] = charToSwap;

                    var ts = new List<char>();
                    for (int j = i; j < numbers.Length; j++)
                    {
                        ts.Add(numbers[j]);
                    }

                    return Convert.ToInt64(string.Join(string.Empty, numbers).Substring(0, i) + string.Join(string.Empty, ts.OrderBy(x => x)));
                }
            }
            return -1;
        }
    }
}