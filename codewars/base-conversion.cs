using System;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    public class base_conversion
    {
        [Test]
        public void FirstTest()
        {
            string res = Convert("0", Alphabet.DECIMAL, Alphabet.ALPHA);
            Assert.That(res, Is.EqualTo("a"));
        }

        // convert between numeral systems
        [TestCase("15", Alphabet.DECIMAL, Alphabet.BINARY, ExpectedResult = "1111")]
        [TestCase("15", Alphabet.DECIMAL, Alphabet.OCTAL, ExpectedResult = "17")]
        [TestCase("1010", Alphabet.BINARY, Alphabet.DECIMAL, ExpectedResult = "10")]
        [TestCase("1010", Alphabet.BINARY, Alphabet.HEXA_DECIMAL, ExpectedResult = "a")]

        // other bases
        [TestCase("0", Alphabet.DECIMAL, Alphabet.ALPHA, ExpectedResult = "a")]
        [TestCase("27", Alphabet.DECIMAL, Alphabet.ALPHA_LOWER, ExpectedResult = "bb")]
        [TestCase("hello", Alphabet.ALPHA_LOWER, Alphabet.HEXA_DECIMAL, ExpectedResult = "320048")]
        [TestCase("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_UPPER, ExpectedResult = "SAME")]
        [TestCase("SAME", Alphabet.ALPHA_UPPER, Alphabet.ALPHA_LOWER, ExpectedResult = "same")]
        public string Convert_Tests(string actual, String from, String to) => Convert(actual, @from, to);

        private static string Convert(string actual, string from, string to)
        {
            var converted = string.Empty;

            if (from.Length == to.Length)
            {
                foreach (var actualChar in actual.ToCharArray())
                {
                    converted += to[from.IndexOf(actualChar)];
                }
                return converted;
            }

            var fromBase = from.Length;
            var toBase = to.Length;
            var fromDec = 0d;
            var pow = 0;
            foreach (var actualChar in actual.ToCharArray().Reverse())
            {
                fromDec += (double)from.IndexOf(actualChar) * Math.Pow(fromBase, pow++);
            }

            var maxPotenz = blubb(fromDec, toBase);

            for (int i = maxPotenz; i >= 0; i--)
            {
                var maxPowVal = Math.Pow(toBase, i);
                int x = (int)Math.Floor(fromDec / maxPowVal);

                converted += $"{to[x]}";
                fromDec -= x * maxPowVal;
            }

            return converted;
        }

        public static int blubb(double n, int nBase) => System.Convert.ToInt32(Math.Floor(Math.Log(n, nBase)));
    }

    public class Alphabet
    {
        public const string BINARY = "01";
        public const string OCTAL = "01234567";
        public const string DECIMAL = "0123456789";
        public const string HEXA_DECIMAL = "0123456789abcdef";
        public const string ALPHA_LOWER = "abcdefghijklmnopqrstuvwxyz";
        public const string ALPHA_UPPER = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string ALPHA_NUMERIC = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}