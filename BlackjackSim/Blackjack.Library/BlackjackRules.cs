using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.Blackjack.Library
{
    public static class BlackjackRules
    {
        public static bool CanSplit(BlackjackHand hand)
        {
            if (hand.Count() != 2)
                return false;

            if(BlackjackHandEvaluator.CardValue(hand[0]) != BlackjackHandEvaluator.CardValue(hand[1]))
                return false;

            return true;
        }

        public static bool CanDouble(BlackjackHand hand)
        {
            if (hand.Count() != 2)
                return false;

            return true;
        }

        public static bool CanSurrender(BlackjackHand hand)
        {
            return false;
        }
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute]
    public class BlackjackRulesViolationException : Exception
    {
        public BlackjackHand Hand { get; set; }
        public BlackjackActions Action { get; set; }

        public BlackjackRulesViolationException(string message) : base(message) { }

        public BlackjackRulesViolationException(BlackjackHand hand, BlackjackActions action)
            : this(string.Format("You cannot {0} this hand: {1}", action.ToString(), hand.ToString()))
        {
            Hand = hand;
            Action = action;
        }
    }
}
