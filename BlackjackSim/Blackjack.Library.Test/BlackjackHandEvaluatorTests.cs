using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;
using Moq;
using System.Collections.Generic;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackHandEvaluatorTests
    {
        [TestMethod]
        public void BlackjackHandEvaluator_CardValuesTest()
        {
            Mock<ICard> card = new Mock<ICard>();
            
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Ace);
            Assert.AreEqual(11, BlackjackHandEvaluator.CardValue(card.Object),  "Aces should be worth 11 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Two);
            Assert.AreEqual(2, BlackjackHandEvaluator.CardValue(card.Object), "Twos should be worth 2 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Three);
            Assert.AreEqual(3, BlackjackHandEvaluator.CardValue(card.Object), "Threes should be worth 3 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Four);
            Assert.AreEqual(4, BlackjackHandEvaluator.CardValue(card.Object), "Fours should be worth 4 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Five);
            Assert.AreEqual(5, BlackjackHandEvaluator.CardValue(card.Object), "Fives should be worth 5 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Six);
            Assert.AreEqual(6, BlackjackHandEvaluator.CardValue(card.Object), "Aces should be worth 6 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Seven);
            Assert.AreEqual(7, BlackjackHandEvaluator.CardValue(card.Object), "Sevens should be worth 7 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Eight);
            Assert.AreEqual(8, BlackjackHandEvaluator.CardValue(card.Object), "Eights should be worth 8 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Nine);
            Assert.AreEqual(9, BlackjackHandEvaluator.CardValue(card.Object), "Nines should be worth 9 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Ten);
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(card.Object), "Tens should be worth 10 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Jack);
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(card.Object), "Jacks should be worth 10 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.Queen);
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(card.Object), "Queens should be worth 10 points.");
            card.Setup(framework => framework.Card).Returns(SuitlessCards.King);
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(card.Object), "Kings should be worth 10 points.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BasicTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Five);
            hand.AddCard(MockCards.Six);
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(11, score, "Expected Score to be 11, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.None, hand.Flags, "This hand should not have any outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BlackjackTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Ace);
            hand.AddCard(MockCards.Jack);
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(21, score, "Expected Score to be 21, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.Blackjack, hand.Flags, "This hand should have the Blackjack outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_SoftAceTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Ace);
            hand.AddCard(MockCards.Six);
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(17, score, "Expected Score to be 17, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.Soft, hand.Flags, "This hand should have the Soft outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_HardAceTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Ace);
            hand.AddCard(MockCards.Six);
            hand.AddCard(MockCards.Eight);
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(15, score, "Expected Score to be 15, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.None, hand.Flags, "This hand should not have any outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BustTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(MockCards.Ace);
            hand.AddCard(MockCards.Six);
            hand.AddCard(MockCards.Eight);
            hand.AddCard(MockCards.King);
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(25, score, "Expected Score to be 25, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.Bust, hand.Flags, "This hand should have the Bust outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerBustTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0); // Dealer's cards don't matter for this test

            pHand.AddCard(MockCards.Ace);
            pHand.AddCard(MockCards.Six);
            pHand.AddCard(MockCards.Eight);
            pHand.AddCard(MockCards.King);

            Assert.AreEqual(25, pHand.Score, "Expected player's Score to be 25, got {0}.", pHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Bust | BlackjackHandFlags.Lose, pHand.Flags, "The player's hand should have the Bust and Lose outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerLoseTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(MockCards.Ace);
            pHand.AddCard(MockCards.Seven);

            dHand.AddCard(MockCards.Ten);
            dHand.AddCard(MockCards.Nine);

            Assert.AreEqual(18, pHand.Score, "Expected player's Score to be 18, got {0}.", pHand.Score);
            Assert.AreEqual(19, dHand.Score, "Expected dealer's Score to be 19, got {0}.", dHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Lose | BlackjackHandFlags.Soft, pHand.Flags, "The player's hand should have the Lose and Soft outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PushTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(MockCards.Ten);
            pHand.AddCard(MockCards.Nine);

            dHand.AddCard(MockCards.Queen);
            dHand.AddCard(MockCards.Nine);

            Assert.AreEqual(19, pHand.Score, "Expected player's Score to be 19, got {0}.", pHand.Score);
            Assert.AreEqual(19, dHand.Score, "Expected dealer's Score to be 19, got {0}.", dHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Push, pHand.Flags, "The player's hand should only have the Push outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_BlackjackPushTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(MockCards.Ten);
            pHand.AddCard(MockCards.Ace);

            dHand.AddCard(MockCards.Ace);
            dHand.AddCard(MockCards.Queen);

            Assert.AreEqual(21, pHand.Score, "Expected player's Score to be 21, got {0}.", pHand.Score);
            Assert.AreEqual(21, dHand.Score, "Expected dealer's Score to be 21, got {0}.", dHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Push | BlackjackHandFlags.Blackjack, pHand.Flags, "The player's hand should have the Push and Blackjack outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerBlackjackTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0); // Dealer's cards don't matter for this test

            pHand.AddCard(MockCards.Ten);
            pHand.AddCard(MockCards.Ace);

            dHand.AddCard(MockCards.Nine);
            dHand.AddCard(MockCards.Queen);

            Assert.AreEqual(21, pHand.Score, "Expected player's Score to be 21, got {0}.", pHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Blackjack | BlackjackHandFlags.Win, pHand.Flags, "The player's hand should have the Blackjack and Win outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerWinTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(MockCards.Ten);
            pHand.AddCard(MockCards.Nine);

            dHand.AddCard(MockCards.Six);
            dHand.AddCard(MockCards.Nine);
            dHand.AddCard(MockCards.Two);


            Assert.AreEqual(19, pHand.Score, "Expected player's Score to be 19, got {0}.", pHand.Score);
            Assert.AreEqual(17, dHand.Score, "Expected dealer's Score to be 17, got {0}.", dHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Win, pHand.Flags, "The player's hand should only have the Win outcome flag set.");
        }
    }
}
