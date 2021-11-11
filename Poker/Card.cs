namespace Poker
{
    class Card
    {
        public Figure figure { get; set; }
        public Color color { get; set; }
        public Card(Figure _figure, Color _color)
        {
            figure = _figure;
            color = _color;
        }

        override
        public string ToString() => figure.ToString() + " " + color.ToString();
    }
}