using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackHandEvaluatorTests
    {
        [TestMethod]
        public void BlackjackHandEvaluator_CardValuesTest()
        {
            Assert.AreEqual(11, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Ace, Suits.Spades)),  "Aces should be worth 11 points.");
            Assert.AreEqual(2, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Two, Suits.Spades)), "Twos should be worth 2 points.");
            Assert.AreEqual(3, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Three, Suits.Spades)), "Threes should be worth 3 points.");
            Assert.AreEqual(4, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Four, Suits.Spades)), "Fours should be worth 4 points.");
            Assert.AreEqual(5, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Five, Suits.Spades)), "Fives should be worth 5 points.");
            Assert.AreEqual(6, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Six, Suits.Spades)), "Aces should be worth 6 points.");
            Assert.AreEqual(7, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Seven, Suits.Spades)), "Sevens should be worth 7 points.");
            Assert.AreEqual(8, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Eight, Suits.Spades)), "Eights should be worth 8 points.");
            Assert.AreEqual(9, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Nine, Suits.Spades)),"Nines should be worth 9 points.");
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Ten, Suits.Spades)),  "Tens should be worth 10 points.");
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Jack, Suits.Spades)), "Jacks should be worth 10 points.");
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.Queen, Suits.Spades)), "Queens should be worth 10 points.");
            Assert.AreEqual(10, BlackjackHandEvaluator.CardValue(new CardBase(SuitlessCards.King, Suits.Spades)), "Kings should be worth 10 points.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BasicTest()
        {
            BlackjackHand hand = new BlackjackHand(0);
            
            hand.AddCard(new CardBase(SuitlessCards.Five, Suits.Diamonds));
            hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Spades));
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(11, score, "Expected Score to be 11, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.None, hand.Flags, "This hand should not have any outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BlackjackTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            hand.AddCard(new CardBase(SuitlessCards.Jack, Suits.Clubs));
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(21, score, "Expected Score to be 21, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.Blackjack, hand.Flags, "This hand should have the Blackjack outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_SoftAceTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Clubs));
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(17, score, "Expected Score to be 17, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.Soft, hand.Flags, "This hand should have the Soft outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_HardAceTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Clubs));
            hand.AddCard(new CardBase(SuitlessCards.Eight, Suits.Hearts));
            int score = BlackjackHandEvaluator.CalculateScore(hand);

            Assert.AreEqual(hand.Score, score, "Hand's saved Score should equal Calculated Score.");
            Assert.AreEqual(15, score, "Expected Score to be 15, got {0}.", score);
            Assert.AreEqual(BlackjackHandFlags.None, hand.Flags, "This hand should not have any outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CalculateScore_BustTest()
        {
            BlackjackHand hand = new BlackjackHand(0);

            hand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Clubs));
            hand.AddCard(new CardBase(SuitlessCards.Eight, Suits.Hearts));
            hand.AddCard(new CardBase(SuitlessCards.King, Suits.Spades));
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

            pHand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Six, Suits.Clubs));
            pHand.AddCard(new CardBase(SuitlessCards.Eight, Suits.Hearts));
            pHand.AddCard(new CardBase(SuitlessCards.King, Suits.Spades));

            Assert.AreEqual(25, pHand.Score, "Expected player's Score to be 25, got {0}.", pHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Bust | BlackjackHandFlags.Lose, pHand.Flags, "The player's hand should have the Bust and Lose outcome flags set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerLoseTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Seven, Suits.Clubs));

            dHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            dHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Clubs));

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

            pHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Clubs));

            dHand.AddCard(new CardBase(SuitlessCards.Queen, Suits.Hearts));
            dHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Spades));

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

            pHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Clubs));

            dHand.AddCard(new CardBase(SuitlessCards.Queen, Suits.Hearts));
            dHand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Spades));

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

            pHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Clubs));

            dHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            dHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Clubs));

            Assert.AreEqual(21, pHand.Score, "Expected player's Score to be 21, got {0}.", pHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Blackjack | BlackjackHandFlags.Win, pHand.Flags, "The player's hand should have the Blackjack and Win outcome flag set.");
        }

        [TestMethod]
        public void BlackjackHandEvaluator_CompareHands_PlayerWinTest()
        {
            BlackjackHand pHand = new BlackjackHand(0);
            BlackjackHand dHand = new BlackjackHand(0);

            pHand.AddCard(new CardBase(SuitlessCards.Ten, Suits.Diamonds));
            pHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Clubs));

            dHand.AddCard(new CardBase(SuitlessCards.Six, Suits.Hearts));
            dHand.AddCard(new CardBase(SuitlessCards.Nine, Suits.Spades));
            dHand.AddCard(new CardBase(SuitlessCards.Two, Suits.Spades));

            Assert.AreEqual(19, pHand.Score, "Expected player's Score to be 19, got {0}.", pHand.Score);
            Assert.AreEqual(17, dHand.Score, "Expected dealer's Score to be 17, got {0}.", dHand.Score);

            BlackjackHandEvaluator.CompareHands(pHand, dHand);

            Assert.AreEqual(BlackjackHandFlags.Win, pHand.Flags, "The player's hand should only have the Win outcome flag set.");
        }
    }
}
