using System;
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
        [TestCase("codewars.com-", ExpectedResult = false)]
        [TestCase("example@codewars.com", ExpectedResult = false)]
        [TestCase("CODEWARS.COM", ExpectedResult = true)]
        [TestCase("codewars.com", ExpectedResult = true)]
        [TestCase("g.co", ExpectedResult = true)]
        [TestCase("sub.codewars.com", ExpectedResult = true)]
        public string DomainNameValidator_Tests(string actual)
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
        internal string validate(string actual)
        {
            throw new NotImplementedException();
        }
    }
}