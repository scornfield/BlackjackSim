using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    public sealed class BlackjackDealer : BlackjackPlayerBase, IBlackjackOutcomeCounter
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Busts { get; set; }
        public int Pushes { get; set; }
        public int Blackjacks { get; set; }
        public Dictionary<string, object> OtherInfo { get; set; }

        public BlackjackHand Hand { get; private set; }

        public BlackjackDealer() : base("Dealer", 0)
        {
            Hand = new BlackjackHand(0);
        }

        public sealed override double PlaceBet(double inChips)
        {
            throw new NotImplementedException("The dealer should never place a bet.");
        }
        
        public BlackjackActions Play()
        {
            if (Hand.Score <= 16 || (Hand.Score == 17 && Hand.Flags.HasFlag(BlackjackHandFlags.Soft)))
                return BlackjackActions.Hit;
            else
                return BlackjackActions.Stand;
        }

        public ICard VisibleCard
        {
            get
            {
                return Hand[1];
            }
        }
    }
}
