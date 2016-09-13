using NUnit.Framework;

namespace codewars
{
    public class SplitString
    {
        [Test]
        [TestCase("abc", ExpectedResult = new string[] { "ab", "c_" })]
        [TestCase("abcdef", ExpectedResult = new string[] { "ab", "cd", "ef" })]
        public string[] SplitString_Test(string actual)
        {
            return Solution(actual);
        }

        public static string[] Solution(string str)
        {
            return null;
        }
    }
}