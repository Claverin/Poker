using System;
using System.Linq;

namespace Poker
{
    class CardComparator
    {
        public static void CheckForWinner(Player player)
        {
            bool strit = false;
            bool color = false;

            HighCardCheck();
            PairOrMoreCheck();
            StraightCheck();
            ColorCheck();
            StraightFlushCheck();

            void PairOrMoreCheck()
            {
                var sameFigureCounter = player.Hand
                    .GroupBy(s => s.figure).Count();

                var maxOfSameFigureCounter = player.Hand
                    .GroupBy(s => s.figure)
                    .Select(g => new { Name =g.Key, Count = g.Count() }).OrderByDescending(g => g.Count).First();

                switch (sameFigureCounter)
                {
                    case 5:
                        break;
                    case 4:
                        player.winningSet = WinningSet.OnePair;
                        player.highCard = maxOfSameFigureCounter.Name;
                        break;
                    case 3:
                        if (maxOfSameFigureCounter.Count == 3)
                        {
                            player.winningSet = WinningSet.ThreeOfAKind;
                            player.highCard = maxOfSameFigureCounter.Name;
                        }
                        else
                        {
                            player.winningSet = WinningSet.TwoPair;
                            player.highCard = maxOfSameFigureCounter.Name;
                        }
                        break;
                    case 2:
                        if (maxOfSameFigureCounter.Count == 3)
                        {
                            player.winningSet = WinningSet.FullHouse;
                            player.highCard = maxOfSameFigureCounter.Name;
                        }
                        else
                        {
                            player.winningSet = WinningSet.FourOfAKind;
                            player.highCard = maxOfSameFigureCounter.Name;
                        }    
                        break;
                }
            }
            void HighCardCheck()
            {
                player.highCard = player.Hand.Max(it => it.figure);
            }
            void StraightCheck()
            {
                if ((int)player.Hand[4].figure == (int)player.Hand[3].figure + 1 &&
                   (int)player.Hand[3].figure == (int)player.Hand[2].figure + 1 &&
                   (int)player.Hand[2].figure == (int)player.Hand[1].figure + 1 &&
                   (int)player.Hand[1].figure == (int)player.Hand[0].figure + 1)
                {
                    player.winningSet = WinningSet.Straight;
                    strit = true;
                }
            }
            void ColorCheck()
            {
                var colourCounter = player.Hand
                .GroupBy(s => s.color).Count();
                if (colourCounter == 1)
                {
                    player.winningSet = WinningSet.Flush;
                    color = true;
                }
            }
            void StraightFlushCheck()
            {
                if (color && strit)
                {
                    player.winningSet = WinningSet.StraightFlush;

                    RoyalFlushCheck();
                }
            }
            void RoyalFlushCheck()
            {
                if ((int)player.Hand[0].figure == 8 && strit)
                {
                    player.winningSet = WinningSet.RoyalFlush;
                }
            }
        }
    }
}