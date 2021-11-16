namespace Poker
{
    public class Player
    {
        public int PlayerId;
        public Hand Hand { get; set; } = new Hand();

        public Player(int playerCounter)
        {
            PlayerId = playerCounter;
        }
        override public string ToString()
        {
            var playerString = "Player " + PlayerId + "\n";
            return playerString;
        }
    }
}