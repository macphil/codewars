using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

// see https://www.codewars.com/kata/find-the-unknown-digit

/*
 * The professor will give you a simple math expression, of the form

[number][op][number]=[number]
He has converted all of the runes he knows into digits.
The only operators he knows are
- addition (+),
- subtraction(-), and
- multiplication (*), so those are the only ones that will appear.

Each number will be in the range from -1000000 to 1000000, and will consist of only the
- digits 0-9,
- possibly a leading -, and
- maybe a few ?s. If there are ?s in an expression, they represent a digit rune that the professor doesn't know (never an operator, and never a leading -).

All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression. No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.

Given an expression, figure out the value of the rune represented by the question mark. If more than one digit works, give the lowest one. If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong. output -1 in that case.

Complete the method to solve the expression to find the value of the unknown rune. The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune or -1 if no such rune exists.
 */

public class Runes
{
    public static string NumberPattern => "[0-9]{1,}";

    public static string OperatorPattern => "[-+*]{1}";

    public static string PlainExpressionPattern => $"{NumberPattern}{OperatorPattern}{NumberPattern}[=]{NumberPattern}";

    public static bool IsPlainExpressionCorrect(string plainExpression)
    {
        if (!Regex.IsMatch(plainExpression, Runes.PlainExpressionPattern))
        {
            return false;
        }

        var numbers = GetNumbersFromExpression(plainExpression);

        var chars = Regex.Split(plainExpression, @"\d+");

        var firstOperator = Array.Find(chars, s => !string.IsNullOrEmpty(s));

        switch (firstOperator)
        {
            case "+":
                return numbers[0] + numbers[1] == numbers[2];

            case "-":
                return numbers[0] - numbers[1] == numbers[2];

            case "*":
                return numbers[0] * numbers[1] == numbers[2];

            default:
                return false;
        }
    }

    public static int solveExpression(string expression)
    {
        var missingDigit = -1;
        //Write code to determine the missing digit or unknown rune
        //Expression will always be in the form
        //(number)[opperator](number)=(number)
        //Unknown digit will not be the same as any other digits used in expression

        return missingDigit;
    }

    private static int[] GetNumbersFromExpression(string plainExpression)
    {
        var digits = Regex.Split(plainExpression, @"\D+");
        var numbers = new int[digits.Length];

        for (var i = 0; i < digits.Length; i++)
        {
            numbers[i] = int.Parse(digits[i]);
        }

        return numbers;
    }
}

[TestFixture]
public class RunesTest
{
    [Test]
    [TestCase("0+1=1", ExpectedResult = true)]
    [TestCase("12*34=408", ExpectedResult = true)]
    [TestCase("98-76=22", ExpectedResult = true)]
    [TestCase("55-44=11", ExpectedResult = true)]
    [TestCase("55-44=10", ExpectedResult = false)]
    [TestCase("1000000-1000000=0", ExpectedResult = true)]
    [TestCase("-1000000+1000000=0", ExpectedResult = true)]
    public bool IsPlainExpressionCorrectTest(string expression) => Runes.IsPlainExpressionCorrect(expression);

    [Test]
    [TestCase("0", ExpectedResult = true)]
    [TestCase("12", ExpectedResult = true)]
    [TestCase("234", ExpectedResult = true)]
    [TestCase("1000000", ExpectedResult = true)]
    [TestCase("-1000000", ExpectedResult = true)]
    [TestCase("10000000", ExpectedResult = true)]
    [TestCase("456789", ExpectedResult = true)]
    [TestCase("-1", ExpectedResult = true)]
    [TestCase("a", ExpectedResult = false)]
    public bool IsValidNumberExpression(string expression) => Regex.IsMatch(expression, Runes.NumberPattern);

    [Test]
    [TestCase("0", ExpectedResult = false)]
    [TestCase("-", ExpectedResult = true)]
    [TestCase("+", ExpectedResult = true)]
    [TestCase("*", ExpectedResult = true)]
    public bool IsValidOperator(string expression) => Regex.IsMatch(expression, Runes.OperatorPattern);

    [Test]
    [TestCase("0+1=1", ExpectedResult = true)]
    [TestCase("12*34=408", ExpectedResult = true)]
    [TestCase("98-76=22", ExpectedResult = true)]
    [TestCase("1=2-2", ExpectedResult = false)]
    public bool IsValidPlainExpression(string expression) => Regex.IsMatch(expression, Runes.PlainExpressionPattern);

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