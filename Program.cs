using System;
using System.Collections.Generic;

namespace deckOfCards
{

    public class Card 
    {
        public string strVal;
        public string suit;
        public int val;

        public Card(string name, string suitType, int value)
        {
            strVal = name;
            suit = suitType;
            val = value;
        }
    }

    public class Deck 
    {
        public List<Card> cards;

        public Deck()
        {
            reset();
            shuffle();
        }

        public Deck reset()
        {
            cards = new List<Card>();     
            string[] suits = {"Hearts","Diamonds","Spades","Clubs"};
            string[] strVals = {"Ace","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten","Jack","Queen","King"}; 

            foreach(string suit in suits)
            {
                for (int i = 0; i < strVals.Length; i++)
                {
                    Card newDeck = new Card(strVals[i], suit, i+1);
                    cards.Add(newDeck);
                }
            }
            return this;
        }

        public Deck shuffle()
        {
            Random rand = new Random();
            for (int i = cards.Count-1; i > 0; i--)
            {
                int j = rand.Next(i+1);
                Card temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
            return this;
        }

        public Card deal()
        {
            while (cards.Count > 0)
            {
                Card top = cards[0];
                cards.RemoveAt(0);
                return top;
            }
            reset();
            return deal();   
        }
    }

    public class Player
    {
        string name;
        public List<Card> hand;

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw(Deck playerDeck)
        {
            Card newDeck = playerDeck.deal();
            hand.Add(newDeck);
            return newDeck;
        }

        public Card discard(int idx)
        {
            if(idx < 0 || idx > hand.Count)
            {
                Console.WriteLine("You Counted The Cards!");
                return null;
            }
            else
            {
                Card res = hand[idx];
                hand.RemoveAt(idx);
                return res;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDraw = new Deck();
            Player Damian = new Player("Damian");
            Console.WriteLine($"Your Hand Has {Damian.hand.Count} Cards");
            Console.WriteLine("======DRAWING CARDS======");
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Damian.draw(newDraw);
            Console.WriteLine($"Your Hand Has {Damian.hand.Count} Cards");
            Console.Write("Your Hand Contains The Following Cards: ");
            foreach (var card in Damian.hand)
            {
                Console.Write($"{card.strVal} of {card.suit}; ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("======DISCARDING CARDS======");
            Damian.discard(1);
            Damian.discard(2);
            Damian.discard(3);
            Damian.discard(5);
            Damian.discard(6);
            Damian.discard(7);
            Damian.discard(9);
            Damian.discard(10);
            Console.WriteLine($"Your Hand Has {Damian.hand.Count} Cards");
            Console.Write("Your Hand Contains The Following Cards: ");
            foreach (var card in Damian.hand)
            {
                Console.Write($"{card.strVal} of {card.suit}; ");
            }
            Console.WriteLine();
        }
    }
}
