using System.Diagnostics;
using Number_Guesser.Game_Types.Handlers;

namespace Number_Guesser.Game_Types {
    public class Games {
        private bool GameRunning;
        private Random rnd;
        private Player player;
        private GameStats stats;
        private Difficulty difficulty;
        private GameMode mode;
        private int maxGuesses;

        public Games() {
            GameRunning = true;
            rnd = new Random();
            player = new Player();
            stats = new GameStats();
            difficulty = ChooseDifficulty();
            mode = ChooseGameMode();
            maxGuesses = SetMaxGuesses();
            if (mode == GameMode.LimitedGuesses) {
                difficulty = ChooseDifficulty();
                maxGuesses = SetMaxGuesses();
            }
            else {
                difficulty = Difficulty.Medium;
            }
        }

        public void Start() {
            while (GameRunning) {
                if (mode == GameMode.Standard) {
                    CustomGame();
                }
                else if (mode == GameMode.LimitedGuesses) {
                    LimitedGuessesGame();
                }
            }
        }

        public void CustomGame() {
            int lowerBound = 0,
                upperBound = 0;
            Console.WriteLine("Set the Range of Numbers ");
            lowerBound = player.GetValidNumber("Enter lower bound: ");
            upperBound = player.GetValidNumber("Enter upper bound: ");
            while (upperBound <= lowerBound) {
                Console.WriteLine("Invalid number. Upper Bound must be greater than lower bound.");
                upperBound = player.GetValidNumber("Enter upper bound: ");
            }

            int numberToGuess = rnd.Next(lowerBound, upperBound + 1);
            int guess = 0;
            int attempts = 0;

            while (guess != numberToGuess) {
                guess = player.GetValidNumber("Enter number: ");
                attempts++;
                if (guess > numberToGuess) {
                    Console.WriteLine("You guessed too high. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else if (guess < numberToGuess) {
                    Console.WriteLine("You guessed too low. Try again.");
                    Thread.Sleep(1500);
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else {
                    Console.Clear();
                    Console.WriteLine($"You correctly guessed the number {numberToGuess} in {attempts} attempts.");
                }
            }

            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Do you want to continue? (y/n)");
            string input = Console.ReadLine();
            if (input.ToLower() is "n" or "no" or "nah" or "ne") {
                GameRunning = false;
                Console.Clear();
            }
            else {
                Console.Clear();
            }
        }

        public void LimitedGuessesGame() {
            int lowerBound, upperBound;
            switch (difficulty) {
                case Difficulty.Easy:
                    lowerBound = 0;
                    upperBound = 50;
                    break;
                case Difficulty.Medium:
                    lowerBound = 0;
                    upperBound = 100;
                    break;
                case Difficulty.Hard:
                    lowerBound = 0;
                    upperBound = 150;
                    break;
                case Difficulty.Extreme:
                    lowerBound = 0;
                    upperBound = 200;
                    break;
                default:
                    lowerBound = 0;
                    upperBound = 100;
                    break;
            }

            int NumberToGuess = rnd.Next(lowerBound, upperBound + 1);
            int Guess = 0;
            int attempts = 0;

            while (Guess != NumberToGuess && attempts < maxGuesses) {
                Guess = player.GetValidNumber("enter number: ");
                attempts++;
                if (Guess > NumberToGuess) {
                    Console.WriteLine("You Guessed too high. Try Again");
                    Thread.Sleep(GetSleepTime());
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else if (Guess < NumberToGuess) {
                    Console.WriteLine("You Guessed too low. Try Again");
                    Thread.Sleep(GetSleepTime());
                    Console.Clear();
                    stats.DisplayStats(lowerBound, upperBound, attempts);
                }
                else {
                    Console.Clear();
                    Console.WriteLine($"You found the {NumberToGuess} in {attempts}");
                    return;
                }
            }

            if (Guess != NumberToGuess) {
                Console.Clear();
                Console.WriteLine("You have run out of guesses better luck next time");
            }

            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Do you want to continue (y/n)");
            string input = Console.ReadLine();

            if (input.ToLower() is "n" or "no" or "nah" or "ne") {
                GameRunning = false;
                Console.Clear();
            }
            else {
                Console.Clear();
            }
        }

        private int GetSleepTime() {
            switch (difficulty) {
                case Difficulty.Easy:
                    return 1000;
                case Difficulty.Medium:
                    return 1500;
                case Difficulty.Hard:
                    return 2000;
                case Difficulty.Extreme:
                    return 2500;
                default:
                    return 1500;
            }
        }

        private Difficulty ChooseDifficulty() {
            Console.WriteLine("Choose difficulty level:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
            Console.WriteLine("4. Extreme");

            int choice = player.GetValidNumber("Enter choice: ");
            switch (choice) {
                case 1:
                    return Difficulty.Easy;
                case 2:
                    return Difficulty.Medium;
                case 3:
                    return Difficulty.Hard;
                case 4:
                    return Difficulty.Extreme;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Medium.");
                    return Difficulty.Medium;
            }
            
        }
        private GameMode ChooseGameMode() {
            Console.WriteLine("Choose Game Mode:");
            Console.WriteLine("1. Standard");
            Console.WriteLine("2. Limited Guesses");

            int choice = player.GetValidNumber("Enter choice: ");
            switch (choice) {
                case 1:
                    return GameMode.Standard;
                case 2:
                    return GameMode.LimitedGuesses;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Standard.");
                    return GameMode.Standard;
            }
        }
        private int SetMaxGuesses() {
            switch (difficulty) {
                case Difficulty.Easy:
                    return 10;
                case Difficulty.Medium:
                    return 7;
                case Difficulty.Hard:
                    return 6;
                case Difficulty.Extreme:
                    return 4;
                default:
                    return 7;
            }
        }
    }
}


    

