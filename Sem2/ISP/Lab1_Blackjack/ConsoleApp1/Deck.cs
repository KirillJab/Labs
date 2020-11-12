using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Deck
    {
        public List<Card> Cards = new List<Card>();
        public void ShowDeck()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                Console.Write("|" + Cards[i].Value + Cards[i].Symbol + "|");
            }
            return;
        }
        public void ShowDealerDeck()
        {
            Console.Write("|" + Cards[0].Value + Cards[0].Symbol + "|");
            if(Cards.Count == 2)
                Console.Write("|**|");
            return;
        }
        public void ShuffleDeck()
        {
            Random rand = new Random();
            for(int i = 0; i < 52; i++)
            {
                int n = rand.Next(0, 52);
                Card curCard = Cards[i];
                Cards[i] = Cards[n];
                Cards[n] = curCard;
            }
            return;
        }
        public List<Card> GetDeck()
        {
            Cards.Clear();
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Cards.Add(new Card((Face)i, (Suit)j));
                }
            }
            return Cards;
        }
        public Card GetCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
