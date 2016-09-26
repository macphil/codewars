using System.Collections.Generic;
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
            // sometimes, it's seems legit to use dictionaries :-)
            // https://oeis.org/A023106 + https://oeis.org/A023106/b023106.txt
            return OESIS_A023106[n + 9];
        }

        public static Dictionary<int, long> OESIS_A023106 = new Dictionary<int, long>
        {
            [0] = 0,
            [1] = 1,
            [2] = 2,
            [3] = 3,
            [4] = 4,
            [5] = 5,
            [6] = 6,
            [7] = 7,
            [8] = 8,
            [9] = 9,
            [10] = 81,
            [11] = 512,
            [12] = 2401,
            [13] = 4913,
            [14] = 5832,
            [15] = 17576,
            [16] = 19683,
            [17] = 234256,
            [18] = 390625,
            [19] = 614656,
            [20] = 1679616,
            [21] = 17210368,
            [22] = 34012224,
            [23] = 52521875,
            [24] = 60466176,
            [25] = 205962976,
            [26] = 612220032,
            [27] = 8303765625,
            [28] = 10460353203,
            [29] = 24794911296,
            [30] = 27512614111,
            [31] = 52523350144,
            [32] = 68719476736,
            [33] = 271818611107,
            [34] = 1174711139837,
            [35] = 2207984167552,
            [36] = 6722988818432,
            [37] = 20047612231936,
            [38] = 72301961339136,
            [39] = 248155780267521,
            [40] = 3904305912313344,
            [41] = 45848500718449031,
            [42] = 81920000000000000,
            [43] = 150094635296999121
        };
    }
}