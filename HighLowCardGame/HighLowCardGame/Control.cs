using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Control
    {
        static Deck base_deck;

        public static void SettingUp()
        {
            Console.WriteLine("High-Low Card Game");
            Console.WriteLine("Game set up...");
            base_deck = new Deck(13, 4);
            base_deck.Shuffle();
            //base_deck.ViewCardsinDeck();
            Console.WriteLine("Game ready...");
        }
        public static void NewPlayers(Player pPlayer1, Player pPlayer2, string pPlayerName1 = "Anonymous", string pPlayerName2 = "Anonymous")
        {
            Console.WriteLine("Creating new two players...");
            Console.WriteLine(" ");
            Console.Write("[" + pPlayer1.Name + "] Enter name of player 1 : ");
            pPlayerName1 = Console.ReadLine();
            Console.Write("[" + pPlayer2.Name + "] Enter name of player 2 : ");
            pPlayerName2 = Console.ReadLine();
            pPlayer1.Name = pPlayerName1;
            pPlayer2.Name = pPlayerName2;
            Console.WriteLine("[" + pPlayer1.Name + "] is " + pPlayer1.Name);
            Console.WriteLine("[" + pPlayer2.Name + "] is " + pPlayer2.Name);
        }
        public static void GivePlayerADeck(Player pPlayer1, Player pPlayer2)
        {
            for (int i = 0; i < 26; i++)
            {
                pPlayer1.PlayDeck.Cards.Add(base_deck.Cards[i]);
            }
            for (int i = 0; i < 26; i++)
            {
                pPlayer2.PlayDeck.Cards.Add(base_deck.Cards[i + 26]);
            }
            Console.WriteLine("[Control] Two players card deck are each equal to the number of cards");
        }

        public static void PlayerWinTurn(Player pPlayer, int NumberofCards = 1)
        {
            pPlayer.Count += (NumberofCards) * 2;
            //Console.WriteLine("[WIN][Player " + pPlayer.Order + "] get 2 card into his/her pile");
            Console.WriteLine("[WIN][" + pPlayer.Name + "] get 2 card into his/her pile");
        }
        public static void TieTurn(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("[Tie] Reshuffle the both players card deck");
            pPlayer1.PlayDeck.Shuffle();
            //if (pPlayer1.PlayDeck.Cards.Count != 2)
            {
                pPlayer2.PlayDeck.Shuffle();
            }
        }

        public static void RemovePlayerCards(Player pPlayer1, Player pPlayer2, int range)
        {
            int LastCard = pPlayer1.PlayDeck.Cards.Count - 1;
            pPlayer1.PlayDeck.Cards.RemoveRange(LastCard - range + 1, range);
            pPlayer2.PlayDeck.Cards.RemoveRange(LastCard - range + 1, range);
            //Console.WriteLine("[Remove] " + range + " card(s) of both players card deck");
        }

        public static int CompareCardDeck(Player pPlayer1, Player pPlayer2)
        {
            if (pPlayer1.PlayDeck.Cards.Count == 0) // No longer be playing
            {
                Console.WriteLine("[Summary] No more card left in the both players card deck");
                return -1;
            }
            int LastCard = pPlayer1.PlayDeck.Cards.Count - 1;
            int pPlayer1_last = pPlayer1.PlayDeck.Cards[LastCard].Value;
            int pPlayer2_last = pPlayer2.PlayDeck.Cards[LastCard].Value;
            Console.WriteLine("[" + pPlayer1.Name + "] \thas " + pPlayer1.PlayDeck.Cards[LastCard]);
            Console.WriteLine("[" + pPlayer2.Name + "] \thas " + pPlayer2.PlayDeck.Cards[LastCard]);
            if (pPlayer1.PlayDeck.Cards.Count == 1 && pPlayer1.PlayDeck.Cards[LastCard].Value == pPlayer2.PlayDeck.Cards[LastCard].Value) // No longer be playing
            {
                Console.WriteLine("[Tie] The last card of both players is the same.");
                return -1;
            }
            if (pPlayer1_last == pPlayer2_last)
            {
                bool Continue_Game = true;
                for (int i = 0; i <= LastCard; i++)
                {
                    for (int j = 0; j <= LastCard; j++)
                    {
                        if (pPlayer1.PlayDeck.Cards[i].Value > pPlayer2.PlayDeck.Cards[j].Value)
                        {
                            Continue_Game = false;
                        }
                        else
                        {
                            Continue_Game = true;
                        }
                    }
                }
                if (!Continue_Game)
                {
                    Console.WriteLine("== [" + pPlayer1.Name + "] Card deck is containing these cards :");
                    pPlayer1.PlayDeck.ViewCardsinDeck();
                    Console.WriteLine("== [" + pPlayer2.Name + "] Card deck is containing these cards :");
                    pPlayer2.PlayDeck.ViewCardsinDeck();
                    return -1;
                }
                int NumberFromLastCard = pPlayer1_last;
                if (NumberFromLastCard > LastCard) // More value of the card than number of left cards
                {
                    TieTurn(pPlayer1, pPlayer2);
                    //Console.WriteLine("== [" + pPlayer1.Name + "] Card deck is containing these cards :");
                    //pPlayer1.PlayDeck.ViewCardsinDeck();
                    //Console.WriteLine("== [" + pPlayer2.Name + "] Card deck is containing these cards :");
                    //pPlayer2.PlayDeck.ViewCardsinDeck();
                    //Console.ReadKey();
                    return 0;
                }
                Console.WriteLine("[" + pPlayer1.Name + "] has " + pPlayer1.PlayDeck.Cards[NumberFromLastCard]);
                Console.WriteLine("[" + pPlayer2.Name + "] has " + pPlayer2.PlayDeck.Cards[NumberFromLastCard]);
                int pPlayer1_fromlast = pPlayer1.PlayDeck.Cards[NumberFromLastCard].Value;
                int pPlayer2_fromlast = pPlayer2.PlayDeck.Cards[NumberFromLastCard].Value;
                if (pPlayer1_fromlast < pPlayer2_fromlast) // Player 1 WIN
                {
                    PlayerWinTurn(pPlayer1, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 1;
                }
                else if (pPlayer1_fromlast > pPlayer2_fromlast) // Player 2 WIN
                {
                    PlayerWinTurn(pPlayer2, NumberFromLastCard);
                    RemovePlayerCards(pPlayer1, pPlayer2, NumberFromLastCard);
                    return 2;
                }
                else // Tie
                {
                    TieTurn(pPlayer1, pPlayer2);
                    return 0;
                }
            }
            // Player 1 WIN
            else if (pPlayer1_last < pPlayer2_last)
            {
                PlayerWinTurn(pPlayer1);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 1;
            }
            // Player 2 WIN
            else if (pPlayer1_last > pPlayer2_last)
            {
                PlayerWinTurn(pPlayer2);
                RemovePlayerCards(pPlayer1, pPlayer2, 1);
                return 2;
            }
            return -1;
        }

        public static void FinishedPlaying(Player pPlayer1, Player pPlayer2)
        {
            Console.WriteLine("");
            Console.WriteLine("=== [ " + (pPlayer1.Count > pPlayer2.Count ? pPlayer1.Name : pPlayer2.Name) + " Win ] ===");
        }
    }
}
