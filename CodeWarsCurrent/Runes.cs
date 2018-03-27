// see https://www.codewars.com/kata/find-the-unknown-digit

using System;

namespace codewars
{
    public class Runes
    {
        internal int FirstNumber;
        internal char NumberOperator;
        internal int Result;
        internal int SecondNumber;

        public static int SolveExpression(string expression)
        {
            const int missingDigit = -1;

            for (var i = 0; i < 10; i++)
            {
                if (expression.Contains($"{i}"))
                {
                    continue;
                }

                if (IsPlainExpressionCorrect(expression.Replace("?", $"{i}")))
                {
                    return i;
                }
            }

            return missingDigit;
        }

        internal static bool IsPlainExpressionCorrect(string plainExpression)
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

        internal static bool ValidateExpression(string expression, int equalsSignPos, int operationsPos)
        {
            if (equalsSignPos == -1 || operationsPos == -1 || equalsSignPos < operationsPos)
            {
                return false;
            }

            // -- No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.
            if (!expression.Contains("00"))
            {
                return true;
            }

            if (CheckDoubleOAfterPosition(expression, 0)
                || CheckDoubleOAfterPosition(expression, operationsPos + 1)
                || CheckDoubleOAfterPosition(expression, equalsSignPos + 1))
            {
                return false;
            }

            return true;
        }

        internal bool TryParseExpression(string expression)
        {
            var equalsSignPos = expression.IndexOf('=');
            var numberOperatorChars = new[] { '-', '+', '*' };
            var operationsPos = expression.IndexOfAny(numberOperatorChars, 1);

            if (!ValidateExpression(expression, equalsSignPos, operationsPos))
            {
                return false;
            }
            NumberOperator = expression[operationsPos];
            return NumberOperator != char.MaxValue &&
                   int.TryParse(expression.Substring(0, operationsPos), out FirstNumber) &&
                   int.TryParse(expression.Substring(operationsPos + 1, equalsSignPos - operationsPos - 1), out SecondNumber) &&
                   int.TryParse(expression.Substring(equalsSignPos + 1), out Result);
        }

        private static bool CheckDoubleOAfterPosition(string expression, int position) => expression.IndexOf("00", StringComparison.Ordinal) == position;
    }
}