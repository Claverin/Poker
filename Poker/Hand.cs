using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Poker
{
    public class Hand : IComparable<Hand>
    {

        public Figure highCard;
        public WinningSet WinningSet;
        public List<Card> Cards { get; set; } = new List<Card>();

        public Hand()
        {
            WinningSet = WinningSet.HighCard;
            highCard = Figure.Two;
        }

        public int CompareTo([AllowNull] Hand other)
        {
            if(this.WinningSet > other.WinningSet) return 1;
            else if (this.WinningSet < other.WinningSet) return -1;
            else
            {
                Console.WriteLine("The sets are same so we need to check the high cards: ");
                Console.WriteLine($"{this.highCard} vs {other.highCard}");
                Console.WriteLine();

                if (this.highCard > other.highCard) return 1;
                else if (this.highCard < other.highCard) return -1;
                else return 0;
            }
        }

        override public string ToString()
        {
            Cards = Cards.OrderBy(it => it.Figure).ToList();
            var cardString = "";
            Cards.ForEach(it => cardString += it.ToString() + " | ");
            return cardString;
        }
    }
}
