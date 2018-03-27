using System.Collections.Generic;
using System.Linq;
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
    internal int FirstNumber;
    internal char NumberOperator;
    internal int Result;
    internal int SecondNumber;

    public static bool IsPlainExpressionCorrect(string plainExpression)
    {
        var runes = new Runes();
        if (!runes.TryParseExpression(plainExpression))
        {
            return false;
        }

        switch (runes.NumberOperator)
        {
            case '+':
                return runes.FirstNumber + runes.SecondNumber == runes.Result;

            case '-':
                return runes.FirstNumber - runes.SecondNumber == runes.Result;

            case '*':
                return runes.FirstNumber * runes.SecondNumber == runes.Result;

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
        var possibleDigits = PossibleDigits(expression);
        foreach (var possibleDigit in possibleDigits)
        {
            // -- No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.
            if (possibleDigit == 0 && expression.Contains("??"))
            {
                continue;
            }

            if (IsPlainExpressionCorrect(expression.Replace("?", $"{possibleDigit}")))
            {
                return possibleDigit;
            }
        }

        return missingDigit;
    }

    public bool TryParseExpression(string expression)
    {
        var equalsSignPos = expression.IndexOf('=');
        var numberOperatorChars = new[] { '-', '+', '*' };
        var operationsPos = expression.IndexOfAny(numberOperatorChars, 1);

        if (equalsSignPos == -1 || operationsPos == -1 || operationsPos >= equalsSignPos)
        {
            return false;
        }

        FirstNumber = int.Parse(expression.Substring(0, operationsPos));
        NumberOperator = expression[operationsPos];
        SecondNumber = int.Parse(expression.Substring(operationsPos + 1, equalsSignPos - operationsPos - 1));
        Result = int.Parse(expression.Substring(equalsSignPos + 1));

        return NumberOperator != char.MaxValue;
    }

    internal static IEnumerable<int> PossibleDigits(string expression)
    {
        int[] range = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var usedDigits = expression.ToCharArray()
            .Where(char.IsDigit)
            .Select(c => (int)char.GetNumericValue(c));

        return range.Except(usedDigits);
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
    [TestCase("55-44=10", ExpectedResult = false, Ignore = "nyi")]
    [TestCase("1000000-1000000=0", ExpectedResult = true)]
    [TestCase("-1000000+1000000=0", ExpectedResult = true)]
    public bool IsPlainExpressionCorrectTest(string expression) => Runes.IsPlainExpressionCorrect(expression);

    [Test]
    [TestCase("12345", ExpectedResult = "0,6,7,8,9")]
    [TestCase("123456789", ExpectedResult = "0")]
    [TestCase("1234567890", ExpectedResult = "")]
    [TestCase("", ExpectedResult = "0,1,2,3,4,5,6,7,8,9")]
    public string PossibleDigitsTest(string expression) => string.Join(",", Runes.PossibleDigits(expression));

    // regex: s: .*\(([^,]*), Runes\.solveExpression\(([^\)]*)\), ([^\)]*).* r: [TestCase($2, ExpectedResult = $1, TestName = $3)]
    [Test]
    [TestCase("1+1=?", ExpectedResult = 2, TestName = "Answer for expression '1+1=?' ")]
    [TestCase("123*45?=5?088", ExpectedResult = 6, TestName = "Answer for expression '123*45?=5?088' ")]
    [TestCase("-5?*-1=5?", ExpectedResult = 0, TestName = "Answer for expression '-5?*-1=5?' ")]
    [TestCase("19--45=5?", ExpectedResult = -1, TestName = "Answer for expression '19--45=5?' ")]
    [TestCase("1975=6", ExpectedResult = -1, TestName = "Answer for expression '1975=6' ")]
    [TestCase("??*??=302?", ExpectedResult = 5, TestName = "Answer for expression '??*??=302?' ")]
    [TestCase("?*11=??", ExpectedResult = 2, TestName = "Answer for expression '?*11=??' ")]
    [TestCase("??*1=??", ExpectedResult = 2, TestName = "Answer for expression '??*1=??' ")]
    public int SolveExpressionTests(string expression) => Runes.solveExpression(expression);

    [Test]
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

    [Test]
    [TestCase("1+2=3", 1, '+', 2, 3)]
    [TestCase("10 + 20 = 30", 10, '+', 20, 30)]
    [TestCase("-10 * 20 = -200", -10, '*', 20, -200)]
    public void TryParseExpressionTest(string expression, int firstNumber, char op, int secondNumber, int result)
    {
        // arrange
        var sut = new Runes();

        // act
        sut.TryParseExpression(expression);

        // assert
        Assert.That(sut.FirstNumber, Is.EqualTo(firstNumber));
        Assert.That(sut.SecondNumber, Is.EqualTo(secondNumber));
        Assert.That(sut.NumberOperator, Is.EqualTo(op));
        Assert.That(sut.Result, Is.EqualTo(result));
    }
}