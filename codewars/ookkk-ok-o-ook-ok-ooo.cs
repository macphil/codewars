using NUnit.Framework;

namespace codewars
{
    public class ookkk_ok_o_ook_ok_ooo
    {
        [Test]
        [TestCase("Ok, Ook, Ooo!", ExpectedResult = "H")]
        [TestCase("Okk, Ook, Ok!", ExpectedResult = "e")]
        [TestCase("Okk, Okk, Oo!", ExpectedResult = "l")]
        [TestCase("Okk, Okkkk!", ExpectedResult = "o")]
        [TestCase("Ok, Ok, Okkk!", ExpectedResult = "W")]
        [TestCase("Okkk, Ook, O!", ExpectedResult = "r")]
        [TestCase("Okk, Ook, Oo!", ExpectedResult = "d")]
        [TestCase("Ok, Ook, Ooo?  Okk, Ook, Ok?  Okk, Okk, Oo?  Okk, Okk, Oo?  Okk, Okkkk!", ExpectedResult = "Hello")]
        [TestCase("Ok, Ok, Okkk?  Okk, Okkkk?  Okkk, Ook, O?  Okk, Okk, Oo?  Okk, Ook, Oo?  Ook, Ooook!",
            ExpectedResult = "World!")]
        public string ookkk_ok_o_ook_ok_ooo_Tests(string actual) => okkOokOo(actual);

        public static string okkOokOo(string okkOookk)
        {
            return string.Empty;
        }
    }
}