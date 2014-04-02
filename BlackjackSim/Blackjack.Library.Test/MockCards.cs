using Cornfield.CardGame.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Cornfield.Blackjack.Library.Test
{
    public static class MockCards
    {
        public static ICard Ace
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Ace);
                return card.Object;
            }
        }

        public static ICard Two
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Two);
                return card.Object;
            }
        }

        public static ICard Three
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Three);
                return card.Object;
            }
        }

        public static ICard Four
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Four);
                return card.Object;
            }
        }

        public static ICard Five
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Five);
                return card.Object;
            }
        }

        public static ICard Six
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Six);
                return card.Object;
            }
        }

        public static ICard Seven
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Seven);
                return card.Object;
            }
        }

        public static ICard Eight
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Eight);
                return card.Object;
            }
        }

        public static ICard Nine
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Nine);
                return card.Object;
            }
        }

        public static ICard Ten
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Ten);
                return card.Object;
            }
        }

        public static ICard Jack
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Jack);
                return card.Object;
            }
        }

        public static ICard Queen
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.Queen);
                return card.Object;
            }
        }

        public static ICard King
        {
            get
            {
                Mock<ICard> card = new Mock<ICard>();
                card.Setup(framework => framework.Card).Returns(SuitlessCards.King);
                return card.Object;
            }
        }
    }
}
