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

        [Test]
        [TestCase("123", "456", ExpectedResult = "579")]
        [TestCase("123", "7", ExpectedResult = "130")]
        [TestCase("1", "2015", ExpectedResult = "2016")]
        [TestCase("788", "22", ExpectedResult = "810")]
        [TestCase("", "5", ExpectedResult = "5")]
        [TestCase("712569312664357328695151392", "8100824045303269669937", ExpectedResult = "712577413488402631964821329")]
        [TestCase("50095301248058391139327916261", "81055900096023504197206408605", ExpectedResult = "131151201344081895336534324866")]
        public string SumStrings_Test(string a, string b)
        {
            return SumStrings(a, b);
        }

        private string SumStrings(string a, string b)
        {
            var maxDigits = Math.Max(a.Length, b.Length);
            a = a.PadLeft(maxDigits, '0');
            b = b.PadLeft(maxDigits, '0');

            var res = string.Empty;

            var uebertrag = 0;
            for (int i = maxDigits - 1; i >= 0; i--)
            {
                var ai = char.GetNumericValue(a[i]);
                var bi = char.GetNumericValue(b[i]);
                var ci = ai + bi + uebertrag;

                if (ci >= 10)
                {
                    uebertrag = 1;
                    ci -= 10;
                }
                else
                {
                    uebertrag = 0;
                }

                res = $"{ci}{res}";
            }
            if (uebertrag == 1)
            {
                res = $"1{res}";
            }
            return res.TrimStart('0');
        }
    }
}