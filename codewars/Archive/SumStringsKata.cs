using System;
using NUnit.Framework;

namespace codewars
{
    public class SumStringsKata
    {
        [Test]
        [TestCase("123", "456", ExpectedResult = "579")]
        [TestCase("123", "7", ExpectedResult = "130")]
        [TestCase("1", "2015", ExpectedResult = "2016")]
        [TestCase("788", "22", ExpectedResult = "810")]
        [TestCase("007", "000999", ExpectedResult = "1006")]
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

            var sumString = string.Empty;

            var uebertrag = 0;
            for (int i = maxDigits - 1; i >= 0; i--)
            {
                var ai = char.GetNumericValue(a[i]);
                var bi = char.GetNumericValue(b[i]);
                var charSum = ai + bi + uebertrag;
                uebertrag = 0;
                if (charSum >= 10)
                {
                    uebertrag = 1;
                    charSum -= 10;
                }
                sumString = $"{charSum}{sumString}";
            }
            sumString = $"{uebertrag}{sumString}";
            return sumString.TrimStart('0');
        }
    }
}