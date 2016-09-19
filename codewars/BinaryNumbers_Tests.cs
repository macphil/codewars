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
        public string BinaryNumbers_Tests_Tests(string a, string b)
        {
            return Add(a, b);
        }

        public static string Add(string a, string b)
        {
            return "";
        }
    }
}