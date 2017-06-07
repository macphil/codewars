using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace codewars
{
    // https://www.codewars.com/kata/5893933e1a88084be10001a3/train/csharp
    public class DomainNameValidatorTests
    {
        private DomainNameValidator v;

        [Test]
        [TestCase("codewars", ExpectedResult = false)]
        [TestCase(".codewars.com", ExpectedResult = false)]
        [TestCase("127.0.0.1", ExpectedResult = false)]
        [TestCase("L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L", ExpectedResult = false)]
        [TestCase("L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L.L", ExpectedResult = true)]
        [TestCase("codewars.com-", ExpectedResult = false)]
        [TestCase("example@codewars.com", ExpectedResult = false)]
        [TestCase("CODEWARS.COM", ExpectedResult = true)]
        [TestCase("codewars.com", ExpectedResult = true)]
        [TestCase("123.codewars.com", ExpectedResult = true)]
        [TestCase("nö.codewars.com", ExpectedResult = false)]
        [TestCase("x#x.codewars.com", ExpectedResult = false)]
        [TestCase("g.co", ExpectedResult = true)]
        [TestCase("g.-x-.co", ExpectedResult = false)]
        [TestCase("g.x-.co", ExpectedResult = false)]
        [TestCase("g.-x.co", ExpectedResult = false)]
        [TestCase("g.--.co", ExpectedResult = false)]
        [TestCase("g.-.co", ExpectedResult = false)]
        [TestCase("sub.code-wars.com", ExpectedResult = true)]
        [TestCase("sub.codewars.com", ExpectedResult = true)]
        public bool DomainNameValidator_Tests(string actual)
        {
            return v.validate(actual);
        }

        [OneTimeSetUp]
        public void setup()
        {
            v = new DomainNameValidator();
        }
    }

    internal class DomainNameValidator
    {
        /***
         * In this kata you have to create a domain name validator mostly compliant with RFC 1035, RFC 1123, and RFC 2181

        For purposes of this kata, following rules apply:

          [x] Domain name may contain subdomains (levels), hierarchically separated by . (period) character
          [x] Domain name must not contain more than 127 levels, including top level (TLD)
          [x] Domain name must not be longer than 253 characters (RFC specifies 255, but 2 characters are reserved for trailing dot and null character for root level)
          [_] Level names must be composed out of lowercase and uppercase ASCII letters, digits and - (minus sign) character
          [_] Level names must not start or end with - (minus sign) character
          [x] Level names must not be longer than 63 characters
          [_] Top level (TLD) must not be fully numerical

        Additionally, in this kata

            Domain name must contain at least one subdomain (level) apart from TLD
            Top level validation must be naive - ie. TLDs nonexistent in IANA register are still considered valid as long as they adhere to the rules given above.

        The validation function accepts string with the full domain name and returns boolean value indicating whether the domain name is valid or not.
        */

        public bool validate(string domain)
        {
            if (!ValidateStringLength(domain, 253)) return false;
            var levels = domain.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            if (levels.Length < 2 || levels.Length > 127)
            {
                return false;
            }
            if (levels.Any(level => !ValidateLevel(level)))
            {
                return false;
            }

            return true;
        }

        private static bool ValidateStringLength(string stringToValidate, int maxLength)
        {
            return !string.IsNullOrWhiteSpace(stringToValidate) && stringToValidate.Trim().Length <= maxLength;
        }

        private bool ValidateLevel(string level)
        {
            if (!ValidateStringLength(level, 63)) return false;
            if (level.StartsWith("-") || level.EndsWith("-")) return false;
            return Regex.IsMatch(level, @"^[A-Z0-9-]*$", RegexOptions.IgnoreCase);
        }
    }
}