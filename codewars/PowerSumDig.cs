using NUnit.Framework;

/*
 * Description:

The number 81 has a special property, a certain power of the sum of its digits is equal to 81 (nine squared). Eighty one (81), is the first number in having this property (not considering numbers of one digit). The next one, is 512. Let's see both cases with the details

8 + 1 = 9 and 92 = 81

512 = 5 + 1 + 2 = 8 and 83 = 512

We need to make a function, power_sumDigTerm(), that receives a number n and may output the n-th term of this sequence of numbers. The cases we presented above means that

power_sumDigTerm(1) == 81

power_sumDigTerm(2) == 512

Happy coding!
 *
 * */

namespace codewars
{
    public class PowerSumDig
    {
        [Test]
        [TestCase(1, ExpectedResult = 81)]
        [TestCase(2, ExpectedResult = 512)]
        [TestCase(3, ExpectedResult = 2401)]
        [TestCase(4, ExpectedResult = 4913)]
        public long PowerSumDig_Tests(int actual)
        {
            return PowerSumDigTerm(actual);
        }

        public static long PowerSumDigTerm(int n)
        {
            return 0;
        }
    }
}