using System;
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
        public void zebulans_nightmare_test()
        {
            Assert.AreEqual("camelCase", ZebulansNightmare("camel_case"));
            Assert.AreEqual("markAsIssue", ZebulansNightmare("mark_as_issue"));
            Assert.AreEqual("copyPastePep8", ZebulansNightmare("copy_paste_pep8"));
            Assert.AreEqual("gotoNextKata", ZebulansNightmare("goto_next_kata"));
            Assert.AreEqual("repeat", ZebulansNightmare("repeat"));
            Assert.AreEqual("trollingIsFun", ZebulansNightmare("trolling_is_fun"));
            Assert.AreEqual("why", ZebulansNightmare("why"));
            Assert.AreEqual("123AbcDef", ZebulansNightmare("123_abc_def"));
        }

        public string ZebulansNightmare(string functionName)
        {
            return functionName;
        }
    }
}