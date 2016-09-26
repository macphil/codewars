using System;
using NUnit.Framework;

namespace codewars
{
    public class ValidBraces
    {
        [Test]
        [TestCase("(){}[]", ExpectedResult = true)]
        [TestCase("(}", ExpectedResult = false)]
        [TestCase("[(])", ExpectedResult = false)]
        [TestCase("([{}])", ExpectedResult = true)]
        public bool ValidBraces_Tests(string actual)
        {
            return Brace.validBraces(actual);
        }
    }

    internal class Brace
    {
        internal static bool validBraces(string braces)
        {
            return false;
        }
    }
}