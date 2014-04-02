using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackHandTests
    {
        [TestMethod]
        public void BlackjackHand_CreationTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            Assert.AreEqual(0, hand.Count, "The hand shouldn't have any cards in it yet, but we found {0} card(s).", hand.Count);
            Assert.AreEqual(10, hand.Bet, "We initialized the Bet to 10, but now the hand says it's {0}.", hand.Bet);
        }

        [TestMethod]
        public void BlackjackHand_DealCardTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.DealCard(MockCards.Five);

            Assert.AreEqual(1, hand.Count, "The hand should have 1 card in it, but we found {0} card(s).", hand.Count);
            Assert.AreEqual(0, hand.Score, "The hand's score should be 0, because DealCard doesn't calculate the score, but it's {0}.", hand.Score);
        }

        [TestMethod]
        public void BlackjackHand_AddCardTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.AddCard(MockCards.Five);

            Assert.AreEqual(1, hand.Count, "The hand should have 1 card in it, but we found {0} card(s).", hand.Count);
            Assert.AreEqual(5, hand.Score, "The hand's score should be 5, but it's {0}.", hand.Score);
        }

        [TestMethod]
        public void BlackjackHand_ClearTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.AddCard(MockCards.Five);
            Assert.AreEqual(1, hand.Count, "The hand should have 1 card in it, but we found {0} card(s).", hand.Count);

            hand.Clear();
            Assert.AreEqual(0, hand.Count, "The hand should have 0 card in it after being cleared, but we found {0} card(s).", hand.Count);
        }

        [TestMethod]
        public void BlackjackHand_HitTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.Hit(MockCards.Five);

            Assert.AreEqual(1, hand.Count, "The hand should have 1 card in it, but we found {0} card(s).", hand.Count);
            Assert.AreEqual(5, hand.Score, "The hand's score should be 5, but it's {0}.", hand.Score);
        }

        [TestMethod]
        public void BlackjackHand_DoubleDownTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.AddCard(MockCards.Five);
            hand.AddCard(MockCards.Six);

            hand.DoubleDown(MockCards.King);

            Assert.AreEqual(20, hand.Bet, "The bet should be doubled now that the player has doubled down.");
            Assert.AreEqual(3, hand.Count, "The hand should now have 3 cards after the new card was added.");
            Assert.AreEqual(21, hand.Score, "The hand should now have a score of 21 after the new card was added.");
        }

        [TestMethod]
        public void BlackjackHand_SplitTest()
        {
            BlackjackHand hand = new BlackjackHand(10);

            hand.AddCard(MockCards.Eight);
            hand.AddCard(MockCards.Eight);

            ICard splitCard = hand.Split();

            Assert.AreEqual(8, hand.Score, "The hand should now have a score of 8 after splitting.");
            Assert.AreEqual(1, hand.Count, "The hand should now have 1 card after splitting.");

            hand.AddCard(MockCards.King);
            Assert.AreEqual(18, hand.Score, "The hand should now have a score of 18 after the new card was added.");
            Assert.AreEqual(2, hand.Count, "The hand should now have 2 cards after the new card was added.");
        }

        [TestMethod]
        public void BlackjackHand_SuitlessStringTest()
        {
            BlackjackHand hand = new BlackjackHand(10);
            hand.AddCard(MockCards.Eight);
            hand.AddCard(MockCards.Eight);

            Assert.AreEqual("88", hand.SuitlessString, "The hand should have a SuitlessString of '88', but it is '{0}'", hand.SuitlessString);

            hand = new BlackjackHand(10);
            hand.AddCard(MockCards.Nine);
            hand.AddCard(MockCards.Seven);

            Assert.AreEqual("97", hand.SuitlessString, "The hand should have a SuitlessString of '97', but it is '{0}'", hand.SuitlessString);

            hand = new BlackjackHand(10);
            hand.AddCard(MockCards.Ace);
            hand.AddCard(MockCards.Queen);

            Assert.AreEqual("AQ", hand.SuitlessString, "The hand should have a SuitlessString of 'AQ', but it is '{0}'", hand.SuitlessString);

            hand = new BlackjackHand(10);
            hand.AddCard(MockCards.Six);
            hand.AddCard(MockCards.Ace);

            Assert.AreEqual("6A", hand.SuitlessString, "The hand should have a SuitlessString of '6A', but it is '{0}'", hand.SuitlessString);
        }

        [TestMethod]
        public void BlackjackHandCollection_CreationTest()
        {
            BlackjackHandCollection hands = new BlackjackHandCollection();
        }

    }
}
