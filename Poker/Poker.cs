using System;

namespace Poker
{
    public class Poker
    {
        private Deck _deck;
        private Player _playerOne;
        private Player _playerTwo;

        public void StartGame()
        {
            while (true)
            {
                _deck = new Deck();
                _playerOne = new Player();
                _playerTwo = new Player();

                PrepareGame();
                ShowPlayersCard();
                AskForSwapCard();
                ShowGameResults();

                //if (_playerOne.Hand.WinningSet == WinningSet.Straight) break;
                //if (_playerTwo.Hand.WinningSet == WinningSet.Straight) break;

                if (Console.ReadKey().KeyChar == 'e')
                {
                    break;
                }
                Console.Clear();
            }
        }

        private void PrepareGame()
        {
            _playerOne.Hand.Cards = _deck.GetCards();
            _playerTwo.Hand.Cards = _deck.GetCards();
        }
        private void ShowPlayersCard()
        {
            Console.Write(_playerOne.ToString());
            Console.WriteLine(_playerOne.Hand.ToString());
            Console.Write(_playerTwo.ToString());
            Console.WriteLine(_playerTwo.Hand.ToString());
        }
        private void AskForSwapCard()
        {
            Console.WriteLine("Would you like to swap any card? If yes type yes"); 

            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine();
                Console.WriteLine("Which one?");
                var cardsToSwap = Console.ReadLine();
            }
            Console.WriteLine(_playerOne.Hand.ToString());
        }
        private void ShowGameResults()
        {
            HandSetAssigner.CheckPlayerWinningSet(_playerOne);
            HandSetAssigner.CheckPlayerWinningSet(_playerTwo);

            Console.WriteLine();
            Console.WriteLine("Player" + _playerOne.PlayerId + " : " + _playerOne.Hand.WinningSet);
            Console.WriteLine("Player" + _playerTwo.PlayerId + " : " + _playerTwo.Hand.WinningSet);
            Console.WriteLine();

            var gameResult = _playerOne.Hand.CompareTo(_playerTwo.Hand);

            switch (gameResult)
            {
                case 1:
                    Console.WriteLine("The winer is Player " + _playerOne.PlayerId);
                    break;
                case -1:
                    Console.WriteLine("The winer is Player " + _playerTwo.PlayerId);
                    break;
                case 0:
                    Console.WriteLine("Draw");
                    break;
            }
        }
    }
}