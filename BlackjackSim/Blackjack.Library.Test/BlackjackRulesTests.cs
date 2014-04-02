using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackRulesTests
    {
        [TestMethod]
        public void BlackjackRules_CanDoubleTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Five);
            Assert.IsFalse(BlackjackRules.CanDouble(hand), "You should not be able to double this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Six);
            Assert.IsTrue(BlackjackRules.CanDouble(hand), "You should be able to double this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Seven);
            Assert.IsFalse(BlackjackRules.CanDouble(hand), "You should not able to double this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_SameCardTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Five);
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Five);
            Assert.IsTrue(BlackjackRules.CanSplit(hand), "You should be able to split this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Five);
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_SameValueTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Ten);
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.King);
            Assert.IsTrue(BlackjackRules.CanSplit(hand), "You should be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_DifferentCardsTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Seven);
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Eight);
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSurrenderTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Seven);
            Assert.IsFalse(BlackjackRules.CanSurrender(hand), "You should not be able to surrender this hand: {0}", hand.ToString());

            hand.AddCard(MockCards.Nine);
            Assert.IsFalse(BlackjackRules.CanSurrender(hand), "You should not be able to surrender this hand: {0}", hand.ToString());
        }
    }
}
