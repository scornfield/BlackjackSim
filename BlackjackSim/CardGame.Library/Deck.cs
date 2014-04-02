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
                ICard temp = this[n];
                this[n] = this[k];
                this[k] = temp;
            }
        }

        public ICard Pop()
        {
            ICard tmp = this[0];
            this.RemoveAt(0);
            return tmp;
        }

        public void AddStandardDeck()
        {
            System.Collections.ObjectModel.Collection<SuitlessCardBase> cards = SuitlessCards.getAllCards();
            System.Collections.ObjectModel.Collection<CardSuit> suits = Suits.getAllSuits();

            foreach (SuitlessCardBase card in cards)
            {
                foreach (CardSuit suit in suits)
                {
                    this.Add(new CardBase(card, suit));
                }
            }
        }

    }
}
