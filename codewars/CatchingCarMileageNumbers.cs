using System.Collections.Generic;
using NUnit.Framework;

namespace codewars
{
    public class CatchingCarMileageNumbers
    {
        public enum NumberIs
        {
            Interesting = 2,
            NearbyInteresting = 1,
            Booring = 0
        };

        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            var result = NumberIs.Booring;

            if (!NumberIsInRange(number))
            {
                return (int)result;
            }
            var currentNumber = number;
            while (result == NumberIs.Booring && currentNumber - number <= 2)
            {
                result = CheckForDigitFollowedByAllZeros(currentNumber);
                //if (CheckForDigitFollowedByAllZeros(currentNumber))
                //{
                //    result = CheckForEveryDigitIsTheSameNumber(currentNumber);
                //}

                if (result == NumberIs.Booring)
                {
                    result = CheckForSequence(currentNumber);
                }

                if (result == NumberIs.Booring)
                {
                    result = CheckForPalindrome(currentNumber);
                }

                if (result == NumberIs.Booring)
                {
                    result = CheckForAwesomePhrases(currentNumber, awesomePhrases);
                }
                currentNumber++;
            }

            return

            (int)result;
            /*
             *
    Any digit followed by all zeros: 100, 90000
    Every digit is the same number: 1111
    The digits are sequential, incementing†: 1234
    The digits are sequential, decrementing‡: 4321
    The digits are a palindrome: 1221 or 73837
    The digits match one of the values in the awesomePhrases array

             *
             */
        }

        [Test]
        [TestCase(3, ExpectedResult = 0)]
        [TestCase(99, ExpectedResult = 0)]
        [TestCase(1336, ExpectedResult = 1)]
        [TestCase(1337, ExpectedResult = 2)]
        [TestCase(11208, ExpectedResult = 0)]
        [TestCase(11209, ExpectedResult = 1)]
        [TestCase(11210, ExpectedResult = 2)]
        [TestCase(1000000000, ExpectedResult = 0)]
        [TestCase(1000000001, ExpectedResult = 0)]
        public int CatchingCarMileageNumbers_Tests(int numberToTest)
        {
            return IsInteresting(numberToTest, new List<int> { 1337, 256 });
        }

        private static NumberIs CheckForAwesomePhrases(int number, List<int> awesomePhrases)
        {
            return NumberIs.Booring;
        }

        private static NumberIs CheckForDigitFollowedByAllZeros(int number)
        {
            // Any digit followed by all zeros: 100, 90000

            return NumberIs.Booring;
        }

        private static NumberIs CheckForEveryDigitIsTheSameNumber(int number)
        {
            return NumberIs.Booring;
        }

        private static NumberIs CheckForPalindrome(int number)
        {
            return NumberIs.Booring;
        }

        private static NumberIs CheckForSequence(int number)
        {
            return NumberIs.Booring;
        }

        private static bool NumberIsInRange(int number)
        {
            return (number <= 99 || number >= 1000000000);
        }
    }
}