using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public enum Suit
    {
        Hearts = 0,
        Diamonds,
        Clubs,
        Spades
    }

    public enum Face
    {
        Ace = 0,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    public class Card
    {
        public Face Face { get; }
        public Suit Suit { get; }
        public char Symbol;
        public string Value;
        public int Cost { get; set; }

        public Card(Face face, Suit suit)
        {
            Suit = suit;
            Face = face;
            switch (suit)
            {
                case Suit.Hearts:
                    {
                        Symbol = '♥';
                        break;
                    }
                case Suit.Clubs:
                    {
                        Symbol = '♣';
                        break;
                    }
                case Suit.Spades:
                    {
                        Symbol = '♠';
                        break;
                    }
                case Suit.Diamonds:
                    {
                        Symbol = '♦';
                        break;
                    }
            }
            switch (face)
            {
                case Face.Two:
                    {
                        Cost = 2;
                        Value = "2";
                        break;
                    }
                case Face.Three:
                    {
                        Cost = 3;
                        Value = "3";
                        break;
                    }
                case Face.Four:
                    {
                        Cost = 4;
                        Value = "4";
                        break;
                    }
                case Face.Five:
                    {
                        Cost = 5;
                        Value = "5";
                        break;
                    }
                case Face.Six:
                    {
                        Cost = 6;
                        Value = "6";
                        break;
                    }
                case Face.Seven:
                    {
                        Cost = 7;
                        Value = "7";
                        break;
                    }
                case Face.Eight:
                    {
                        Cost = 8;
                        Value = "8";
                        break;
                    }
                case Face.Nine:
                    {
                        Cost = 9;
                        Value = "9";
                        break;
                    }
                case Face.Ten:
                    {
                        Cost = 10;
                        Value = "10";
                        break;
                    }
                case Face.Jack:
                    {
                        Cost = 10;
                        Value = "J";
                        break;
                    }
                case Face.Queen:
                    {
                        Cost = 10;
                        Value = "Q";
                        break;
                    }
                case Face.King:
                    {
                        Cost = 10;
                        Value = "K";
                        break;
                    }
                case Face.Ace:
                    {
                        Cost = 11;
                        Value = "A";
                        break;
                    }
            }
        }
    }
}
