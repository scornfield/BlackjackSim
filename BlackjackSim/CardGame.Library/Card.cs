using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cornfield.CardGame.Library
{
    public class CardBase
    {
        public CardSuit Suit { get; private set;  }
        public SuitlessCardBase Card { get; private set; }

        public CardBase(SuitlessCardBase inCard, CardSuit inSuit)
        {
            Card = inCard;
            Suit = inSuit;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", Card, Suit);
        }

        /* Code for Comparisons */
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(CardBase a, CardBase b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Card == b.Card && a.Suit == b.Suit;
        }

        public static bool operator !=(CardBase a, CardBase b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast, return false:
            CardBase card = obj as CardBase;
            if ((object)card == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Card == card.Card && Suit == card.Suit;
        }
    }

    /// <summary>
    /// A card with no suit
    /// </summary>
    public class SuitlessCardBase
    {
        public string Abbrev { get; private set; }
        public string Name { get; private set; }

        public SuitlessCardBase(string inAbbrev, string inName)
        {
            Abbrev = inAbbrev;
            Name = inName;
        }

        public override string ToString()
        {
            return Abbrev;
        }

        /* Code for comparisons */
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(SuitlessCardBase a, SuitlessCardBase b)
        {
            if (System.Object.ReferenceEquals(a, b))
                return true;

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return a.Abbrev == b.Abbrev && a.Name == b.Name;
        }

        public static bool operator !=(SuitlessCardBase a, SuitlessCardBase b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            // If parameter cannot be cast, return false:
            SuitlessCardBase card = obj as SuitlessCardBase;
            if ((object)card == null)
            {
                return false;
            }

            // Return true if the fields match:
            return Abbrev == card.Abbrev && Name == card.Name;
        }
    }

    public static class SuitlessCards
    {
        public static System.Collections.ObjectModel.Collection<SuitlessCardBase> getAllCards()
        {
            System.Collections.ObjectModel.Collection<SuitlessCardBase> cardList = new System.Collections.ObjectModel.Collection<SuitlessCardBase>();
            cardList.Add(Ace);
            cardList.Add(Two);
            cardList.Add(Three);
            cardList.Add(Four);
            cardList.Add(Five);
            cardList.Add(Six);
            cardList.Add(Seven);
            cardList.Add(Eight);
            cardList.Add(Nine);
            cardList.Add(Ten);
            cardList.Add(Jack);
            cardList.Add(Queen);
            cardList.Add(King);

            return cardList;
        }

        public static readonly SuitlessCardBase Ace = new SuitlessCardBase("A", "Ace");
        public static readonly SuitlessCardBase Two = new SuitlessCardBase("2", "Two");
        public static readonly SuitlessCardBase Three = new SuitlessCardBase("3", "Three");
        public static readonly SuitlessCardBase Four = new SuitlessCardBase("4", "Four");
        public static readonly SuitlessCardBase Five = new SuitlessCardBase("5", "Five");
        public static readonly SuitlessCardBase Six = new SuitlessCardBase("6", "Six");
        public static readonly SuitlessCardBase Seven = new SuitlessCardBase("7", "Seven");
        public static readonly SuitlessCardBase Eight = new SuitlessCardBase("8", "Eight");
        public static readonly SuitlessCardBase Nine = new SuitlessCardBase("9", "Nine");
        public static readonly SuitlessCardBase Ten = new SuitlessCardBase("10", "Ten");
        public static readonly SuitlessCardBase Jack = new SuitlessCardBase("J", "Jack");
        public static readonly SuitlessCardBase Queen = new SuitlessCardBase("Q", "Queen");
        public static readonly SuitlessCardBase King = new SuitlessCardBase("K", "King");

    }
}
