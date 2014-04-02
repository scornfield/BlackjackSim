using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library.Test
{
    [TestClass]
    public class BlackjackDealerTests
    {
        [TestMethod]
        public void BlackjackDealer_CreationTest()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            Assert.AreEqual("Dealer", dealer.Name, "The dealer's name should be 'Dealer'.");
            Assert.AreEqual(0, dealer.Bet, "The dealer's bet should be 0.");
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "The PlaceBet method shouldn't be implemented in the BlackjackDealer")]
        public void BlackjackDealer_PlaceBetTest()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            double bet = dealer.PlaceBet(100);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "The standard play with input parameters method shouldn't be implemented in the BlackjackDealer")]
        public void BlackjackDealer_StandardPlayTest()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            BlackjackActions a = dealer.Play(new BlackjackHand(0), new BlackjackTableInfo(8));
        }

        [TestMethod]
        public void BlackjackDealer_Play_Under17Test()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            dealer.Hand.AddCard(MockCards.Five);
            dealer.Hand.AddCard(MockCards.Five);
            BlackjackActions action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Hit, action, "The dealer should always hit on anything under 17.");

            dealer.Hand.Clear();
            dealer.Hand.AddCard(MockCards.Six);
            dealer.Hand.AddCard(MockCards.Ten);
            action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Hit, action, "The dealer should always hit on anything under 17.");
        }

        [TestMethod]
        public void BlackjackDealer_Play_Over17Test()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            dealer.Hand.AddCard(MockCards.King);
            dealer.Hand.AddCard(MockCards.Eight);
            BlackjackActions action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Stand, action, "The dealer should always stand on anything over 17.");

            dealer.Hand.Clear();
            dealer.Hand.AddCard(MockCards.Eight);
            dealer.Hand.AddCard(MockCards.Ace);
            action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Stand, action, "The dealer should always stand on anything over 17.");
        }

        [TestMethod]
        public void BlackjackDealer_Play_17Test()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            dealer.Hand.AddCard(MockCards.Ace);
            dealer.Hand.AddCard(MockCards.Six);
            BlackjackActions action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Hit, action, "The dealer should hit on a soft 17.");

            dealer.Hand.Clear();
            dealer.Hand.AddCard(MockCards.Jack);
            dealer.Hand.AddCard(MockCards.Seven);
            action = dealer.Play();
            Assert.AreEqual(BlackjackActions.Stand, action, "The dealer should stand on a hard 17.");
        }

        [TestMethod]
        public void BlackjackDealer_VisibleCardTest()
        {
            BlackjackDealer dealer = new BlackjackDealer();

            dealer.Hand.AddCard(new CardBase(SuitlessCards.Ace, Suits.Diamonds));
            dealer.Hand.AddCard(new CardBase(SuitlessCards.Six, Suits.Spades));
            Assert.AreEqual(new CardBase(SuitlessCards.Six, Suits.Spades), dealer.VisibleCard, "The dealer's second card should be visible to the player.");
        }
    }
}
