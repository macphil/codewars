using NUnit.Framework;

// see https://www.codewars.com/kata/find-the-unknown-digit
public class Runes
{
    public static int solveExpression(string expression)
    {
        int missingDigit = -1;

        //Write code to determine the missing digit or unknown rune
        //Expression will always be in the form
        //(number)[opperator](number)=(number)
        //Unknown digit will not be the same as any other digits used in expression

        return missingDigit;
    }
}

[TestFixture]
public class RunesTest
{
    // regex: s: .*\(([^,]*), Runes\.solveExpression\(([^\)]*)\), ([^\)]*).* r: [TestCase($2, ExpectedResult = $1, TestName = $3)]
    [Test]
    [TestCase("1+1=?", ExpectedResult = 2, TestName = "Answer for expression '1+1=?' ")]
    [TestCase("123*45?=5?088", ExpectedResult = 6, TestName = "Answer for expression '123*45?=5?088' ")]
    [TestCase("-5?*-1=5?", ExpectedResult = 0, TestName = "Answer for expression '-5?*-1=5?' ")]
    [TestCase("19--45=5?", ExpectedResult = -1, TestName = "Answer for expression '19--45=5?' ")]
    [TestCase("??*??=302?", ExpectedResult = 5, TestName = "Answer for expression '??*??=302?' ")]
    [TestCase("?*11=??", ExpectedResult = 2, TestName = "Answer for expression '?*11=??' ")]
    [TestCase("??*1=??", ExpectedResult = 2, TestName = "Answer for expression '??*1=??' ")]
    public int SolveExpressionTests(string expression) => Runes.solveExpression(expression);

    [Test, Ignore("not yet finished")]
    public void testSample()
    {
        Assert.AreEqual(2, Runes.solveExpression("1+1=?"), "Answer for expression '1+1=?' ");
        Assert.AreEqual(6, Runes.solveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");
        Assert.AreEqual(0, Runes.solveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
        Assert.AreEqual(-1, Runes.solveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
        Assert.AreEqual(5, Runes.solveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
        Assert.AreEqual(2, Runes.solveExpression("?*11=??"), "Answer for expression '?*11=??' ");
        Assert.AreEqual(2, Runes.solveExpression("??*1=??"), "Answer for expression '??*1=??' ");
    }
}