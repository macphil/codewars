using NUnit.Framework;

/* https://www.codewars.com/kata/ipv4-validator/train/csharp
*
* In this kata you have to write a method to verify the validity of IPv4 addresses.

Example of valid inputs:

"1.1.1.1"

"127.0.0.1"

"255.255.255.255"

Example of invalid input:

"1444.23.9"

"153.500.234.444"

"-12.344.43.11"

* */

namespace codewars
{
    public class Ipv4Validator
    {
        [Test]
        [TestCase("123.456.789.0", false)]
        [TestCase("127.0.0.1", true)]
        public void IpValidator_AreEqual(string actual, bool expected)
        {
            Assert.AreEqual(expected, IpValidator(actual));
        }

        public static bool IpValidator(string ip)
        {
            return false;
        }
    }
}