namespace Poker
{
    public class Player
    {
        public int PlayerId;
        public static int PlayerCounter = 0;
        public Hand Hand { get; set; } = new Hand();

        public Player()
        {
            PlayerCounter += 1;
            PlayerId = PlayerCounter;
        }
        override public string ToString()
        {
            var playerString = "Player " + PlayerId + "\n";
            return playerString;
        }
    }
}