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
        [TestCase("P", ExpectedResult = "Pay")]
        public string PigIt_Test(string actual)
        {
            return PigIt(actual);
        }

        public static string PigIt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }
            var pigIt = new System.Text.StringBuilder();
            foreach (string word in str.Split(' '))
            {
                pigIt.Append(string.Concat(word.Substring(1), word.Substring(0, 1), "ay "));
            }
            return pigIt.ToString().TrimEnd();
        }
    }
}