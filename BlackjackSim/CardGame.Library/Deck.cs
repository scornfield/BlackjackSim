using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.CardGame.Library
{
    public class Deck : CardCollection
    {
        public Deck() : base() { }

        /// <summary>
        /// Suffles the deck using Fisher-Yates algorithm
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            int n = this.Count;
            while (n > 1)
            {
                int k = rng.Next(n);
                --n;
                CardBase temp = this[n];
                this[n] = this[k];
                this[k] = temp;
            }
        }

        public CardBase Pop()
        {
            CardBase tmp = this[0];
            this.RemoveAt(0);
            return tmp;
        }

        public void AddStandardDeck()
        {
            foreach (SuitlessCardBase card in SuitlessCards.getAllCards())
            {
                foreach (CardSuit suit in Suits.getAllSuits())
                {
                    this.Add(new CardBase(card, suit));
                }
            }
        }

    }
}
