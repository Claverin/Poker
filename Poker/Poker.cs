using System;

namespace Poker
{
    public class Poker
    {
        private Deck deck;
        private Player playerOne;
        private Player playerTwo;

        public Poker()
        {
            deck = new Deck();
            playerOne = new Player();
            playerTwo = new Player();

            PreareGame();
            ShowPlayersCard();
            ShowGameResults();
        }
        private void PreareGame()
        {
            deck.BuildDeck();
            playerOne.Hand = deck.GetXCards();
            playerOne.SortHandByFigure();
            playerTwo.Hand = deck.GetXCards();
            playerTwo.SortHandByFigure();
        }
        private void ShowPlayersCard()
        {
            Console.WriteLine(playerOne.ToString());
            Console.WriteLine(playerTwo.ToString());
        }
        private void ShowGameResults()
        {

            CardComparator.CheckForWinner(playerOne);
            CardComparator.CheckForWinner(playerTwo);

            Console.WriteLine();
            Console.WriteLine("Player" + playerOne.PlayerId + " : " + playerOne.winningSet);
            Console.WriteLine("Player" + playerTwo.PlayerId + " : " + playerTwo.winningSet);
            Console.WriteLine();
            if (playerOne.winningSet > playerTwo.winningSet) Console.WriteLine("The winer is Player " + playerOne.PlayerId);
            if (playerOne.winningSet < playerTwo.winningSet) Console.WriteLine("The winer is Player " + playerTwo.PlayerId);
            if (playerOne.winningSet == playerTwo.winningSet)
            {
                Console.Write("The sets are same so ");
                if (playerOne.highCard > playerTwo.highCard)
                    Console.WriteLine("player " + playerOne.PlayerId + " is winning because of high card");
                else if (playerOne.highCard < playerTwo.highCard)
                    Console.WriteLine("player " + playerTwo.PlayerId + " is winning because of high card");
                else Console.WriteLine("it is draw high card:");
                Console.WriteLine(playerOne.highCard + " || " + playerTwo.highCard);
            }
        }
    }
}