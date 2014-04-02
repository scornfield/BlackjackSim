using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.Blackjack.Library;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Players
{
    public class StevePlayer : BlackjackPlayerBase
    {
        public StevePlayer(string inName, double inBet = 10) : base(inName, inBet) { }

        public override BlackjackActions Play(BlackjackHand hand, BlackjackTableInfo info)
        {
            List<string> lowSplitHands = new List<string>();
            lowSplitHands.Add("22");
            lowSplitHands.Add("33");
            lowSplitHands.Add("66");
            lowSplitHands.Add("77");
            lowSplitHands.Add("99");
            lowSplitHands.Add("88");
            lowSplitHands.Add("AA");

            List<string> highSplitHands = new List<string>();
            lowSplitHands.Add("88");
            lowSplitHands.Add("AA");

            // Double down logic:
            //  If we have a 9.
            //  If we have a 10 or 11 and that's better than the dealer's up card.
            //  If we have a soft 16-18.
            if (BlackjackRules.CanDouble(hand))
            {
                if (hand.Score == 9)
                    return BlackjackActions.DoubleDown;
                if ((Enumerable.Range(10, 2).Contains(hand.Score) && hand.Score > BlackjackHandEvaluator.CardValue(info.DealerUpCard)))
                    return BlackjackActions.DoubleDown;
                if ((Enumerable.Range(16, 3).Contains(hand.Score) && hand.Flags.HasFlag(BlackjackHandFlags.Soft)))
                    return BlackjackActions.DoubleDown;
            }

            // Split logic:
            //  If we have an 88 or AA against anything.
            //  If we have 22, 33, 66, 77, 99 against a 2-6.
            if (BlackjackRules.CanSplit(hand))
            {
                if (highSplitHands.Contains(hand.SuitlessString))
                    return BlackjackActions.Split;
                if (lowSplitHands.Contains(hand.SuitlessString) && Enumerable.Range(2, 6).Contains(BlackjackHandEvaluator.CardValue(info.DealerUpCard)))
                    return BlackjackActions.Split;
            }

            // Hit Logic:
            //  If we got to this point (didn't want to/couldn't double or split) and we have 16 or less.
            if (hand.Score <= 16)
                return BlackjackActions.Hit;

            return BlackjackActions.Stand;

        }

    }
}
