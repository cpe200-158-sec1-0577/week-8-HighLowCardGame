using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_Low_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {

                Player player1 = new Player(1);
                Player player2 = new Player(2);
                Control.SettingUp();
                Control.NewPlayers(player1, player2);
                Control.GivePlayerADeck(player1, player2);

                // Display all cards in both player decks
                Console.WriteLine("== [" + player1.Name + "] Card deck is containing these cards :");
                player1.PlayDeck.ViewCardsinDeck();
                Console.WriteLine("== [" + player2.Name + "] Card deck is containing these cards :");
                player2.PlayDeck.ViewCardsinDeck();

                Console.WriteLine("");
                Console.WriteLine("> STARTING GAME <");

                int result = 0;
                int turn = 1;
                do
                {
                    Console.WriteLine("___ {Turn " + turn + " } ___ ");
                    //Console.WriteLine("Comparing player 1 and player 2 card deck");
                    result = Control.CompareCardDeck(player1, player2);
                    player1.ShowPlayer();
                    player2.ShowPlayer();
                    if (player1.PlayDeck.Cards.Count == 0)
                    {
                        Console.WriteLine("[Summary] No more card left in the both players card deck");
                        break;
                    }
                    Console.WriteLine("");
                    ++turn;
                    Console.ReadKey();
                } while (result != -1);
                Control.FinishedPlaying(player1, player2);
                Console.ReadKey();
            }
        }
    }

