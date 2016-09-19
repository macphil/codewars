using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using NUnit.Framework;

namespace codewars
{
    public class NextBiggerNumberKata
    {
        //[Test]
        //[TestCase(1, ExpectedResult = -1)]
        //[TestCase(12, ExpectedResult = 21)]
        //[TestCase(513, ExpectedResult = 531)]
        //[TestCase(2017, ExpectedResult = 2071)]
        //[TestCase(414, ExpectedResult = 441)]
        //[TestCase(144, ExpectedResult = 414)]
        //[TestCase(1211111, ExpectedResult = 2111111)]
        //[TestCase(1234567890, ExpectedResult = 1234567908)]
        //[TestCase(890, ExpectedResult = 908)]
        //[TestCase(9, ExpectedResult = -1)]
        //[TestCase(531, ExpectedResult = -1)]
        //[TestCase(59884848459853, ExpectedResult = 59884848483559)]
        //[TestCase(59853, ExpectedResult = 83559)]
        //public long NextBiggerNumber_Tests(long actual)
        //{
        //    return NextBiggerNumber(actual);
        //}

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
            var numbers = n.ToString();
            for (int i = numbers.Length - 1; i > 0; i--)
            {
                var org = numbers.Substring(0, i - 1);
                var sort = SortNumbers(numbers.Substring(i - 1));
                long sn = Convert.ToInt64(org + sort);

                if (sn > n)
                {
                    return sn;
                }
            }
            return -1;
        }

        private static string SortNumbers(string v)
        {
            return string.Join(string.Empty, v.ToCharArray().OrderByDescending(x => x).ToArray());
        }

        [Test]
        [TestCase("24", ExpectedResult = "42")]
        public string SortNumbers_Test(string a)
        {
            return SortNumbers(a);
        }
    }
}