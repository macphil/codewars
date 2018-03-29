using NUnit.Framework;

[TestFixture]
public class HumanTimeFormatTests
{
    [Test]
    [TestCase(0, ExpectedResult = "now")]
    [TestCase(1, ExpectedResult = "1 second")]
    [TestCase(2, ExpectedResult = "2 seconds")]
    [TestCase(59, ExpectedResult = "59 seconds")]
    [TestCase(2, ExpectedResult = "2 seconds")]
    [TestCase(61, ExpectedResult = "1 minute and 1 second")]
    [TestCase(62, ExpectedResult = "1 minute and 2 seconds")]
    [TestCase(60 * 2 + 2, ExpectedResult = "2 minutes and 2 seconds")]
    [TestCase(60 * 60 * 2 + 2, ExpectedResult = "2 hours and 2 seconds")]
    [TestCase(60 * 60 * 2 - 4, ExpectedResult = "1 hour, 59 minutes and 56 seconds")]
    [TestCase(60 * 60 * 24 + 1, ExpectedResult = "1 day and 1 second")]
    [TestCase(60 * 60 * 24 + 61, ExpectedResult = "1 day, 1 minute and 1 second")]
    [TestCase(60 * 60 * 24 * 365 + 60 * 60 * 24 + 60 * 60 + 61, ExpectedResult = "1 year, 1 day, 1 hour, 1 minute and 1 second")]
    [TestCase(60 * 60 * 24 * 365 + 1, ExpectedResult = "1 year and 1 second")]
    [TestCase(int.MaxValue, ExpectedResult = "68 years, 35 days, 3 hours, 14 minutes and 7 seconds")]
    public string FormatDurationTests(int seconds) => HumanTimeFormat.formatDuration(seconds);

    [Test]
    public void test1()
    {
        Assert.AreEqual("now", HumanTimeFormat.formatDuration(0));
    }

    [Test]
    public void test2()
    {
        Assert.AreEqual("1 second", HumanTimeFormat.formatDuration(1));
    }

    [Test]
    public void test3()
    {
        Assert.AreEqual("1 minute and 2 seconds", HumanTimeFormat.formatDuration(62));
    }

    [Test]
    public void test4()
    {
        Assert.AreEqual("2 minutes", HumanTimeFormat.formatDuration(120));
    }

    [Test]
    public void test5()
    {
        Assert.AreEqual("1 hour, 1 minute and 2 seconds", HumanTimeFormat.formatDuration(3662));
    }
}