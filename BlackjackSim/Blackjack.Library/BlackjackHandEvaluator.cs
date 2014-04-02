using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    [Flags]
    public enum BlackjackHandFlags
    {
        None = 0,
        Win = 1,
        Lose = 2,
        Push = 4,
        Bust = 8,
        Blackjack = 16,
        Soft = 32,
        Split = 64,
        DoubleDown = 128,
    }

    public static class BlackjackHandEvaluator
    {
        public const int BUST_SCORE = 22;

        public static int CardValue(ICard card)
        {
            if (card.Card == SuitlessCards.King || card.Card == SuitlessCards.Queen || card.Card == SuitlessCards.Jack || card.Card == SuitlessCards.Ten)
                return 10;
            else if (card.Card == SuitlessCards.Ace)
                return 11;
            else if (card.Card == SuitlessCards.Two)
                return 2;
            else if (card.Card == SuitlessCards.Three)
                return 3;
            else if (card.Card == SuitlessCards.Four)
                return 4;
            else if (card.Card == SuitlessCards.Five)
                return 5;
            else if (card.Card == SuitlessCards.Six)
                return 6;
            else if (card.Card == SuitlessCards.Seven)
                return 7;
            else if (card.Card == SuitlessCards.Eight)
                return 8;
            else if (card.Card == SuitlessCards.Nine)
                return 9;
            else
                throw new BlackjackHandEvaluationException(string.Format("Cannot find value for card: %s", card));
        }

        public static int CalculateScore(BlackjackHand hand)
        {
            CardCollection aces = new CardCollection();
            int tScore = 0;

            hand.Flags = BlackjackHandFlags.None;

            foreach (ICard card in hand)
            {
                if (card.Card == SuitlessCards.Ace)
                    aces.Add(card);
                else
                    tScore += CardValue(card);
            }

            foreach (ICard ace in aces)
            {
                if (tScore + 11 >= BUST_SCORE)
                    tScore += 1;
                else
                {
                    tScore += 11;
                    hand.Flags |= BlackjackHandFlags.Soft;
                }
            }

            if (tScore >= BUST_SCORE)
                hand.Flags |= BlackjackHandFlags.Bust;

            if (tScore == 21 && hand.Count() == 2)
                hand.Flags = (hand.Flags ^ BlackjackHandFlags.Soft) | BlackjackHandFlags.Blackjack; // Remove the Soft flag if we have blackjack

            return tScore;
        }

        public static void CompareHands(BlackjackHand playerHand, BlackjackHand dealerHand)
        {
            if (playerHand.Score >= BUST_SCORE)
                // playerHand already has been evaluated for score and knows that it busted
                playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Lose;
            else if (dealerHand.Score > playerHand.Score && dealerHand.Score <= BUST_SCORE)
                // If our score is less than the dealer and the dealer didn't bust, then we lost
                playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Lose;
            else if (playerHand.Score == dealerHand.Score)
            {
                // If our score is equal to the dealer, we pushed
                playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Push;
                if (playerHand.Score == 21 && playerHand.Count() == 2 && dealerHand.Count() == 2)
                    // If we both have Blackjack, set the Blackjack flag too
                    playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Blackjack;
            }
            else if (playerHand.Score == 21 && playerHand.Count() == 2)
                // If our score is 21 and we have two cards, then we got Blackjack!
                playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Blackjack | BlackjackHandFlags.Win;
            else if (dealerHand.Score >= BUST_SCORE || playerHand.Score > dealerHand.Score)
                // If the dealer busted or our score is greater than the dealer, then we won!
                playerHand.Flags = playerHand.Flags | BlackjackHandFlags.Win;
            else 
                throw new BlackjackHandEvaluationException(playerHand, dealerHand);
                // This should never happen.  If we get this error, it means that we didn't cover all of our possible cases above
        }
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    public class BlackjackHandEvaluationException : Exception
    {
        public BlackjackHand PlayerHand { get; set; }
        public BlackjackHand DealerHand { get; set; }

        public BlackjackHandEvaluationException(string message) : base(message) { }

        public BlackjackHandEvaluationException(BlackjackHand pHand, BlackjackHand dHand)
            : this(string.Format("Unexpected outcome when comparing these hands: {0}, {1}", pHand.ToString(), dHand.ToString()))
        {
            PlayerHand = pHand;
            DealerHand = dHand;
        }
    }
}
