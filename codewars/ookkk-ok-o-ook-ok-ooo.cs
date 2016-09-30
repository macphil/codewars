using System;
using System.Text;
using NUnit.Framework;

namespace codewars
{
    public class ookkk_ok_o_ook_ok_ooo
    {
        [Test]
        [TestCase("Ok, Ook, Ooo!", ExpectedResult = 9)]   //  72
        [TestCase("Okk, Ook, Ok!", ExpectedResult = 9)]   // 101
        [TestCase("Okk, Okk, Oo!", ExpectedResult = 9)]   // 108
        [TestCase("Okk, Okkkk!", ExpectedResult = 9)]     // 111
        [TestCase("Ok, Ok, Okkk!", ExpectedResult = 9)]   //  87
        [TestCase("Okkk, Ook, O!", ExpectedResult = 9)]   // 114
        [TestCase("Okk, Ook, Oo!", ExpectedResult = 9)]   // 100
        public int ookkk_ok_o_ook_ok_ooo_Length(string actual) => actual.Replace(',', ' ').Replace(" ", string.Empty).Length;

        [Test]
        [TestCase("Ok, Ook, Ooo!", ExpectedResult = "H")]   //  72
        [TestCase("Okk, Ook, Ok!", ExpectedResult = "e")]   // 101
        [TestCase("Okk, Okk, Oo!", ExpectedResult = "l")]   // 108
        [TestCase("Okk, Okkkk!", ExpectedResult = "o")]     // 111
        [TestCase("Ok, Ok, Okkk!", ExpectedResult = "W")]   //  87
        [TestCase("Okkk, Ook, O!", ExpectedResult = "r")]   // 114
        [TestCase("Okk, Ook, Oo!", ExpectedResult = "d")]   // 100
        [TestCase("Ok, Ook, Ooo?  Okk, Ook, Ok?  Okk, Okk, Oo?  Okk, Okk, Oo?  Okk, Okkkk!", ExpectedResult = "Hello")]
        [TestCase("Ok, Ok, Okkk?  Okk, Okkkk?  Okkk, Ook, O?  Okk, Okk, Oo?  Okk, Ook, Oo?  Ook, Ooook!", ExpectedResult = "World!")]
        public string ookkk_ok_o_ook_ok_ooo_Tests(string actual) => okkOokOo(actual);

        public static string okkOokOo(string okkOookk)
        {
            var okAyByteString = new StringBuilder();
            var translated = new StringBuilder();
            foreach (var ko in okkOookk.ToUpperInvariant().ToCharArray())
            {
                switch (ko)
                {
                    case '!':
                    case '?':
                        translated.Append((char)Convert.ToSByte(okAyByteString.ToString(), 2));
                        okAyByteString.Clear();
                        break;

                    case 'O':
                        okAyByteString.Append('0');
                        break;

                    case 'K':
                        okAyByteString.Append('1');
                        break;

                    default:
                        break;
                }
            }

            return translated.ToString();
        }
    }
}