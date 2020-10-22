using System;
using System.Collections.Generic;
using static System.Console;


namespace ConsoleApp1
{
   class Program
    {

        class Karta
        {

            public string _suit { set; get; }
            public string _namecard { set; get; }


            public Karta(string _suit, string _namecard)
            {
                this._suit = _suit;
                this._namecard = _namecard;

            }

            public override string ToString()
            {
                return $"{_suit}:{_namecard}";
            }

        }

        class Player
        {
            string _nameplayer { get; set; }
            public List<Karta> card = new List<Karta>();

            public Player(string _nameplayer, Karta[] _card)
            {
                this._nameplayer = _nameplayer;

                for(int i = 0; i < _card.Length; i++)
                {
                    card.Add(_card[i]);
                }
            }
        }

        class Game
        {
            public Player player1;
            public Player player2;

             Karta[] deck = new Karta[]
        {
            new Karta("Heart", "6"),
            new Karta("Heart", "7"),
            new Karta("Heart", "8"),
            new Karta("Heart", "9"),
            new Karta("Heart", "10"),
            new Karta("Heart", "Jack"),
            new Karta("Heart", "Queen"),
            new Karta("Heart", "King"),
            new Karta("Heart", "Ace"),
            new Karta("Diamond", "6"),
            new Karta("Diamond", "7"),
            new Karta("Diamond", "8"),
            new Karta("Diamond", "9"),
            new Karta("Diamond", "10"),
            new Karta("Diamond", "Jack"),
            new Karta("Diamond", "Queen"),
            new Karta("Diamond", "King"),
            new Karta("Diamond", "Ace"),
            new Karta("Club", "6"),
            new Karta("Club", "7"),
            new Karta("Club", "8"),
            new Karta("Club", "9"),
            new Karta("Club", "10"),
            new Karta("Club", "Jack"),
            new Karta("Club", "Queen"),
            new Karta("Club", "King"),
            new Karta("Club", "Ace"),
            new Karta("Spade", "6"),
            new Karta("Spade", "7"),
            new Karta("Spade", "8"),
            new Karta("Spade", "9"),
            new Karta("Spade", "10"),
            new Karta("Spade", "Jack"),
            new Karta("Spade", "Queen"),
            new Karta("Spade", "King"),
            new Karta("Spade", "Ace"),
        };

             void Shuffle(Karta[] coloda)
            {
                Random rng = new Random();
                int n = 0;
                while (n < 35)
                {
                    int k = rng.Next(n + 1);
                    Karta value = coloda[k];
                    coloda[k] = coloda[n];
                    coloda[n] = value;
                    n++;
                }
            }

            public Game()
            {
                Shuffle(deck);
                Karta[] p1 = new Karta[18];
                Karta[] p2 = new Karta[18];

                for(int i = 0, j1 = 0, j2 = 0; i < 36; i++)
                {
                    if (i % 2 == 0) { p1[j1] = deck[i]; j1++; }
                    else { p2[j2] = deck[i]; j2++; }
                }
                deck = null;

                

                player1 = new Player("Player1", p1);
                player2 = new Player("Player2", p2);
                p1 = null;
                p2 = null;
                
                GC.Collect();
                GC.WaitForPendingFinalizers();

            }

            public void Start()
            {
                List<Karta> table = new List<Karta>();
                int card1 = 0, card2 = 0;
                while (player1.card.Count != 0 && player1.card.Count != 0)
                {
                    Clear();
                    table.Add(player1.card[0]);
                    player1.card.RemoveAt(0);
                    table.Add(player2.card[0]);
                    player2.card.RemoveAt(0);

                    WriteLine($"Player1 card = {table[0]}");
                    WriteLine($"Player2 card = {table[1]}");
                    switch (table[0]._namecard)
                    {
                        case "6": card1 = 6; break;
                        case "7": card1 = 7; break;
                        case "8": card1 = 8; break;
                        case "9": card1 = 9; break;
                        case "10": card1 = 10; break;
                        case "Jack": card1 = 11; break;
                        case "Queen": card1 = 12; break;
                        case "King": card1 = 13; break;
                        case "Ace": card1 = 14; break;
                    }

                    switch (table[1]._namecard)
                    {
                        case "6": card2 = 6; break;
                        case "7": card2 = 7; break;
                        case "8": card2 = 8; break;
                        case "9": card2 = 9; break;
                        case "10": card2 = 10; break;
                        case "Jack": card2 = 11; break;
                        case "Queen": card2 = 12; break;
                        case "King": card2 = 13; break;
                        case "Ace": card2 = 14; break;
                    }

                    if (card1 < card2) { player2.card.Add(table[0]); player2.card.Add(table[1]); table.RemoveAt(0); table.RemoveAt(0); WriteLine("Player2 pick up cards"); }
                    else if (card1 > card2) { player1.card.Add(table[0]); player1.card.Add(table[1]); table.RemoveAt(0); table.RemoveAt(0); WriteLine("Player1 pick up cards"); }
                    else if (card1 == card2) { player1.card.Add(table[0]); player2.card.Add(table[1]); table.RemoveAt(0); table.RemoveAt(0); WriteLine("Identical cards. Nobody takes"); }
                    if (player1.card.Count == 0) { WriteLine("Player2 WIN!"); break; }
                    if (player2.card.Count == 0) { WriteLine("Player1 WIN!"); break; }
                    ReadKey();
                }
            }



        }
        static void Main()
        {
            Game game = new Game();
            game.Start();

            ReadKey();
        }
    }

}
