using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    class Player
    {
        public int PlayerId;
        public Figure highCard;
        public static int PlayerCounter = 0;
        public List<Card> Hand = new List<Card>(5);
        public WinningSet winningSet { get; set; }

        public Player()
        {
            Player.PlayerCounter += 1;
            PlayerId = Player.PlayerCounter;
            winningSet = WinningSet.HighCard;
            highCard = Figure.Ten;
        }

        public void SortHandByFigure()
        {
            Hand = Hand.OrderBy(it => it.figure).ToList();
        }

        override
        public string ToString()
        {
            var playerString = "Player " + PlayerId + "\n";
            Hand.ForEach(it => playerString += it.ToString() + " | ");
            return playerString;
        }
    }
}