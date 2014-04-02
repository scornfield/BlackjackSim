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

            hand.AddCard(new CardBase(SuitlessCards.Five, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanDouble(hand), "You should not be able to double this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Clubs));
            Assert.IsTrue(BlackjackRules.CanDouble(hand), "You should be able to double this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Seven, Suits.Hearts));
            Assert.IsFalse(BlackjackRules.CanDouble(hand), "You should not able to double this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_SameCardTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Five, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Five, Suits.Hearts));
            Assert.IsTrue(BlackjackRules.CanSplit(hand), "You should be able to split this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Five, Suits.Spades));
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_SameValueTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.King, Suits.Hearts));
            Assert.IsTrue(BlackjackRules.CanSplit(hand), "You should be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSplit_DifferentCardsTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Seven, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Eight, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanSplit(hand), "You should not be able to split this hand: {0}", hand.ToString());
        }

        [TestMethod]
        public void BlackjackRules_CanSurrenderTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Seven, Suits.Diamonds));
            Assert.IsFalse(BlackjackRules.CanSurrender(hand), "You should not be able to surrender this hand: {0}", hand.ToString());

            hand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Clubs));
            Assert.IsFalse(BlackjackRules.CanSurrender(hand), "You should not be able to surrender this hand: {0}", hand.ToString());
        }
    }
}
