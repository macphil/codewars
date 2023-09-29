using System;
using System.Globalization;
using System.Linq;
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
        [TestCase("1444.23.9", false)]
        [TestCase("-12.344.43.11", false)]
        [TestCase("153.500.234.444", false)]
        [TestCase("153.a.234.444", false)]
        [TestCase(" 1.2.3.4", false)]
        [TestCase("1.2.3.4 ", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        [TestCase("127.0.0.1", true)]
        public void IpValidator_AreEqual(string actual, bool expected)
        {
            Assert.That(IpValidator(actual), Is.EqualTo(expected));
        }

        public static bool IpValidator(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip))
            {
                return false;
            }
            var bytes = ip.Split('.');
            if (bytes.Length != 4)
            {
                return false;
            }

            byte parsedByte;
            return bytes.All(b => Byte.TryParse(b, NumberStyles.None, CultureInfo.InvariantCulture, out parsedByte));
        }
    }
}