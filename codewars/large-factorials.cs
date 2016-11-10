namespace codewars
{
    using NUnit.Framework;

    public class large_factorials
    {
        public static string Factorial(int n)
        {
            return "";
        }

        [Test]
        [TestCase(-1, ExpectedResult = "")]
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(5, ExpectedResult = "120")]
        [TestCase(9, ExpectedResult = "362880")]
        [TestCase(15, ExpectedResult = "1307674368000")]
        [TestCase(25, ExpectedResult = "15511210043330985984000000")]
        public string large_factorials_Tests(int n)
        {
            return Factorial(n);
        }
    }
}