using System;
using NUnit.Framework;

namespace codewars
{
    public class BinaryNumbers_Tests
    {
        [Test]
        [TestCase("111", "10", ExpectedResult = "1001")]
        [TestCase("1101", "101", ExpectedResult = "10010")]
        [TestCase("1101", "10111", ExpectedResult = "100100")]
        [TestCase("00011", "00", ExpectedResult = "11")]
        [TestCase("00", "11", ExpectedResult = "11")]
        [TestCase("00", "0", ExpectedResult = "0")]
        public string BinaryNumbers_Tests_Tests(string a, string b)
        {
            return Add(a, b);
        }

        public static string Add(string a, string b)
        {
            var maxDigits = Math.Max(a.Length, b.Length);
            a = a.PadLeft(maxDigits, '0');
            b = b.PadLeft(maxDigits, '0');

            var sumString = string.Empty;

            var uebertrag = 0;
            for (int i = maxDigits - 1; i >= 0; i--)
            {
                var ai = char.GetNumericValue(a[i]);
                var bi = char.GetNumericValue(b[i]);
                var charSum = ai + bi + uebertrag;
                uebertrag = 0;
                if (charSum >= 2)
                {
                    uebertrag = 1;
                    charSum -= 2;
                }
                sumString = $"{charSum}{sumString}";
            }
            sumString = $"{uebertrag}{sumString}".TrimStart('0');
            return sumString.Length == 0 ? "0" : sumString;
        }
    }
}