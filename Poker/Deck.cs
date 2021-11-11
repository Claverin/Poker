using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Deck
    {
        public List<Card> deck = new List<Card>(52);
        public void BuildDeck()
        {
            var colors = Enum
                .GetValues(typeof(Color))
                .OfType<Color>()
                .ToList();
            var figures = Enum
                .GetValues(typeof(Figure))
                .OfType<Figure>()
                .ToList();

            colors.ForEach(
                color =>
                {
                    figures.ForEach(
              figure => deck.Add(new Card(figure, color))
              );
                }
            );

        }
        public Card DrawCard()
        {
            int randomNumber = new Random().Next(deck.Count);
            var card = deck[randomNumber];
            deck.Remove(card);
            return card;
        }
        public List<Card> GetXCards(int x = 5)
        {
            return Enumerable
                .Range(0, x)
                .Select(it=>DrawCard())
                .ToList();
        }
        public void ShowDeck()
        {
            deck.ForEach(it => System.Console.WriteLine(it.ToString()));
        }
        public int CountDeck()
        {
            return deck.Count;
        }
    }
}