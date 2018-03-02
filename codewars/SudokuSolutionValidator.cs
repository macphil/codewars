using System.Linq;

namespace codewars
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    /// <summary>
    /// see https://www.codewars.com/kata/sudoku-solution-validator/csharp
    /// </summary>

    class Sudoku
    {
        public static bool ValidateSolution(int[][] board)
        {
            return ValidateRows(board) && ValidateColumns(board) && ValidateBlocks(board);
        }

        internal static bool ValidateBlocks(int[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                var sequenceToTest = GetBlockSequence(board, i);
                if (!ValidateSequence(sequenceToTest))
                {
                    return false;
                }
            }
            return true;
        }

        private static int[] GetBlockSequence(int[][] board, int block)
        {
            int x = 0;
            int y = 0;
            switch (block)
            {
                case 0:
                    x = 0;
                    y = 0;
                    break;

                case 1:
                    x = 3;
                    y = 0;
                    break;

                case 2:
                    x = 6;
                    y = 0;
                    break;

                case 3:
                    x = 0;
                    y = 3;
                    break;

                case 4:
                    x = 3;
                    y = 3;
                    break;

                case 5:
                    x = 6;
                    y = 3;
                    break;

                case 6:
                    x = 0;
                    y = 6;
                    break;

                case 7:
                    x = 3;
                    y = 6;
                    break;

                case 8:
                    x = 6;
                    y = 6;
                    break;

                default:
                    x = 0;
                    y = 0;
                    break;
            }

            var blockWidth = (int)Math.Floor(Math.Sqrt(board.Length));
            var sequenceToTest = new int[board.Length];
            int pos = 0;

            for (int i = 0; i < blockWidth; i++)
            {
                for (int j = 0; j < blockWidth; j++)
                {
                    sequenceToTest[pos++] = board[x + i][y + j];
                }
            }

            return sequenceToTest;
        }

        internal static bool ValidateColumns(int[][] board)
        {
            for (var row = 0; row < board.Length; row++)
            {
                var sequenceToTest = new int[board.Length];
                for (var column = 0; column < board.First().Length; column++)
                {
                    sequenceToTest[column] = board[column][row];
                }
                if (!ValidateSequence(sequenceToTest))
                {
                    return false;
                }
            }
            return true;
        }

        internal static bool ValidateRows(int[][] board) => board.All(ValidateSequence);

        internal static bool ValidateSequence(int[] sequenceToTest)
        {
            if (sequenceToTest.Any(x => x == 0) || sequenceToTest.Any(x => x > sequenceToTest.Length))
            {
                return false;
            }
            return sequenceToTest.Distinct().Count() == sequenceToTest.Length;
        }
    }

    [TestFixture]
    public class Sample_Tests
    {
        private static object[] testCases = new object[]
        {
            new object[]
            {
                true,
                new int[][]
                {
                    new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                    new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                    new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                    new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
                },
            },
            new object[]
            {
                false,
                new int[][]
                {
                    new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                    new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
                    new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
                    new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
                    new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
                },
            },
            new object[]
            {
                false,
                new int[][]
                {
                    new int[] {5, 3, 4, 6, 7, 8, 9, 2, 1},
                    new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                    new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                    new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                    new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                    new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                    new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                    new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                    new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
                },
            },
            new object[]
            {
                false,
                new int[][]
                {
                    new int[] { 7, 8, 9, 1, 2, 3, 4, 5, 6},
                    new int[] { 8, 9, 7, 2, 3, 1, 5, 6, 4},
                    new int[] { 9, 7, 8, 3, 1, 2, 6, 4, 5},
                    new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9},
                    new int[] { 2, 3, 1, 5, 6, 4, 8, 9, 7},
                    new int[] { 3, 1, 2, 6, 4, 5, 9, 7, 8},
                    new int[] { 4, 5, 6, 7, 8, 9, 1, 2, 3},
                    new int[] { 5, 6, 4, 8, 9, 7, 2, 3, 1},
                    new int[] { 6, 4, 5, 9, 7, 8, 3, 1, 2},
                },
            },
        };

        public static IEnumerable TestSequences
        {
            get
            {
                yield return new TestCaseData(new[] { 1, 2 }).Returns(true);
                yield return new TestCaseData(new[] { 1, 1 }).Returns(false);
                yield return new TestCaseData(new[] { 1, 0 }).Returns(false);
                yield return new TestCaseData(new[] { 1, 3 }).Returns(false);
                yield return new TestCaseData(new[] { 5, 3, 4, 6, 7, 8, 9, 1, 2 }).Returns(true);
                yield return new TestCaseData(new[] { 3, 0, 0, 2, 8, 6, 1, 7, 9 }).Returns(false);
            }
        }

        [Test, TestCaseSource("testCases")]
        public void Test(bool expected, int[][] board) => Assert.AreEqual(expected, Sudoku.ValidateSolution(board));

        [Test]
        [TestCaseSource(nameof(TestSequences))]
        public bool TestValidateSequence(int[] sequenceToTest) => Sudoku.ValidateSequence(sequenceToTest);

        [Test]
        public void TestValidateBlocks()
        {
            // arrange
            var board = new int[][]
            {
                new int[] {1, 2, 3, 1, 2, 3, 1, 2, 3},
                new int[] {4, 5, 6, 4, 5, 6, 4, 5, 6},
                new int[] {7, 8, 9, 7, 8, 9, 7, 8, 9},
                new int[] {1, 2, 3, 1, 2, 3, 1, 2, 3},
                new int[] {4, 5, 6, 4, 5, 6, 4, 5, 6},
                new int[] {7, 8, 9, 7, 8, 9, 7, 8, 9},
                new int[] {1, 2, 3, 1, 2, 3, 1, 2, 3},
                new int[] {4, 5, 6, 4, 5, 6, 4, 5, 6},
                new int[] {7, 8, 9, 7, 8, 9, 7, 8, 8},
            };

            // act
            bool isValid = Sudoku.ValidateBlocks(board);

            // assert
            Assert.That(isValid, Is.False);
        }
    }
}