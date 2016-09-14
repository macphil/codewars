using NUnit.Framework;

namespace codewars
{
    public class bit_calculator
    {
        [Test]
        [TestCase("10", "10", ExpectedResult = 4)]
        [TestCase("10", "0", ExpectedResult = 2)]
        [TestCase("101", "10", ExpectedResult = 7)]
        public int bit_calculator_test(string num1, string num2)
        {
            return Calculate(num1, num2);
        }

        public static int Calculate(string num1, string num2)
        {
            return 0;
        }
    }
}