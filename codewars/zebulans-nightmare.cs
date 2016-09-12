using System;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    /* https://www.codewars.com/kata/zebulans-nightmare/train/csharp
     * Zebulan has worked hard to write all his python code in strict compliance to PEP8 rules.
     * In this kata, you are a mischevious hacker that has set out to sabatoge all his good code.
     * Your job is to take PEP8 compatible function names and convert them to camelCase.
     * */

    public class zebulans_nightmare
    {
        [Test]
        [TestCase("camel_case", ExpectedResult = "camelCase")]
        [TestCase("mark_as_issue", ExpectedResult = "markAsIssue")]
        [TestCase("copy_paste_pep8", ExpectedResult = "copyPastePep8")]
        [TestCase("goto_next_kata", ExpectedResult = "gotoNextKata")]
        [TestCase("repeat", ExpectedResult = "repeat")]
        [TestCase("trolling_is_fun", ExpectedResult = "trollingIsFun")]
        [TestCase("why", ExpectedResult = "why")]
        [TestCase("123_abc_def", ExpectedResult = "123AbcDef")]
        public string zebulans_nightmare_test(string functionName)
        {
            return ZebulansNightmare(functionName);
        }

        public string ZebulansNightmare(string functionName)
        {
            var cfn = string.Empty;
            var builder = new System.Text.StringBuilder();
            builder.Append(cfn);
            foreach (string s in functionName.Split('_'))
            {
                if (builder.Length == 0)
                {
                    builder.Append(s.ToLowerInvariant());
                }
                else
                {
                    builder.Append(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s));
                }
            }

            return builder.ToString();
        }
    }
}