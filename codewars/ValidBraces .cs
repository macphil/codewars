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

    /*
     * All input strings will be nonempty, and will only consist of
     * open parentheses '(' ,
     * closed parentheses ')',
     * open brackets '[',
     * closed brackets ']',
     * open curly braces '{' and
     * closed curly braces '}'.
     * */

    internal class Brace
    {
        internal static bool validBraces(string braces)
        {
            var openParentheses = 0;
            var openBrackets = 0;
            var openCurlyBraces = 0;

            foreach (char c in braces.ToCharArray())
            {
                switch (c)
                {
                    case '[':
                        openBrackets++;
                        break;

                    case ']':
                        openBrackets--;
                        break;

                    case '{':
                        openCurlyBraces++;
                        break;

                    case '}':
                        openBrackets--;
                        break;

                    case '(':
                        openParentheses++;
                        break;

                    case ')':
                        openParentheses--;
                        break;
                }
            }

            return openCurlyBraces == 0 && openBrackets == 0 && openParentheses == 0;
        }
    }
}