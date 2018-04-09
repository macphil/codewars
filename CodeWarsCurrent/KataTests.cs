using NUnit.Framework;
using System;
namespace codewars
{


    /*
     * https://www.codewars.com/kata/text-align-justify/train/csharp
     * 
     * Your task in this Kata is to emulate text justification in monospace font. 
     * You will be given a single-lined text and the expected justification width. 
     * The longest word will never be greater than this width.
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
        [TestCase("Hello World", 10, ExpectedResult = "Hello\nWorld", Ignore = "nji")]
        public string JustifyTests(string str, int len) => Kata.Justify(str, len);


        [Test]
        [TestCase("Hello World", 110, ExpectedResult = "Hello World")]
        [TestCase("Hello World", 11, ExpectedResult = "Hello World")]
        [TestCase("Hello World", 10, ExpectedResult = "Hello")]
        [TestCase("12345 6789 112 34 5", 100, ExpectedResult = "12345 6789 112 34 5")]
        [TestCase("12345 6789 112 34 5", 19, ExpectedResult = "12345 6789 112 34 5")]
        [TestCase("12345 6789 112 34 5", 18, ExpectedResult = "12345 6789 112 34")]
        [TestCase("12345 6789 112 34 5", 17, ExpectedResult = "12345 6789 112 34")]
        [TestCase("12345 6789 112 34 5", 16, ExpectedResult = "12345 6789 112")]
        [TestCase("12345 6789 112 34 5", 15, ExpectedResult = "12345 6789 112")]
        [TestCase("12345 6789 112 34 5", 14, ExpectedResult = "12345 6789 112")]
        [TestCase("12345 6789 112 34 5", 13, ExpectedResult = "12345 6789")]
        [TestCase("12345 6789 112 34 5", 12, ExpectedResult = "12345 6789")]
        [TestCase("12345 6789 112 34 5", 11, ExpectedResult = "12345 6789")]
        [TestCase("12345 6789 112 34 5", 10, ExpectedResult = "12345 6789")]
        [TestCase("12345 6789 112 34 5", 9, ExpectedResult = "12345")]
        [TestCase(LoremIpsum, 30, ExpectedResult = "Lorem ipsum dolor sit amet,")]
        public string GetWordsUpToWidthTests(string str, int len) => Kata.GetWordsUpToWidth(str, len);

        [Test, Ignore("nji")]
        public void MyTest()
        {
            Assert.AreEqual("123  45\n6", Kata.Justify("123 45 6", 7));
        }

        internal const string LoremIpsum_30 = "Lorem  ipsum  dolor  sit amet,\n" +
                                        "consectetur  adipiscing  elit.\n" +
                                        "Vestibulum    sagittis   dolor\n" +
                                        "mauris,  at  elementum  ligula\n" +
                                        "tempor  eget.  In quis rhoncus\n" +
                                        "nunc,  at  aliquet orci. Fusce\n" +
                                        "at   dolor   sit   amet  felis\n" +
                                        "suscipit   tristique.   Nam  a\n" +
                                        "imperdiet   tellus.  Nulla  eu\n" +
                                        "vestibulum    urna.    Vivamus\n" +
                                        "tincidunt  suscipit  enim, nec\n" +
                                        "ultrices   nisi  volutpat  ac.\n" +
                                        "Maecenas   sit   amet  lacinia\n" +
                                        "arcu,  non dictum justo. Donec\n" +
                                        "sed  quam  vel  risus faucibus\n" +
                                        "euismod.  Suspendisse  rhoncus\n" +
                                        "rhoncus  felis  at  fermentum.\n" +
                                        "Donec lorem magna, ultricies a\n" +
                                        "nunc    sit    amet,   blandit\n" +
                                        "fringilla  nunc. In vestibulum\n" +
                                        "velit    ac    felis   rhoncus\n" +
                                        "pellentesque. Mauris at tellus\n" +
                                        "enim.  Aliquam eleifend tempus\n" +
                                        "dapibus. Pellentesque commodo,\n" +
                                        "nisi    sit   amet   hendrerit\n" +
                                        "fringilla,   ante  odio  porta\n" +
                                        "lacus,   ut   elementum  justo\n" +
                                        "nulla et dolor.";

        internal const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                                        "Vestibulum sagittis dolor mauris, at elementum ligula" +
                                        "tempor eget. In quis rhoncus nunc, at aliquet orci. Fusce" +
                                        "at dolor sit amet felis suscipit tristique. Nam a" +
                                        "imperdiet tellus. Nulla eu vestibulum urna. Vivamus" +
                                        "tincidunt suscipit enim, nec ultrices nisi volutpat ac." +
                                        "Maecenas sit amet lacinia arcu, non dictum justo. Donec" +
                                        "sed quam vel risus faucibus euismod. Suspendisse rhoncus" +
                                        "rhoncus felis at fermentum. Donec lorem magna, ultricies a" +
                                        "nunc sit amet, blandit fringilla nunc. In vestibulum" +
                                        "velit ac felis rhoncus pellentesque. Mauris at tellus" +
                                        "enim. Aliquam eleifend tempus dapibus. Pellentesque commodo," +
                                        "nisi sit amet hendrerit fringilla, ante odio porta" +
                                        "lacus, ut elementum justo nulla et dolor.";
    }
}
