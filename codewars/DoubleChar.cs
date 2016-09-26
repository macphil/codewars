using System.Linq;
using System.Text;
using NUnit.Framework;

namespace codewars
{
    public class DoubleChar
    {
        [Test]
        [TestCase("abcd", ExpectedResult = "aabbccdd")]
        [TestCase("Adidas", ExpectedResult = "AAddiiddaass")]
        [TestCase("1337", ExpectedResult = "11333377")]
        [TestCase("illuminati", ExpectedResult = "iilllluummiinnaattii")]
        [TestCase("123456", ExpectedResult = "112233445566")]
        [TestCase("%^&*(", ExpectedResult = "%%^^&&**((")]
        public static string FixedTest(string s)
        {
            //var n = 1000;

            //var sw = new Stopwatch();
            //sw.Start();

            //Kata.DoubleChar(new string('x', n));

            //sw.Stop();
            //Console.WriteLine($"ohne sb:    {sw.ElapsedMilliseconds:N0}");
            //sw.Reset();
            //sw.Start();

            //Kata.DoubleCharSB(new string('x', n));

            //sw.Stop();

            //Console.WriteLine($"mit sb:     {sw.ElapsedMilliseconds:N0}");
            //sw.Start();

            //Kata.DoubleChar(new string('x', n));

            //sw.Stop();
            //Console.WriteLine($"ohne sb:    {sw.ElapsedMilliseconds:N0}");
            //sw.Reset();
            //sw.Start();

            //Kata.DoubleCharSB(new string('x', n));

            //sw.Stop();

            //Console.WriteLine($"mit sb:     {sw.ElapsedMilliseconds:N0}");

            return Kata.DoubleCharSB(s);
        }
    }

    internal class Kata
    {
        internal static string DoubleChar(string s) => s.ToCharArray().Aggregate(string.Empty, (a, c) => a + new string(c, 2));

        internal static string DoubleCharSB(string s)
        {
            var sb = new StringBuilder();
            s.ToCharArray().ToList().ForEach(c => sb.Append(new string(c, 2)));
            return sb.ToString();
        }
    }
}