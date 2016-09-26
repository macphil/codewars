using System;
using System.Linq;
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

        [Test]
        [TestCase("0", ExpectedResult = 0)]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("10", ExpectedResult = 2)]
        [TestCase("101", ExpectedResult = 5)]
        [TestCase("111111111", ExpectedResult = 511)]
        public int BitStringToInt_test(string num)
        {
            return BitStringToInt(num);
        }

        public static int Calculate(string num1, string num2)
        {
            return BitStringToInt(num1) + BitStringToInt(num2);
        }

        public static int BitStringToInt(string num)
        {
            int intVal = 0, pow = 0;
            foreach (char c in num.ToArray().Reverse())
            {
                if (c == '1')
                {
                    intVal += (int)Math.Pow(2, pow);
                }
                pow++;
            }
            return intVal;
        }
    }
}