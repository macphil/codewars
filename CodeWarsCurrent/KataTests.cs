using NUnit.Framework;
using System;
namespace codewars
{


    /*
     * https://www.codewars.com/kata/text-align-justify/train/csharp
     * 
     * Your task in this Kata is to emulate text justification in monospace font. You will be given a single-lined text and the expected justification width. The longest word will never be greater than this width.
     *
     *  Here are the rules:
     *
     *  - Use spaces to fill in the gaps between words.
     *  - Each line should contain as many words as possible.
     *  - Use '\n' to separate lines.
     *  - Gap between words can't differ by more than one space.
     *  - Lines should end with a word not a space.
     *  - '\n' is not included in the length of a line.
     *  - Large gaps go first, then smaller ones: 'Lorem---ipsum---dolor--sit--amet' (3, 3, 2, 2 spaces).
     *  - Last line should not be justified, use only one space between words.
     *  - Last line should not contain '\n'
     *  - Strings with one word do not need gaps ('somelongword\n').
     */

    [TestFixture()]
    public class KataTests
    {
        [Test]
        [TestCase("Hello World", 11, ExpectedResult = "Hello World")]
        public string JustifyTests(string str, int len) => Kata.Justify(str, len);

        [Test]
        public void MyTest()
        {
            Assert.AreEqual("123  45\n6", Kata.Justify("123 45 6", 7));
        }
    }
}
