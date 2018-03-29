using NUnit.Framework;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        if(seconds == 0)
        {
            return "now";
        }


        return string.Empty;
    }
}

[TestFixture]
public class HumanTimeFormatTests
{
    [Test]
    public void test1()
    {
        Assert.AreEqual("now", HumanTimeFormat.formatDuration(0));
    }

    [Test]
    [Ignore("nyi")]
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