using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Deck
    {
        public List<Card> Cards;


        public Deck()
        {
            Cards = new List<Card>();
        }

        public Deck(int inValue = 13, int inSuit = 4) : this()
        {

            for (int i = 0; i < inValue; i++)
            {
                for (int j = 0; j < inSuit; j++)
                {
                    Cards.Add(new Card { Value = i + 1, Suit = j + 1 });
                 }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

        public void ViewCardsinDeck()
        {
            foreach (Card p1Card in this.Cards)
            {
                Console.WriteLine(p1Card);
            }
        }
    }
}
