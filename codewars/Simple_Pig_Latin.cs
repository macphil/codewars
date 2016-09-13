using NUnit.Framework;

namespace codewars
{
    /*
     *
     * Move the first letter of each word to the end of it, then add 'ay' to the end of the word.
     *
     * */

    public class Simple_Pig_Latin
    {
        [Test]
        [TestCase("Pig latin is cool", ExpectedResult = "igPay atinlay siay oolcay")]
        [TestCase("This is my string", ExpectedResult = "hisTay siay ymay tringsay")]
        public string PigIt_Test(string actual)
        {
            return PigIt(actual);
        }

        public static string PigIt(string str)
        {
            return str;
        }
    }
}