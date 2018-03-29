using System.Linq;
using NUnit.Framework;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if(seconds == 0)
        {
            return "now";
        }
        var humanTimeFormat = new System.Collections.Generic.List<string>
        {
            ParseForTimeUnit(seconds, TimeUnit.year, out int remainder),
            ParseForTimeUnit(remainder, TimeUnit.day, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.hour, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.minute, out remainder),
            ParseForTimeUnit(remainder, TimeUnit.second, out remainder)
        };

        var nonZeroComponents = humanTimeFormat.Where(x => !string.IsNullOrEmpty(x));
        var humanReadableDuration = string.Empty;
        if(nonZeroComponents.Count() > 2)
        {
            var csvComponents = nonZeroComponents.ToList().GetRange(0, nonZeroComponents.Count() - 2);
            humanReadableDuration = string.Join(", ", csvComponents) + ", ";
        }
        if (nonZeroComponents.Count() > 1)
        {
            var recentButOneComponent = nonZeroComponents.Skip(nonZeroComponents.Count() - 2).Take(1);
            humanReadableDuration += $"{recentButOneComponent.Single()} and ";
        }
        humanReadableDuration += nonZeroComponents.Last();

        return humanReadableDuration;
    }

    internal static string ParseForTimeUnit(int seconds, TimeUnit timeUnit, out int remainder)
    {
        remainder = 0;
        int number = 0;

        switch (timeUnit)
        {
            case TimeUnit.second:
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
            return $"1 {timeUnit}";
        }
        else
        {
            return $"{number} {timeUnit}s";
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
    year = 60*60*24*365, day = 60*60*24, hour = 60*60, minute = 60, second = 1
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