using NUnit.Framework;

public class HumanTimeFormat
{
    public static string formatDuration(int seconds)
    {
        //Enter Code here
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