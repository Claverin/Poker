namespace Poker
{
    public class Card
    {
        public Figure Figure { get; set; }
        public Color Color { get; set; }
        public Card(Figure _figure, Color _color)
        {
            Figure = _figure;
            Color = _color;
        }

        override public string ToString() => $"{Figure} of {Color}";
    }
}