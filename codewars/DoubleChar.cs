using System;
using NUnit.Framework;

namespace codewars
{
    public class DoubleChar
    {
        [Test]
        [TestCase("abcd", ExpectedResult = "aabbccdd")]
        [TestCase("Adidas", ExpectedResult = "AAddiiddaass")]
        [TestCase("1337", ExpectedResult = "11333377")]
        [TestCase("illuminati", ExpectedResult = "iilllluummiinnaattii")]
        [TestCase("123456", ExpectedResult = "112233445566")]
        [TestCase("%^&*(", ExpectedResult = "%%^^&&**((")]
        public static string FixedTest(string s)
        {
            return Kata.DoubleChar(s);
        }
    }

    internal class Kata
    {
        internal static string DoubleChar(string s)
        {
            var builder = new System.Text.StringBuilder();
            foreach (char c in s.ToCharArray())
            {
                builder.Append(new string(c, 2));
            }
            return builder.ToString();
        }
    }
}