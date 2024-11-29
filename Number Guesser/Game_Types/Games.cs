using Number_Guesser.Game_Types.Handlers;

namespace Number_Guesser.Game_Types
{
    public class Games
    {
        private bool GameRunning;
        private Random rnd;
        private Player player;
        private GameStats stats;
        
        public Games()
        {
            GameRunning = true;
            rnd = new Random();
            player = new Player();
            stats = new GameStats();
        }

        public void Start()
        {
            while (GameRunning)
            {
                CustomGame();
            }
        }

        public void CustomGame()
        {
            int lowerBound = 0,
                upperBound = 0;
            Console.WriteLine("Set the Range of Numbers ");
            lowerBound = player.GetValidNumber("Enter lower bound: ");
            upperBound = player.GetValidNumber("Enter upper bound: ");
            while (upperBound <= lowerBound)
            {
                Console.WriteLine("Invalid number. Upper Bound must be greater than lower bound.");
                upperBound = player.GetValidNumber("Enter upper bound: ");
            }
            int numberToGuess = rnd.Next(lowerBound, upperBound + 1);
            int guess = 0;
            int attempts = 0;

            while (guess != numberToGuess)
            {
                guess = player.GetValidNumber("Enter number: ");
                attempts++;
                if (guess > numberToGuess)
                {
                    Console.WriteLine("You guessed too high. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else if (guess < numberToGuess)
                {
                    Console.WriteLine("You guessed too low. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You correctly guessed the number {numberToGuess} in {attempts} attempts.");
                }
            }

            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Do you want to continue? (y/n)");
            string input = Console.ReadLine();
            if (input.ToLower() is "n" or "no" or "nah" or "ne")
            {
                GameRunning = false;
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
        }
    }
}
