using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Card
    {
        private int _value;
        private int _suit;
        

        public int Value
        {
            get;
            set;
        }

        public int Suit
        {
            get;
            set;
        }

        public override string ToString()
        {
            return face[Value - 1]  + suit[Suit - 1] ;
        }

        public Card()
        {
            Value = 0;
            Suit = 0;
        }

        protected string[] suit = { "♣", "♦", "♥", "♠" };
        protected string[] face = { " 1", " 2", " 3", " 4", " 5", " 6", " 7", " 8", " 9", "10", " J", " Q", " K" };

    }
}
