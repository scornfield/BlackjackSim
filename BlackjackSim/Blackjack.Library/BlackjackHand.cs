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

        public void AddCard(CardBase inCard)
        {
            Add(inCard);
            calcScore();
        }

        #region Actions
        
        public void Hit(CardBase inCard)
        {
            AddCard(inCard);
        }

        public void DoubleDown(CardBase inCard)
        {
            Bet *= 2;
            AddCard(inCard);
        }

        public CardBase Split()
        {
            CardBase tmp = this[0];
            RemoveAt(0);
            calcScore();
            return tmp;
        }
        
        #endregion

        private void calcScore()
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
