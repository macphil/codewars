using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace codewars
{
    public class NextBiggerNumberKata
    {
        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1211111, ExpectedResult = 2111111)]
        public long NextBiggerNumber_Tests(long actual)
        {
            return NextBiggerNumber(actual);
        }

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
                    break;
                }
            }

            return Convert.ToInt64(string.Join(string.Empty, numbers));
        }
    }
}