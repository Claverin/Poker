using System.Linq;

namespace Poker
{
    public static class HandSetAssigner
    {
        private static bool _strit;
        private static bool _color;
        public static void CheckPlayerWinningSet(Player player)
        {
            _strit = false;
            _color = false;

            HighCardCheck(player);
            PairOrMoreCheck(player);
            StraightCheck(player);
            ColorCheck(player);
            StraightFlushCheck(player);
            RoyalFlushCheck(player);
        }
        private static void PairOrMoreCheck(Player player)
        {
            var diffrentFigureCounter = player.Hand.Cards
                .GroupBy(f => f.Figure).Count();

            var maxOfSameFigureCounter = player.Hand.Cards
                .GroupBy(f => f.Figure)
                .Select(g => new { Name = g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).First();

            switch (diffrentFigureCounter)
            {
                case 4:
                    player.Hand.WinningSet = WinningSet.OnePair;
                    player.Hand.highCard = maxOfSameFigureCounter.Name;
                    break;
                case 3:
                    if (maxOfSameFigureCounter.Count == 3)
                    {
                        player.Hand.WinningSet = WinningSet.ThreeOfAKind;
                    }
                    else
                    {
                        player.Hand.WinningSet = WinningSet.TwoPair;
                    }
                    player.Hand.highCard = maxOfSameFigureCounter.Name;
                    break;
                case 2:
                    if (maxOfSameFigureCounter.Count == 3)
                    {
                        player.Hand.WinningSet = WinningSet.FullHouse;
                    }
                    else
                    {
                        player.Hand.WinningSet = WinningSet.FourOfAKind;
                    }
                    player.Hand.highCard = maxOfSameFigureCounter.Name;
                    break;
            }
        }
        private static void HighCardCheck(Player player)
        {
            player.Hand.highCard = player.Hand.Cards.Max(it => it.Figure);
        }
        private static void StraightCheck(Player player)
        {
            int counter = 0;
            for (int i = 0; i < player.Hand.Cards.Count()-1; i++)
            {
                if (player.Hand.Cards[i].Figure == player.Hand.Cards[i + 1].Figure - 1) counter++;
                else break;
            }
            if (counter == 4)
            {
                player.Hand.WinningSet = WinningSet.Straight;
                _strit = true;
            }
        }
        private static void ColorCheck(Player player)
        {
            var colorCheck = player.Hand.Cards.All(c => c.Color == player.Hand.Cards[0].Color);

            if (colorCheck)
            {
                player.Hand.WinningSet = WinningSet.Flush;
                _color = true;
            }
        }
        private static void StraightFlushCheck(Player player)
        {
            if (_color && _strit)
            {
                player.Hand.WinningSet = WinningSet.StraightFlush;
            }
        }
        private static void RoyalFlushCheck(Player player)
        {
            if (_color && _strit && player.Hand.Cards[0].Figure == Figure.Ten)
            {
                player.Hand.WinningSet = WinningSet.RoyalFlush;
            }
        }
    }
}