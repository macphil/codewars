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
            var splittedString = new System.Collections.Generic.List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (i + 1 < str.Length)
                {
                    splittedString.Add(str.Substring(i++, 2));
                }
                else
                {
                    splittedString.Add(str.Substring(i, 1) + '_');
                }
            }
            return splittedString.ToArray();
        }
    }
}