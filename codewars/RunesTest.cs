using NUnit.Framework;

namespace codewars
{
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
        [TestCase("5?+5?=1??", ExpectedResult = 0)]
        [TestCase("5?+1??=15?", ExpectedResult = 0)]
        [TestCase("51?-1??=41?", ExpectedResult = 0)]
        [TestCase("51?-??1=5?9", ExpectedResult = -1)] // -- No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.
        [TestCase("1??-1??=?", ExpectedResult = 0)]
        [TestCase("?*?=?", ExpectedResult = 0)]
        [TestCase("?*?=", ExpectedResult = -1)]
        [TestCase("10/2=?", ExpectedResult = -1)]
        public int SolveExpressionTests(string expression) => Runes.SolveExpression(expression);

        [Test]
        public void testSample()
        {
            Assert.AreEqual(2, Runes.SolveExpression("1+1=?"), "Answer for expression '1+1=?' ");
            Assert.AreEqual(6, Runes.SolveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");
            Assert.AreEqual(0, Runes.SolveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
            Assert.AreEqual(-1, Runes.SolveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
            Assert.AreEqual(5, Runes.SolveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
            Assert.AreEqual(2, Runes.SolveExpression("?*11=??"), "Answer for expression '?*11=??' ");
            Assert.AreEqual(2, Runes.SolveExpression("??*1=??"), "Answer for expression '??*1=??' ");
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
}