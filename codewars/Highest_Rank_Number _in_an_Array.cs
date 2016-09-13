﻿using System;
using System.Linq;
using NUnit.Framework;

/// <summary>
/// https://www.codewars.com/kata/highest-rank-number-in-an-array/train/csharp
/// </summary>
/// <autogeneratedoc />
namespace codewars
{
    public class Highest_Rank_Number__in_an_Array
    {
        [Test]
        [TestCase(new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12 }, ExpectedResult = 12, TestName = "eins")]
        [TestCase(new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12, 10 }, ExpectedResult = 12, TestName = "zwei")]
        [TestCase(new int[] { 12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10 }, ExpectedResult = 3, TestName = "drei")]
        [TestCase(new int[] { 12, 10 }, ExpectedResult = 12, TestName = "vier")]
        [TestCase(new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12 }, ExpectedResult = 12, TestName = "fuenf")]
        [TestCase(new int[] { 5, 8, 5, 11, 6, 11, 7, 8, 6 }, ExpectedResult = 11, TestName = "sechs")]
        public int Highest_Rank_Number__in_an_Array_AreEqual(int[] arr)
        {
            return arr.GroupBy(x => x).OrderByDescending(x => x.Key).OrderByDescending(g => g.Count()).Select(g => g.Key).First();
        }
    }
}