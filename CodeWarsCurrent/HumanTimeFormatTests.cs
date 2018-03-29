using NUnit.Framework;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if(seconds == 0)
        {
            return "now";
        }
        // var humanTimeFormat = new System.Text.StringBuilder();

        var secondsPart =  ParseForTimeUnit(seconds, TimeUnit.seconds, out int remainder);

        return secondsPart;
    }

    internal static string ParseForTimeUnit(int seconds, TimeUnit timeUnit, out int remainder)
    {
        remainder = 0;
        int number = 0;


        switch (timeUnit)
        {
            case TimeUnit.seconds:
                number = seconds;
                break;
            default:
                HumanTimeFormat.EuclideanDivision(seconds, (int)timeUnit, out number, out remainder);
                break;
        }

        if(number == 0)
        {
            return string.Empty;
        }
        if(number == 1)
        {
            var singleTimeUnit = timeUnit.ToString().Substring(0, timeUnit.ToString().Length -1);
            return $"1 {singleTimeUnit}";
        }
        else
        {
            return $"{number} {timeUnit}";
        }
    }


    internal static void EuclideanDivision(int divident, int divisor, out int quotient, out int remainder)
    {
        quotient = divident / divisor;
        remainder = divident % divisor;
    }
}

internal enum TimeUnit : int
{
    years = 60*60*24*365, days = 60*60*24, hours = 60*60, minutes = 60, seconds = 1
}

[TestFixture]
public class HumanTimeFormatTests
{
    [Test]
    [TestCase(9, 2, 4, 1)]
    [TestCase(10, 5, 2, 0)]
    [TestCase(121,60,2,1)]
    public void TestEuclideanDivision(int divident, int divisor, int expectedQuotient, int expectedRemainder) 
    {
        // arrange
        int quotent;
        int remainder;

        // act
        HumanTimeFormat.EuclideanDivision(divident, divisor, out quotent, out remainder);

        // assert
        Assert.That(quotent, Is.EqualTo(expectedQuotient));
        Assert.That(remainder, Is.EqualTo(expectedRemainder));
    }

    [Test]
    [TestCase(0, ExpectedResult = "now")]
    [TestCase(1, ExpectedResult = "1 second")]
    [TestCase(2, ExpectedResult = "2 seconds")]
    [TestCase(59, ExpectedResult = "59 seconds")]
    [TestCase(2, ExpectedResult = "2 seconds")]
    [TestCase(61, ExpectedResult = "1 minute and 1 second")]
    [TestCase(62, ExpectedResult = "1 minute and 2 seconds")]
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
    [Ignore("nyi")]
    public void test3()
    {
        Assert.AreEqual("1 minute and 2 seconds", HumanTimeFormat.formatDuration(62));
    }

    [Test]
    [Ignore("nyi")]
    public void test4()
    {
        Assert.AreEqual("2 minutes", HumanTimeFormat.formatDuration(120));
    }

    [Test]
    [Ignore("nyi")]
    public void test5()
    {
        Assert.AreEqual("1 hour, 1 minute and 2 seconds", HumanTimeFormat.formatDuration(3662));
    }
}