using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cornfield.CardGame.Library;

namespace Cornfield.Blackjack.Library
{
    public class BlackjackHand : CardCollection
    {
        public BlackjackActions Action { get; protected set; }
        public double Bet { get; protected set; }
        public int Score { get; private set; }

        public BlackjackHand(double inBet) : base() 
        {
            Bet = inBet;
        }

        public BlackjackHandFlags Flags { get; set; }

        public void DealCard(ICard inCard)
        {
            Add(inCard);
        }
        
        public void AddCard(ICard inCard)
        {
            Add(inCard);
            CalculateScore();
        }

        #region Actions
        
        public void Hit(ICard inCard)
        {
            AddCard(inCard);
        }

        public void DoubleDown(ICard inCard)
        {
            Bet *= 2;
            AddCard(inCard);
        }

        public ICard Split()
        {
            ICard tmp = this[0];
            RemoveAt(0);
            CalculateScore();
            return tmp;
        }
        
        #endregion

        public void CalculateScore()
        {
            Score = BlackjackHandEvaluator.CalculateScore(this);
        }

        public new void Clear()
        {
            Flags = BlackjackHandFlags.None;
            base.Clear();
        }

        public string SuitlessString 
        {
            get
            {
                return string.Join("", this.Select((card) => card.Card.ToString()));
            }
        }
    }

    public class BlackjackHandCollection : System.Collections.ObjectModel.Collection<BlackjackHand>
    {
        public BlackjackHandCollection() : base()
        {

        }
    }
}
