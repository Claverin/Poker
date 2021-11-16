using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Deck
    {
        public List<Card> Cards { get; private set; } = new List<Card>(52);
        public Deck()
        {
            BuildDeck();
        }
        private void BuildDeck()
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
                    figures.ForEach(figure => Cards
                    .Add(new Card(figure, color)));
                }
            );
        }
        public Card DrawCard()
        {
            int randomNumber = new Random().Next(Cards.Count);
            var card = Cards[randomNumber];
            Cards.Remove(card);

            return card;
        }
        public List<Card> GetCards(int x = 5)
        {
            return Enumerable
                .Range(0, x)
                .Select(it=>DrawCard())
                .ToList();
        }
        public void SwapCards()
        {

        }
        public void DiscardCards()
        {
            Console.WriteLine("Write the number of card that you want to discard:");
        }
    }
}