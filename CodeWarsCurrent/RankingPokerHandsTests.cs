namespace codewars
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    ///  see https://www.codewars.com/kata/ranking-poker-hands/csharp
    /// 
    /// The first character is the value of the card, valid characters are: 
    /// 2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)
    /// 
    /// The second character represents the suit, valid characters are: 
    /// S(pades), H(earts), D(iamonds), C(lubs)
    /// </summary>

    [TestFixture]
    public class PokerTests
    {
        [TestCase("Highest straight flush wins", Result.Loss, "2H 3H 4H 5H 6H", "KS AS TS QS JS")]
        [TestCase("Straight flush wins of 4 of a kind", Result.Win, "2H 3H 4H 5H 6H", "AS AD AC AH JD")]
        [TestCase("Highest 4 of a kind wins", Result.Win, "AS AH 2H AD AC", "JS JD JC JH 3D")]
        [TestCase("4 Of a kind wins of full house", Result.Loss, "2S AH 2H AS AC", "JS JD JC JH AD")]
        [TestCase("Full house wins of flush", Result.Win, "2S AH 2H AS AC", "2H 3H 5H 6H 7H")]
        [TestCase("Highest flush wins", Result.Win, "AS 3S 4S 8S 2S", "2H 3H 5H 6H 7H")]
        [TestCase("Flush wins of straight", Result.Win, "2H 3H 5H 6H 7H", "2S 3H 4H 5S 6C")]
        [TestCase("Equal straight is tie", Result.Tie, "2S 3H 4H 5S 6C", "3D 4C 5H 6H 2S")]
        [TestCase("Straight wins of three of a kind", Result.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS")]
        [TestCase("3 Of a kind wins of two pair", Result.Loss, "2S 2H 4H 5S 4C", "AH AC 5H 6H AS")]
        [TestCase("2 Pair wins of pair", Result.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S")]
        [TestCase("Highest pair wins", Result.Loss, "6S AD 7H 4S AS", "AH AC 5H 6H 7S")]
        [TestCase("Pair wins of nothing", Result.Loss, "2S AH 4H 5S KC", "AH AC 5H 6H 7S")]
        [TestCase("Highest card loses", Result.Loss, "2S 3H 6H 7S 9C", "7H 3C TH 6H 9S")]
        [TestCase("Highest card wins", Result.Win, "4S 5H 6H TS AC", "3S 5H 6H TS AC")]
        [TestCase("Equal cards is tie", Result.Tie, "2S AH 4H 5S 6C", "AD 4C 5H 6H 2C")]
        public void PokerHandTest(string description, Result expected, string hand, string opponentHand)
        {
            Assert.AreEqual(expected, new PokerHand(hand).CompareWith(new PokerHand(opponentHand)), description);
        }
    }

    public enum Result
    {
        Win,
        Loss,
        Tie
    }

    public enum HandRanking
    {
        Unknown = 0,
        HighCard = 1,
        Pair = 2,
        TwoPair = 3,
        Trips = 4,
        Straight = 5,
        Flush = 6,
        FullHouse = 7,
        Quads = 8,
        StraightFlush = 9,
        RoyalFlush = 10
    }

    public class Card
    {
        public char Suit { get; }

        public char Value { get; }

        public Card(string card)
        {
            Value = card[0];
            Suit = card[1];
        }

        public override string ToString()
        {
            return $"Card: {Value} {Suit}";
        }
    }

    public class PokerHand
    {
        List<Card> _hand;
        public HandRanking handRanking { get; private set; }
        public PokerHand(string hand)
        {
            _hand = new List<Card>();
            handRanking = HandRanking.Unknown;
            foreach (string card in hand.Split(' '))
            {
                _hand.Add(new Card(card));
            }

            handRanking = ParseHand(_hand);

        }

        private HandRanking ParseHand(List<Card> hand)
        {
            var uniqSuits = hand.Select(x => x.Suit).Distinct();
            if (uniqSuits.Count() == 1)
            {
                return HandRanking.Flush;
            }
            return HandRanking.Unknown;
        }

        public Result CompareWith(PokerHand hand)
        {
            if (this.handRanking > hand.handRanking)
            {
                return Result.Win;
            }
            if (this.handRanking < hand.handRanking)
            {
                return Result.Loss;
            }
            return Result.Tie;
        }
    }
}
