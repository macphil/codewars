using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestCase("}])", ExpectedResult = false)]
        [TestCase("(})", ExpectedResult = false)]
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
            Console.WriteLine();
            var bracesDic = new Dictionary<char, char>();
            bracesDic.Add(')', '(');
            bracesDic.Add(']', '[');
            bracesDic.Add('}', '{');

            var openedBraces = new List<char>();

            foreach (char c in braces.ToCharArray())
            {
                if (bracesDic.ContainsValue(c))
                {
                    openedBraces.Add(c);
                }
                else if (bracesDic.ContainsKey(c) && openedBraces.Count > 0 && openedBraces.Last().Equals(bracesDic[c]))
                {
                    openedBraces.RemoveAt(openedBraces.LastIndexOf(bracesDic[c]));
                }
                else
                {
                    return false;
                }
            }

            return openedBraces.Count == 0;
        }
    }
}