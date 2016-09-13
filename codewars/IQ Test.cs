using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    /*
     * Bob is preparing to pass IQ test.
     * The most frequent task in this test is to find out which one of the given numbers differs from the others.
     * Bob observed that one number usually differs from the others in evenness.
     * Help Bob — to check his answers,
     * he needs a program that among the given numbers finds one
     * that is different in evenness, and return a position of this number.
     * ! Keep in mind that your task is to help Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)
     *
     * */

    public class IQ_Test
    {
        [Test]
        [TestCase("2 4 7 8 10", ExpectedResult = 3)] // Third number is odd, while the rest of the numbers are even
        [TestCase("1 2 1 1", ExpectedResult = 2)] // Second number is even, while the rest of the numbers are odd
        public int IQ_Test_AreEqual(string numbers)
        {
            return IQ_Test.Test(numbers);
        }

        public static int Test(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return -1;
            }
            var numberArray = numbers.Split(' ');
            var pos = 1;

            var numberDict = new Dictionary<int, int>();
            foreach (string s in numberArray)
            {
                numberDict.Add(pos++, Int32.Parse(s));
            }

            if (numberDict.Count(x => x.Value % 2 == 0) == 1)
            {
                return numberDict.First(x => x.Value % 2 == 0).Key;
            }
            else
            {
                return numberDict.First(x => x.Value % 2 == 1).Key;
            }
        }
    }
}