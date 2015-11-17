using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Player
    {
        private Deck _playdeck;
        private int _count;
        private string _name;
        private int order = 0;

        public Deck PlayDeck
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public int Order
        {
            get;
            set;
        }

        public Player (int inOrder = 0, string inName = "Anonymous")
        {
            PlayDeck = new Deck();
            Count = 0;
            Name = inName;
            Order = inOrder;
        }

        public void ShowPlayer()
        {
            Console.WriteLine("[" + Name + "] \thas | " + PlayDeck.Cards.Count + " playing card(s) |, | " + Count + " winning card(s) |");
        }
    }

}
