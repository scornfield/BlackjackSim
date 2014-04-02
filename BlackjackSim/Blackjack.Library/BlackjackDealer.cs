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

        public object[] ObjectArray
        {
            get
            {
                object[] objs = new object[8];
                objs[0] = Name;
                objs[1] = 0;
                objs[2] = 0;
                objs[3] = 0;
                objs[4] = Busts;
                objs[5] = 0;
                objs[6] = Blackjacks;
                objs[7] = 0;

                return objs;
            }
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
